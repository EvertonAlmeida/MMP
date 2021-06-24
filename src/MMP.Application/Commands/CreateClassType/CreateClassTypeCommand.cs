using MediatR;
using MMP.Application.ViewModels;

namespace MMP.Application.Commands.CreateClassType
{
    public record CreateClassTypeCommand(string Title) : IRequest<bool>;  
}