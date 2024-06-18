﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AspYt.Domain
{
    public class UseCaseLog
    {
        public int Id { get; set; }
        public string UseCaseName { get; set; }
        public string Username { get; set; }
        public string UseCaseData { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}
