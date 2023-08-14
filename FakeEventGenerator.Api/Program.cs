using Microsoft.EntityFrameworkCore;
using FakeEventGenerator.Domain;
using FakeEventGenerator.Domain.IRepositories;
using FakeEventGenerator.Infrastructure;
using FakeEventGenerator.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<FakeEventGeneratorDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FakeEventGeneratorConnection")),
    ServiceLifetime.Singleton);
builder.Services.AddSingleton<DbContext>(provider => provider.GetService<FakeEventGeneratorDBContext>()!);

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IEnvironmentRepository), typeof(EnvironmentRepository));
builder.Services.AddScoped(typeof(IPartOfHouseRepository), typeof(PartOfHouseRepository));

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall", policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("allowall");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
