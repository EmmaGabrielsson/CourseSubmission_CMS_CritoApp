using Crito.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class ContactForm
{
    [Required(ErrorMessage = "Your name is required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Your email is required")]
    [EmailAddress]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to enter a valid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "A message is required")]
    public string Message { get; set; } = null!;

    public string RedirectUrl { get; set; } = "/";



    public static implicit operator ContactFormEntity(ContactForm model)
    {
        return new ContactFormEntity
        {
            Name = model.Name,
            Email = model.Email,
            Message = model.Message
        };
    }
}
