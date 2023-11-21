using Lib.DataAccess;
using Lib.Models;
using Lib.Queries;
using MediatR;

namespace Lib.Handlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    private readonly IMediator _mediator;

    public GetPersonByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPersonListQuery());
        var output = result.FirstOrDefault(x => x.Id == request.Id);

        if (output != null)
            return output;

        throw new Exception($"Person with id {request.Id} not found.");
    }
}