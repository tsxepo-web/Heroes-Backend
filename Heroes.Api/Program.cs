using MongoDB.Driver;
using Heroes.Infrastructure.Models;
using Heroes.Infrastructure;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotEnv.Load();
var mongoConnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
var mongoDatabaseName = Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME");
var mongoCollectionName = Environment.GetEnvironmentVariable("MONGO_COLLECTION_NAME");

var mongoClient = new MongoClient("mongodb://tsxepo:UrppOt8Gwj5AWfZ9d3skk3bRlUkuLCbgLA2PZxzGgrK6PVnJZV0rLQnIdWV0R3upCNuacc7cx9aoACDbSTQzqQ==@tsxepo.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@tsxepo@");
var mongoDatabase = mongoClient.GetDatabase("Heroes");
var mongoCollection = mongoDatabase.GetCollection<Battle>("Battle");
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
