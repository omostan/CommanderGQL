using CommanderGQL.Data;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL;

public class PlatformRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<IReadOnlyList<Platform>> GetPlatformsAsync(CancellationToken cancellationToken = default)
    {
        return await _context
            .Platforms
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
