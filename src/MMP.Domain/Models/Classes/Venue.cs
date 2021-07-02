using System;
using System.Collections.Generic;

namespace MMP.Domain.Models.Classes
{
    public class Venue: Entity
    {

        public Venue() {}
        
        public Venue(
            Guid venueId, string name, string address, bool online, 
            string url, string contactNumber
            )
        {
            VenueId = venueId;
            Name = name;
            Address = address;
            Online = online;
            Url = url;
            ContactNumber = contactNumber;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public bool Online { get; set; }
        public string Url { get; set; }
        public string ContactNumber { get; set; }

        /* EF Relations */
        public IEnumerable<Class> Classes { get; set; }
        public Guid VenueId { get; }
    }
}