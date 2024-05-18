using CatchUpPlatform.API.News.Application.Internal.CommandServices;
using CatchUpPlatform.API.News.Application.Internal.QueryServices;
using CatchUpPlatform.API.News.Domain.Repositories;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.News.Infrastructure.Persistence.EFC.Repositories;
using CatchUpPlatform.API.Shared.Domain.Repositories;
using CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Level
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
        if (builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration
builder.Services.AddScoped<IFavoriteSourceRepository, FavoriteSourceRepository>();
builder.Services.AddScoped<IFavoriteSourceCommandService, FavoriteSourceCommandService>();
builder.Services.AddScoped<IFavoriteSourceQueryService, FavoriteSourceQueryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();