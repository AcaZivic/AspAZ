using AspAZ.Api.Core;
using AspAZ.Application;
using AspAZ.Implementation;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace AspAZ.API.Core
{
    public class JWTprovider : IApplicationActorProvider
    {
        private string authorizationHeader;

        public JWTprovider(string authorizationHeader)
        {
            this.authorizationHeader = authorizationHeader;
        }

        public IApplicationActor GetActor()
        {
            

            if (authorizationHeader.Split("Bearer").Length != 2)
            {
                return new UnauthorizedActor();
            }

            string token = authorizationHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var data = claims.Where(x => x.Type == "ActorData").FirstOrDefault().Value;
            var actor = JsonConvert.DeserializeObject<JwtActor>(data);


            //var actor = new Actor
            //{
            //    Username = claims.First(x => x.Type == "Username").Value,
            //    Id = int.Parse(claims.First(x => x.Type == "Id").Value),
            //    AllowedUseCases = JsonConvert.DeserializeObject<List<int>>(claims.First(x => x.Type == "UseCaseIds").Value)
            //};

            return actor;
        }
    }
}
