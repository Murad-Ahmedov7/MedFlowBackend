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
builder.Services.AddCorsServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<DatabaseSeeder>();

//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.MapType<TimeOnly>(() => new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Type = "string",
        Format = "time",
        Example = new Microsoft.OpenApi.Any.OpenApiString("09:00")
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())    
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
await app.SeedDatabaseAsnyc();

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseExceptionHandling();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
