using MediatR;
using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.CQRS.Query
{
    public record GetAllDishesQuery : IRequest<IEnumerable<Dish>>;
}
