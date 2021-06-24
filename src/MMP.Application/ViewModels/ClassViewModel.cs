using System;
using System.ComponentModel.DataAnnotations;

namespace MMP.Application.ViewModels
{
    public class ClassViewModel
    {
        [Key]
        public Guid Id { get; init; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; init; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedAt { get; init; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} need to have between {2} and {1} caracters", MinimumLength = 2)]
        public string Title { get;  set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(1000, ErrorMessage = "The field {0} need to have between {2} and {1} caracters", MinimumLength = 2)]
        public string Description { get;  set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is free?")]
        public bool Free { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid format currency")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} need to have between {2} and {1} caracters", MinimumLength = 2)]
        public string CompanyName { get; set; }
        public Guid ClassTypeId { get; set; }
        public Guid VenueId { get; set; }

        public virtual ClassTypeViewModel ClassType { get; set; }
        public virtual VenueViewModel Venue { get; set; }
    }
}