using System.ComponentModel.DataAnnotations;

namespace api.DTOs;

public class RegisterDTO
{

    [Required]
    public string Username { get; set; }
    [Required]
    [StringLength(8, MinimumLength = 3)]
    public string Password { get; set; }

}
