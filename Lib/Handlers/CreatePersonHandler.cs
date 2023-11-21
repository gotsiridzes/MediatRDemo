using Lib.Commands;
using Lib.DataAccess;
using Lib.Models;
using MediatR;

namespace Lib.Handlers;

public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonModel>
{
    private readonly IDataAccess _data;

    public CreatePersonHandler(IDataAccess data)
    {
        _data = data;
    }

    public Task<PersonModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _data.CreatePerson(request.FirstName, request.LastName);
        return Task.FromResult(person);
    }
}