using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    class StudentVisa : Visa
    {
        public StudentVisa()
        {
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

    }
}
