using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Application
{
    public interface IApplicationActorProvider
    {
        IApplicationActor GetActor();
    }
}
