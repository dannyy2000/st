using System.ComponentModel.DataAnnotations;

namespace WebApplication1.data.dto.request;

public class CreateUserRequest
{
    [Required(ErrorMessage = "field name cannot be null")]
    [StringLength(maximumLength: 100, ErrorMessage = "field name cannot be empty")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "field Password cannot be null")]
    public String Password { get; set; }
    
    [Required(ErrorMessage = "field Email cannot be null")]
    public String Email { get; set; }
}