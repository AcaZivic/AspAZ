using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application
{
    public class UseCaseExecutor2
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor2(IApplicationActor actor)
        {
            this.actor = actor;
        }

        //public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        //{
        //    //logger.Log(query, actor, search);

        //    Console.WriteLine($"{DateTime.Now}: {actor.Username} is trying to execute {query.Name} using data: " +
        //        $"{JsonConvert.SerializeObject(search)}");

        //    if (!actor.AllowedUseCases.Contains(query.Id))
        //    {
        //        throw new UnauthorizedUseCaseException(query, actor);
        //    }

        //    return query.Execute(search);
        //}

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            //logger.Log(command, actor, request);
            Console.WriteLine($"{DateTime.Now}: {actor.Username} is trying to execute {command.Name} using data: " +
                $"{JsonConvert.SerializeObject(request)}");
            // 1 (1,2,3,4)
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }

            command.Execute(request);

        }
    }
}
