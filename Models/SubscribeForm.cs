using Crito.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class SubscribeForm
{

    [Required(ErrorMessage = "Your email is required")]
    [EmailAddress]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to enter a valid email")]
    public string Email { get; set; } = null!;


    public static implicit operator SubscriberEntity(SubscribeForm model)
    {
        return new SubscriberEntity
        {
            Email = model.Email
        };
    }
}
