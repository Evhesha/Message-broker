using System.ComponentModel.DataAnnotations;

namespace MessageBroker.AuthService.Contracts;

public record RegisterContract(
    [Required] string Name,
    [Required] [EmailAddress] string Email,
    [Required] string Password
    );