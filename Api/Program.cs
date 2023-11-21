using Lib.DataAccess;
using Lib.Queries;
using MediatR;

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
    return res;
})
.WithName("GetPeople")
.WithOpenApi();

app.Run();
