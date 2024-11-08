using System.ComponentModel.DataAnnotations;

namespace M223PunchclockDotnet.Model;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public required string Username { get; set; }
    
    public required string Email { get; set; }
    
    public required string Password { get; set; }
}