using Lib.Models;
using MediatR;

namespace Lib.Commands;

public record CreatePersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;