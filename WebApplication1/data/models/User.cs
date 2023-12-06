using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.data.models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public String Email { get; set; }
    
    [Required]
    public String Password { get; set; }

    [Required]
    public DateTime CreationDate { get; set; }

    public DateTime LastUpdate { get; set; }
}