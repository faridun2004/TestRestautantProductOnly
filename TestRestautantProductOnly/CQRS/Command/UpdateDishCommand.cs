using MediatR;
using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.CQRS.Command
{
    public record UpdateDishCommand(int Id, string Name, string Description, string ImageUrl, decimal Price) : IRequest;
}
