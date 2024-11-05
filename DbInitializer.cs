using M223PunchclockDotnet.Model;

namespace M223PunchclockDotnet;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        var category = new Category
        {
            Title = "Category 1"
        };
        context.Categories.AddRange(category,
            new Category
            {
                Title = "Category 2"
            }, new Category
            {
                Title = "Category 3"
            });

        var tag = new Tag
        {
            Title = "Tag 1"
        };
        context.Tags.AddRange(tag,
            new Tag
            {
                Title = "Tag 2"
            }, new Tag
            {
                Title = "Tag 3"
            });

        context.Entries.AddRange(
            new Entry
            {
                CheckIn = new DateTime(2024, 11, 5, 11, 00, 00),
                CheckOut = new DateTime(2024, 11, 5, 14, 00, 00),
                Category = category
            },
            new Entry
            {
                CheckIn = new DateTime(2024, 5, 11, 9, 30, 00),
                CheckOut = new DateTime(2024, 5, 11, 12, 45, 00),
                Tags = [tag]
            },
            new Entry
            {
                CheckIn = new DateTime(2023, 11, 5, 11, 00, 00),
                CheckOut = new DateTime(2023, 11, 6, 14, 00, 00)
            });

        context.SaveChanges();
    }
}