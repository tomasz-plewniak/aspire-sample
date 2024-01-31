var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgresdb = builder.AddPostgresContainer("postgres")
    .AddDatabase("postgresdb");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithReference(postgresdb)

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
