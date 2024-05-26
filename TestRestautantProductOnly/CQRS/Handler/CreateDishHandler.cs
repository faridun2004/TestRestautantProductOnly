using MediatR;
using AutoMapper;
using TestRestautantProductOnly.CQRS.Command;
using TestRestautantProductOnly.Repository;
using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.CQRS.Handler
{
    public class CreateDishHandler : IRequestHandler<CreateDishCommand, int>
    {
        private readonly IDishRepository _repository;

        public CreateDishHandler(IDishRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var dish = new Dish
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price
            };

            await _repository.AddAsync(dish);
            return dish.Id;
        }
    }
}
