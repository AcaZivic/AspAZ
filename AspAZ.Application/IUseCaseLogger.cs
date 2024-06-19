using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Application
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLogDTO log);
    }

    public class UseCaseLogDTO
    {
        public string Username { get; set; }
        public string UseCaseName { get; set; }
        public object UseCaseData { get; set; }
    }
}
