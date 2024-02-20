using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Platforms;

public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any software or service that has a command line interface.");

        descriptor
            .Field(p => p.LicenseKey).Ignore();

        descriptor
            .Field(p => p.Commands)
            .ResolveWith<Resolvers>(p => Resolvers.GetCommands(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("Represents the list of available commands for this platform.");
    }

    private class Resolvers
    {
        public static IQueryable<Command> GetCommands(Platform platform, AppDbContext context)
        {
            return context.Commands.Where(p => p.PlatformId == platform.Id);
        }
    }
}