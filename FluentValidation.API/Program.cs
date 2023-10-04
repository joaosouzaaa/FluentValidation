using FluentValidation.API.Constants.CorsConstants;
using FluentValidation.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjectionHandler();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(PoliciesConstants.DefaultCorsPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program{ }
