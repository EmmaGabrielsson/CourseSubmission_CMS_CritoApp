using System.ComponentModel.DataAnnotations;

namespace Crito.Models.Entities;

public class SubscriberEntity
{
    [Key]
    public string Email { get; set; } = null!;
}
