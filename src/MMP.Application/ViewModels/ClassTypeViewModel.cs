using System;
using System.ComponentModel.DataAnnotations;

namespace MMP.Application.ViewModels
{
    public class ClassTypeViewModel
    {
        [Key]
        public Guid Id { get; init; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; init; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedAt { get; init; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} need to have between {2} and {1} caracters", MinimumLength = 2)]
        public string Title { get; init; }
    }
}