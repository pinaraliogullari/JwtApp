using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Persistence.Context;
using JwtApp.Back.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//CONTEXT
builder.Services.AddDbContext<JwtAppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});
});

//SERVÝSLER,MAPPERLER VS
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//veya
//builder.Services.AddAutoMapper(typeof(ProductMapping));
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


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
