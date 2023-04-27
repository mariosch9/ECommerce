using NewStarterTask.BusinessLogic.Extensions;
using NewStarterTask.WebApi.Extensions;
using NewStaterTask.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwaggerGen();
builder.Services.AddServices();

var app = builder.Build();

app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
