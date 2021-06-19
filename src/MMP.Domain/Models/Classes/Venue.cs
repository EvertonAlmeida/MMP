using System.Collections.Generic;

namespace MMP.Domain.Models.Classes
{
    public class Venue: Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Online { get; set; }
        public string Url { get; set; }
        public string ContactNumber { get; set; }

        /* EF Relations */
        public IEnumerable<Class> Classes { get; set; }
    }
}