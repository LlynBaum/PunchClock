using M223PunchclockDotnet.Model;
using Microsoft.EntityFrameworkCore;

namespace M223PunchclockDotnet.Service;

public class TagService(DatabaseContext context)
{
    public async Task<List<Tag>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Tags.ToListAsync(cancellationToken);
    }

    public async Task<Tag> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var tag = await context.Tags.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (tag is null) throw new ArgumentException($"Can not find Tag with id {id}");
        return tag;
    }

    public async Task<Tag> CreateAsync(Tag tag, CancellationToken cancellationToken)
    {
        var newTag = await context.Tags.AddAsync(tag, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return newTag.Entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var tag = await context.Tags.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (tag is null) throw new ArgumentException($"Can not find Tag with id {id}");
    }
}