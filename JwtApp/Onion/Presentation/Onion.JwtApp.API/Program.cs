using Onion.JwtApp.Application;
using Onion.JwtApp.Persistence;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
