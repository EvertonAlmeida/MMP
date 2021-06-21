using System;

namespace MMP.Application.ViewModels
{
    public record ClassTypeViewModel
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Title { get; init; }
    }
}