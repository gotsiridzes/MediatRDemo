using Lib.Models;
using MediatR;

namespace Lib.Queries;

public record GetPersonListQuery : IRequest<List<PersonModel>>;