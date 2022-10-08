using Microsoft.EntityFrameworkCore;
using shopsruscase.api;
using shopsruscase.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(opt => { opt.SetSqlServerOptions(builder.Configuration); });
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddInfrastructures(builder.Configuration);
IocConfiguration.RegisterAllDependencies(builder.Services, builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    if (context != null)
    {
        context.Database.EnsureCreated();
        await context.Database.MigrateAsync();
        await DataSeeding.Seed(context);
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
