using CommanderGQL.Data;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL;

public class CommandRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<IReadOnlyList<Command>> GetCommandsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context
            .Commands
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
