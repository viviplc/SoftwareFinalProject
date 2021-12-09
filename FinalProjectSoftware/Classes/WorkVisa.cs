using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public class WorkVisa : Visa
    {
        private static int UCI = 0;
        private int uciId = 0;

        public int UciId { get => uciId; }

        public WorkVisa()
        {
            UCI++;
            this.uciId = UCI;
        }

        public override void CallServicesProvided()
        {
            GetJobOfferLetter();
            GetEnglishProficiencyResults();
            GetLMIAResults();
        }

        public void GetJobOfferLetter()
        {
            ServicesProvided += "... Job Offer Letter Provided ...\n";
        }

        public void GetEnglishProficiencyResults()
        {
            ServicesProvided += "... English Proficiency Results Provided ...\n";
        }

        public void GetLMIAResults()
        {
            ServicesProvided += "... LMIA Results Provided ...\n";
        }

        public override int getUCIId()
        {
            return this.uciId;
        }
    }
}
