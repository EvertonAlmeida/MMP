using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MMP.Application.ViewModels
{
    public class VenueViewModel
    {
        [Key]
        public Guid Id { get; init; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; init; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedAt { get; init; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} need to have between {2} and {1} caracters", MinimumLength = 2)]
        public string Name { get; set; }

        public string Address { get; set; }

[       Display(Name = "Is free?")]
        public bool Online { get; set; }
        public string Url { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(15, ErrorMessage = "The field {0} need to have between {2} and {1} caracters", MinimumLength = 2)]
        public string ContactNumber { get; set; }

        public IEnumerable<ClassViewModel> Classes { get; set; }
    }
}