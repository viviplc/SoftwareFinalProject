using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public class StudentVisa : Visa
    {
        private static int UCI = 0;
        private int uciId = 0;

        public int UciId { get => uciId;}

        public StudentVisa()
        {
            UCI++;
            this.uciId = UCI;
        }

        public override void CallServicesProvided()
        {
            GetCollegeOfferLetter();
            GetCollegeEnrollmentLetter();
            GetProofOfTuitionPayment();
            GetPreviousEducationTranscript();
        }


        public void GetCollegeOfferLetter()
        {
            ServicesProvided += "... College Offer Letter Provided ...\n";
        }

        public void GetCollegeEnrollmentLetter()
        {
            ServicesProvided += "... College Enrollment Letter Provided ...\n";
        }

        public void GetProofOfTuitionPayment()
        {
            ServicesProvided += "... Proof of Tuition Payment Provided ...\n";
        }

        public void GetPreviousEducationTranscript()
        {
            ServicesProvided += "... Previous Education Transcript Provided ...\n";
        }

        public override int getUCIId()
        {
            return this.uciId;
        }
    }
}
