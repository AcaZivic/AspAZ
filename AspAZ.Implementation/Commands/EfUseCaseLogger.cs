using AspAZ.Application;
using AspAZ.DataAccess;
using AspAZ.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly GameKingdomContext _context;

        public EfUseCaseLogger(GameKingdomContext context)
        {
            _context = context;
        }

        public void Log(UseCaseLogDTO log)
        {
            var _log = new UseCaseLog
            {
                Username = log.Username,
                ExecutedAt = DateTime.Now,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData),
                UseCaseName = log.UseCaseName

            };
            _context.UseCaseLogs.Add(_log);
            _context.SaveChanges();

        }
    }
}
