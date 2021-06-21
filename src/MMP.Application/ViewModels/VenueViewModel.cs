using System;
using System.Collections.Generic;

namespace MMP.Application.ViewModels
{
    public class VenueViewModel
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Online { get; set; }
        public string Url { get; set; }
        public string ContactNumber { get; set; }
        public IEnumerable<ClassViewModel> Classes { get; set; }
    }
}