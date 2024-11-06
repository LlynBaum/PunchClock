using FluentAssertions;
using M223PunchclockDotnet.Model;
using M223PunchclockDotnet.Service;
using Moq;
using Moq.EntityFrameworkCore;

namespace TestProject1;

[TestFixture]
public class TagServiceTest
{
    [Test]
    public async Task GetAllAsync_ReturnsAllEntries()
    {
        // Arrange
        var data = new List<Tag>
        {
            new Tag
            {
                Id = 1,
                Title = "Test"
            },
            new Tag
            {
                Id = 2,
                Title = "Test2"
            }
        };

        var context = SetUpMock(data);
        var testee = new TagService(context);

        // Act
        var result = await testee.GetAllAsync(CancellationToken.None);
        
        // Assert
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(data);
    }

    private static DatabaseContext SetUpMock(List<Tag> data)
    {
        var mock = new Mock<DatabaseContext>();
        mock.Setup(c => c.Tags).ReturnsDbSet(data);
        return mock.Object;
    }
}