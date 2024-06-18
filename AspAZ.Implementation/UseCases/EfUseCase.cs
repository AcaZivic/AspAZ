using AspAZ.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly GameKingdomContext _context;

        protected EfUseCase(GameKingdomContext context)
        {
            _context = context;
        }

        protected GameKingdomContext Context => _context;
    }
}
