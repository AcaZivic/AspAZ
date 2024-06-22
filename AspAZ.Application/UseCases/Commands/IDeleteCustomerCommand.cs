using AspAZ.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.UseCases.Commands
{
    public interface IDeleteCustomerCommand : ICommand<int>
    {
    }
}
