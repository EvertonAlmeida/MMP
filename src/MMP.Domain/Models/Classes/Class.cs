using System;

namespace MMP.Domain.Models.Classes
{
    public class Class: Entity
    {

        public Class() {}

        public Class(
            string title, string description, DateTime startDate, 
            DateTime endDate, bool free, decimal value, string companyName, 
            Guid classTypeId,  Venue venue)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Free = free;
            Value = value;
            CompanyName = companyName;
            ClassTypeId = classTypeId;
            Venue = venue;
        }

        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Free { get; set; }
        public decimal Value { get; set; }
        public string CompanyName { get; set; }
        public Guid ClassTypeId { get; set; }
        public Guid VenueId { get; set; }

         /* EF Relations */
        public virtual ClassType ClassType { get; set; }
        public virtual Venue Venue { get; set; }
    }
}