using MediatR;
using TestRestautantProductOnly.CQRS.Query;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CQRS.Handler
{
    public class GetAllDishesHandler : IRequestHandler<GetAllDishesQuery, IEnumerable<Dish>>
    {
        private readonly IDishRepository _repository;

        public GetAllDishesHandler(IDishRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Dish>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }

}
