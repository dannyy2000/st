using System.ComponentModel.DataAnnotations;

namespace WebApplication1.data.dto.request;


public class EmailNotificationRequest
{
    [Required(ErrorMessage = "This field cannot be null")]
    [RegularExpression(".*\\S.*", ErrorMessage = "This field cannot be blank")]
    public string Recipients { get; set; }

    public string Subject { get; } = "Welcome to Tracker";

    [Required(ErrorMessage = "This field cannot be null")]
    [RegularExpression(".*\\S.*", ErrorMessage = "This field cannot be blank")]
    public string Text { get; set; }
}

