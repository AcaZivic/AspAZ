﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Domain
{
    public class UseCaseLog :Entity
    {
        public string UseCaseName { get; set; }
        public string Username { get; set; }
        public string UseCaseData { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}
