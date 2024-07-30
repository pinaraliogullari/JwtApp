using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Persistence.Context;
using JwtApp.Back.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//CONTEXT
builder.Services.AddDbContext<JwtAppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true, 
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
    };
});

//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("https://localhost:7201", "http://localhost:5104").AllowAnyHeader().AllowAnyMethod();
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
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
