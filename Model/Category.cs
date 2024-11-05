using System.ComponentModel.DataAnnotations;

namespace M223PunchclockDotnet.Model;

public class Category
{
    public int Id { get; set; }
    
    [Required]
    public required string Title { get; set; }
}