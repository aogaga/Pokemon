using System.Diagnostics;
using PokeMonAPi.Repositories;
using PokeMonAPi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<RedisService>(sp =>
{
    var configuration = builder.Configuration.GetValue<string>("Redis:Configuration");
    if (string.IsNullOrEmpty(configuration))
    {
        throw new InvalidOperationException("Redis configuration cannot be null or empty.");
    }
    return new RedisService(configuration);
});

// Register the distributed cache (using Redis)
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("Redis:Configuration");
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>(); 
builder.Services.AddScoped<PokemonService>();

builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
