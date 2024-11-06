using System.ComponentModel.DataAnnotations;

namespace M223PunchclockDotnet.Dto;

public class EntryDto
{
    [Required]
    public DateTime CheckIn { get; set; }
        
    [Required]
    public DateTime CheckOut { get; set; }

    public required int UserId { get; set; }
}