using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TacheApp.Application.Commands.ClotureTache;
using TacheApp.Application.Commands.CreateTache;
using TacheApp.Application.Commands.DeleteTache;
using TacheApp.Application.Commands.UpdateTache;
using TacheApp.Application.Queries.GetAllTaches;
using TacheApp.Application.Queries.GetTacheById;
using TacheApp.Domain.Interfaces;
using TacheApp.Infrastructure.Data;
using TacheApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
builder.Services.AddScoped<ITacheRepository, TacheRepository>();
builder.Services.AddScoped<GetAllTachesQueryHandler>();
builder.Services.AddScoped<GetTacheByIdQueryHandler>();
builder.Services.AddScoped<CreateTacheCommandHandler>();
builder.Services.AddScoped<UpdateTacheCommandHandler>();
builder.Services.AddScoped<DeleteTacheCommandHandler>();
builder.Services.AddScoped<ClotureTacheCommandHandler>();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
