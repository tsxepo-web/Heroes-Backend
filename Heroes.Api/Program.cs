using MongoDB.Driver;
using Heroes.Infrastructure.Models;
using Heroes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoConnectionString = builder.Configuration["Heroes:ConnectionString"];
var mongoDatabaseName = builder.Configuration["Heroes:DatabaseName"];
var mongoCollectionName = builder.Configuration["Heroes:CollectionName"];

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var mongoCollection = mongoDatabase.GetCollection<Battle>(mongoCollectionName);
builder.Services.AddSingleton(mongoCollection);

builder.Services.AddScoped<IBattleRepository, BattleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
