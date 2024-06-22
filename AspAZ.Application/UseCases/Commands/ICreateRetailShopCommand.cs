using AspAZ.Application.UseCases;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.UseCases.Commands
{
    public interface ICreateRetailShopCommand : ICommand<CreateRetailShopDTO>
    {
    }
}
