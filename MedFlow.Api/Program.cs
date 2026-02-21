using Application;
using Application.Infrastructure;
using DataAccess;
using MedFlow.Api.Infrastructures;
using MedFlow.Api.Infrastructures.Extensions;
using MedFlow.Api.Infrastructures.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DataBaseContext");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlServerServices(connectionString!);
builder.Services.AddApplicationServices();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandling();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
