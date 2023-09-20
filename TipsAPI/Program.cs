using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TipsAPI.DataAccess;
using TipsAPI.DataAccess.Entities;

const string API_NAME = "Tips API";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("TipsDb"))
    .UseSnakeCaseNamingConvention());

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(new Uri(builder.Configuration["MessageBroker:Host"]!), h =>
        {
            h.Username(builder.Configuration["MessageBroker:UserName"]);
            h.Password(builder.Configuration["MessageBroker:Password"]);
        });

        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = API_NAME, Version = "v1" }));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.EnsureCreated();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", API_NAME);
    });
}

app.UseHttpsRedirection();

app.MapGet("/tips", async (AppDbContext dbContext) =>
{
    var tips = await dbContext.Tips.ToListAsync();
    return Results.Ok(tips);
})
.WithName("get-all")
.WithOpenApi();

app.MapGet("/tips/{id}", async (AppDbContext dbContext, int id) =>
{
    var tip = await dbContext.Tips.FindAsync(id);
    return Results.Ok(tip);
})
.WithName("get-by-id")
.WithOpenApi();

app.MapPost("/tips", async (AppDbContext dbContext, Tip tip) =>
{
    await dbContext.Tips.AddAsync(tip);
    await dbContext.SaveChangesAsync();
    
    return Results.Created("/tips", tip);
})
.WithName("create")
.WithOpenApi();

app.MapDelete("/tips/{id}", async (AppDbContext dbContext, int id) =>
{
    await dbContext.Tips.Where(t => t.Id == id).ExecuteDeleteAsync();
    await dbContext.SaveChangesAsync();

    return Results.NoContent();
})
.WithName("delete")
.WithOpenApi();

app.Run();