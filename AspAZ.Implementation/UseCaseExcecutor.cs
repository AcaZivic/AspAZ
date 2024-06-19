using AspAZ.Application;
using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AspAZ.Implementation
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;

        public UseCaseExecutor(IApplicationActor actor,IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;

            
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
             where TResult : class
        {
            var temp = new UseCaseLogDTO{
                UseCaseData = search,
                UseCaseName = query.Name,
                Username = _actor.Username,
            };
            
            _logger.Log(temp );

            Console.WriteLine($"{DateTime.Now}: {_actor.Username} is trying to execute {query.Name} using data: " +
                $"{JsonConvert.SerializeObject(search)}");

            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, _actor);
            }

            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            var temp = new UseCaseLogDTO
            {
                UseCaseData = request,
                UseCaseName = command.Name,
                Username = _actor.Username,
            };
            _logger.Log(temp);
            Console.WriteLine($"{DateTime.Now}: {_actor.Username} is trying to execute {command.Name} using data: " +
                $"{JsonConvert.SerializeObject(request)}");
            // 1 (1,2,3,4)
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }

            command.Execute(request);

        }
    }
}
