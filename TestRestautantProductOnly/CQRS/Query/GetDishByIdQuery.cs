using MediatR;
using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.CQRS.Query
{
    public record GetDishByIdQuery(int Id) : IRequest<Dish>;
}
    