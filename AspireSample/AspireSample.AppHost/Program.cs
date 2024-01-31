var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var database = builder.AddPostgres("database");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithReference(database);

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
