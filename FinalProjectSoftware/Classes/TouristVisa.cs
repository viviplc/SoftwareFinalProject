using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    class TouristVisa : Visa
    {
        public TouristVisa()
        {
        }

        public override void CallServicesProvided()
        {
            GetTravelItinerary();
            GetInvitationLetter();
        }

        
        public void GetTravelItinerary()
        {
            ServicesProvided += "... Travel Itinerary Provided ...\n";
        }

        public void GetInvitationLetter()
        {
            ServicesProvided += "... Invitation Letter Provided ...\n";
        }
    }
}
