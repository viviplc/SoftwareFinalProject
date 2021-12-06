using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    class WorkVisa : Visa
    {
        public WorkVisa()
        {
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
    }
}
