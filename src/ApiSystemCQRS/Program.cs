using ApiSystemCQRS.Middleware;
using FluentValidation.AspNetCore;
using MediatR;
using ApiSystemCQRSInfrastructure.Services;
using ApiSystemCQRSAplication.GyfSystem.Queries;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(GetAllSystemsQuery).Assembly, typeof(Program).Assembly);
builder.Services.AddScoped<IGyfSystems, GyfSystemsRepository>();
builder.Services.AddControllers();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("corsApp", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsApp");
app.UseMiddleware<HandleErrorMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
