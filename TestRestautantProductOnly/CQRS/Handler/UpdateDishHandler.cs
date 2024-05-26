using MediatR;
using TestRestautantProductOnly.CQRS.Command;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CQRS.Handler
{
    //public class UpdateDishHandler : IRequestHandler<UpdateDishCommand>
    //{
    //    private readonly IDishRepository _repository;

    //    public UpdateDishHandler(IDishRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<Unit> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
    //    {
    //        var dish = new Dish
    //        {
    //            Id = request.Id,
    //            Name = request.Name,
    //            Description = request.Description,
    //            ImageUrl = request.ImageUrl,
    //            Price = request.Price
    //        };

    //        await _repository.UpdateAsync(dish);
    //        return Unit.Value;
    //    }
    //}
}
