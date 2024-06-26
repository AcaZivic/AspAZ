using AspAZ.Application;
using AspAZ.DataAccess;
using AspAZ.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation
{
    public class BasicAuthorizationApplicationActorProvider : IApplicationActorProvider
    {
        private string _authorizationHeader;
        private GameKingdomContext _context;

        public BasicAuthorizationApplicationActorProvider(string authorizationHeader, GameKingdomContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }

        public IApplicationActor GetActor()
        {
            if (_authorizationHeader == null || !_authorizationHeader.Contains("Basic"))
            {
                return new UnauthorizedActor();
            }

            var base64Data = _authorizationHeader.Split(" ")[1];



            var bytes = Convert.FromBase64String(base64Data);

            var decodedCredentials = System.Text.Encoding.UTF8.GetString(bytes);

            if(decodedCredentials.Split(":").Length < 2)
            {
                throw new InvalidOperationException("Invalid Basic authorization header.");
            }

            string username = decodedCredentials.Split(":")[0];
            string password = decodedCredentials.Split(":")[1];

            Employee e = _context.Employees.Include(x => x.UseCases)
                                   .FirstOrDefault(x => x.Username == username && x.Password == password);
            
            if(e == null)
            {
                return new UnauthorizedActor();
            }

            var useCases = e.UseCases.Select(x => x.UseCaseId).ToList();

            return new Actor
            {
                Id = e.Id,
                Username = e.Username,
                AllowedUseCases = useCases
            };
        }
    }
}
