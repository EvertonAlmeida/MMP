using System;

namespace MMP.Application.ViewModels
{
    public class ClassViewModel
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Free { get; set; }
        public decimal Value { get; set; }
        public string CompanyName { get; set; }
        public Guid ClassTypeId { get; set; }
        public Guid VenueId { get; set; }

        public virtual ClassTypeViewModel ClassType { get; set; }
        public virtual VenueViewModel Venue { get; set; }
    }
}