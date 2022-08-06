using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Contract;
using TaskManager.Infrustructure.DbContexts;
using TaskManager.Infrustructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IActivityContract, ActivityContract>();

builder.Services.AddDbContext<TaskManagerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TaskManagerDBConnectionString")));

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
