using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace TestRestautantProductOnly.CQRS.Command
{
    public record DeleteDishCommand(int Id) : IRequest;
}
