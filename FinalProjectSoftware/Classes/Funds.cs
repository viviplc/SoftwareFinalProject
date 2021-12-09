using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public class Funds : IFunds
    {
        private double amount;
        private bool fromSponsor;
        public Funds()
        {

        }
        public Funds(double amount, bool fromSponsor)
        {
            this.Amount = amount;
            this.FromSponsor = fromSponsor;
        }

        public double Amount { get => amount; set => amount = value; }
        public bool FromSponsor { get => fromSponsor; set => fromSponsor = value; }
    }
}
