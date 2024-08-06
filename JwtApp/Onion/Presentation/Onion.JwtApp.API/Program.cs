using Microsoft.AspNetCore.Authentication.JwtBearer;
using Onion.JwtApp.Application;
using Onion.JwtApp.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
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

#region ServiceRegistiration
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
#endregion

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
