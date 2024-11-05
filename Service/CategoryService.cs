using M223PunchclockDotnet.Model;
using Microsoft.EntityFrameworkCore;

namespace M223PunchclockDotnet.Service;

public class CategoryService(DatabaseContext context)
{
    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var category = await context.Categories.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (category is null) throw new ArgumentException($"Can not find Tag with id {id}");
        return category;
    }

    public async Task<Category> CreateAsync(Category category, CancellationToken cancellationToken)
    {
        var newCategory = await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return newCategory.Entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var category = await context.Categories.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (category is null) throw new ArgumentException($"Can not find Tag with id {id}");
    }
}