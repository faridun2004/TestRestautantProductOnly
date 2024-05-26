using MediatR;
using TestRestautantProductOnly.CQRS.Query;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CQRS.Handler
{
    public class GetDishByIdHandler : IRequestHandler<GetDishByIdQuery, Dish>
    {
        private readonly IDishRepository _repository;

        public GetDishByIdHandler(IDishRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dish> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
