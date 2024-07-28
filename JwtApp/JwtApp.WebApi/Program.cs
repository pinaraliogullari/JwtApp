using JwtApp.WebApi.Core.Application.Interfaces;
using JwtApp.WebApi.Persistence.Context;
using JwtApp.WebApi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<JwtAppContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
