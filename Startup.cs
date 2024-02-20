using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQL.Platforms;
using Microsoft.EntityFrameworkCore;
using CommanderGQL.GraphQL.Commands;

namespace CommanderGQL;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContextPool<AppDbContext>((options) => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services
            .AddScoped<PlatformRepository>()
            .AddScoped<CommandRepository>();

        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddType<PlatformType>()
            .AddType<CommandType>()
            .RegisterService<PlatformRepository>(ServiceKind.Resolver)
            .RegisterService<CommandRepository>(ServiceKind.Resolver);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });

        app.UseGraphQLVoyager(options: new VoyagerOptions()
        {
            GraphQLEndPoint = "/graphql",
        });
    }
}