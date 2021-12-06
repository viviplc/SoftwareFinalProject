using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    class Funds
    {
        private double amount;
        private bool fromSponsor;

        public Funds(double amount, bool fromSponsor)
        {
            this.Amount = amount;
            this.FromSponsor = fromSponsor;
        }

        public double Amount { get => amount; set => amount = value; }
        public bool FromSponsor { get => fromSponsor; set => fromSponsor = value; }
    }
}
