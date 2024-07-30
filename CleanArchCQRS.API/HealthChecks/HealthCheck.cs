using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CleanArchCQRS.API.HealthChecks
{
    public static class HealthCheck
    {

        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddNpgSql(configuration["ConnectionStrings:Default"]!, 
                healthQuery: "SELECT 1", 
                name: "PostgreSQL Check", 
                failureStatus: HealthStatus.Unhealthy, 
                tags: new[] { "sql", "postgres", "Database" })
                .AddCheck<RemoteHealthCheck>("Remote endpoints Health Check", failureStatus: HealthStatus.Unhealthy)
                .AddCheck<MemoryHealthCheck>($"Feedback Service Memory Check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback Service" })
                .AddUrlGroup(new Uri("https://localhost:7290/swagger/index.html"), name: "base URL", failureStatus: HealthStatus.Unhealthy);


            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10);  
                opt.MaximumHistoryEntriesPerEndpoint(60);  
                opt.SetApiMaxActiveRequests(1);  
                opt.AddHealthCheckEndpoint("feedback api", "/api/health");   

            })
                .AddInMemoryStorage();
        }
    }
}
