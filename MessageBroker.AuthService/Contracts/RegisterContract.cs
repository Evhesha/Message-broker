using System.ComponentModel.DataAnnotations;

namespace MessageBroker.AuthService.Contracts;

public record RegisterContract(
    [Required] string Name,
    [Required] string Email,
    [Required] string Password
    );