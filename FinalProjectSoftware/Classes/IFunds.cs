using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Classes
{
    interface IFunds
    {
        public double Amount { get; set; }
        public bool FromSponsor { get; set; }
    }
}
