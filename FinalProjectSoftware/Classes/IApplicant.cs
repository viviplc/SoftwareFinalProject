﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    interface IApplicant : IComparable<IApplicant>
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public string PassportNumber { get; set; }
        public string Birthday { get; set; }
        public string Country { get; set; }
        public Visa Visa { get; set; }
    }
}
