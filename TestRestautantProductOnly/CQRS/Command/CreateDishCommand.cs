using MediatR;
using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.CQRS.Command
{
    public record CreateDishCommand(string Name, string Description, string ImageUrl, decimal Price) : IRequest<int>;
}
