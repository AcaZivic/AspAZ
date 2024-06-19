using AspAZ.Application.UseCases;

using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Application
{
    public interface IQuery<TSearch, TResult> : IUseCase
        where TResult : class
    {
        TResult Execute(TSearch search);
    }
}
