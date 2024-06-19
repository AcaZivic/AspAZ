using AspAZ.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor with an id of {actor.Id} - {actor.Username} tried to execute {useCase.Name}.")
        {
        }
    }
}
