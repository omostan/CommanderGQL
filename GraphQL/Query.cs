using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;

public class Query
{
    public Task<IReadOnlyList<Command>> GetCommandsAsync(
        CommandRepository commandRepository,
        CancellationToken cancellationToken)
    {
        return commandRepository.GetCommandsAsync(cancellationToken);
    }

    public Task<IReadOnlyList<Platform>> GetPlatformsAsync(
        PlatformRepository platformRepository,
        CancellationToken cancellationToken)
    {
        return platformRepository.GetPlatformsAsync(cancellationToken);
    }
}
