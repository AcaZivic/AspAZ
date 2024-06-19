using AspAZ.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAZ.Api.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Username => "Test Api User";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1 };
    }

    public class AdminFakeApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Username => "Fake Admin";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);

    }
}
