using AspAZ.Application.UseCases;
using AspAZ.DataTransfer;
using AspYt.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.UseCases.Commands
{
    public interface IUpdateCartCommand : ICommand<UpdateCartDto>
    {
    }
}
