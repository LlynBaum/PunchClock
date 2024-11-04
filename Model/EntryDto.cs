using System.ComponentModel.DataAnnotations;

namespace M223PunchclockDotnet.Model;

public class EntryDto
{
    [Required]
    public DateTime CheckIn { get; set; }
        
    [Required]
    public DateTime CheckOut { get; set; }
}