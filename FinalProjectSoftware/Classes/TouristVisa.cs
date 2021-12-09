using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public class TouristVisa : Visa
    {
        private static int UCI = 0;
        private int uciId = 0;

        public int UciId { get => uciId; }

        public TouristVisa()
        {
            UCI++;
            this.uciId = UCI;
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

        public override int getUCIId()
        {
            return this.uciId;
        }
    }
}
