var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var sql = builder.AddSqlServer("sq").AddDatabase("mssql");

var postgresdb = builder.AddPostgresContainer("pg")
    .AddDatabase("postgresdb");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithReference(postgresdb)
    .WithReference(sql);

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
