using M223PunchclockDotnet.Model;
using Microsoft.EntityFrameworkCore;

namespace M223PunchclockDotnet;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        var category = new Category
        {
            Title = "Category 1"
        };
        var tag = new Tag
        {
            Title = "Tag 1"
        };

        context
            .Drop()
            .AddTags(tag)
            .AddCategories(category)
            .AddEntries(tag, category)
            .SaveChanges();
    }

    private static DatabaseContext Drop(this DatabaseContext context)
    {
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Entry");
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Tag");
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Category");
        return context;
    }

    private static DatabaseContext AddTags(this DatabaseContext context, params Tag[] tags)
    {
        context.Tags.AddRange(tags);
        context.Tags.AddRange(new Tag
            {
                Title = "Tag 2"
            }, new Tag
            {
                Title = "Tag 3"
            });
        return context;
    }
    
    private static DatabaseContext AddCategories(this DatabaseContext context, params Category[] categories)
    {
        context.Categories.AddRange(categories);
        context.Categories.AddRange(new Category
        {
            Title = "Category 2"
        }, new Category
        {
            Title = "Category 3"
        });
        return context;
    }
    
    private static DatabaseContext AddEntries(this DatabaseContext context, Tag tag, Category category)
    {
        context.Entries.AddRange(
            new Entry
            {
                CheckIn = new DateTime(2024, 11, 5, 11, 00, 00, DateTimeKind.Utc),
                CheckOut = new DateTime(2024, 11, 5, 14, 00, 00, DateTimeKind.Utc),
                Category = category
            },
            new Entry
            {
                CheckIn = new DateTime(2024, 5, 11, 9, 30, 00, DateTimeKind.Utc),
                CheckOut = new DateTime(2024, 5, 11, 12, 45, 00, DateTimeKind.Utc),
                Tags = [tag]
            },
            new Entry
            {
                CheckIn = new DateTime(2023, 11, 5, 11, 00, 00, DateTimeKind.Utc),
                CheckOut = new DateTime(2023, 11, 6, 14, 00, 00, DateTimeKind.Utc)
            });
        return context;
    }
}