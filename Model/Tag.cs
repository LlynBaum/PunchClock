using System.ComponentModel.DataAnnotations;

namespace M223PunchclockDotnet.Model;

public class Tag
{
    public int Id { get; set; }
    
    [Required]
    public required string Title { get; set; }
}