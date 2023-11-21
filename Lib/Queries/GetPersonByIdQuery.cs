using Lib.Models;
using MediatR;

namespace Lib.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;