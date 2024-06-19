using AspAZ.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Domain
{
    public class UserUseCase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public virtual Employee User { get; set; }
    }
}
