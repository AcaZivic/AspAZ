using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Username { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
