using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Application.UseCases
{
    public interface ICommand<TData> : IUseCase
    {
        void Execute(TData data);
    }
}
