using Lib.Commands;
using Lib.DataAccess;
using Lib.Models;
using Lib.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataAccess, DemoDataAccess>();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DemoDataAccess).Assembly));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/people", async (IMediator mediator) =>
    {
        var res = await mediator.Send(new GetPersonListQuery());
        return Results.Ok(res);
    })
    .WithName("GetPeople")
    .WithOpenApi();

app.MapGet("/people/{personId:int}", async (IMediator mediator, int personId) =>
    {
        try
        {
            var res = await mediator.Send(new GetPersonByIdQuery(personId));
            return Results.Ok(res);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.NotFound();
        }
    })
    .WithName("GetPersonById")
    .WithOpenApi();

app.MapPost("/people", async (IMediator mediator, [FromBody] PersonModel person) =>
    {
        var res = await mediator.Send(new CreatePersonCommand(person.FirstName, person.LastName));
        return Results.Ok(res);
    })
    .WithName("CreatePerson")
    .WithOpenApi();

app.Run();