using AspAZ.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation
{
    public class DefaultActorProvider : IApplicationActorProvider
    {
        public IApplicationActor GetActor()
        {
            return new Actor
            {
                Username = "test",
                Id = 0,
            };
        }
    }
}
