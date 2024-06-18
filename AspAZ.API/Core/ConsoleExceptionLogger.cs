using AspAZ.Application;
using AspAZ.DataAccess;
using AspAZ.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspAZ.API.Core
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public Guid Log(Exception ex, IApplicationActor actor)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(ex.Message + " ID: " + id);

            return id;
        }
    }

    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly GameKingdomContext _context;

        public DbExceptionLogger(GameKingdomContext aspContext)
        {
            _context = aspContext;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            //ID, Message, Time, StrackTrace
            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };

            //_context.Entry(log).State = EntityState.Added;

            _context.ErrorLogs.Add(log);

            _context.SaveChanges();

            return id;
        }
    }
}
