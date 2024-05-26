using MediatR;
using TestRestautantProductOnly.CQRS.Command;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.CQRS.Handler
{
    //public class DeleteDishHandler : IRequestHandler<DeleteDishCommand>
    //{
    //    private readonly IDishRepository _repository;

    //    public DeleteDishHandler(IDishRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<Unit> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    //    {
    //        await _repository.DeleteAsync(request.Id);
    //        return Unit.Value;
    //    }
    //}
}
