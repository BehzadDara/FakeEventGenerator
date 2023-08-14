using Microsoft.EntityFrameworkCore;
using FakeEventGenerator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<FakeEventGeneratorDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FakeEventGeneratorConnection")),
    ServiceLifetime.Singleton);
builder.Services.AddSingleton<DbContext>(provider => provider.GetService<FakeEventGeneratorDBContext>()!);

builder.Services.AddSingleton<UnitOfWork>();

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
