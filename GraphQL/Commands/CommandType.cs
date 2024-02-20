using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Commands;

public class CommandType : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command on the command line.");

        descriptor
            .Field(c => c.Platform)
            .ResolveWith<Resolvers>(c => Resolvers.GetPlatform(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("Represents the platform to which the command belongs.");
    }

    private class Resolvers
    {
        public static Platform GetPlatform(Command command, AppDbContext context)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId)!;
        }
    }
}