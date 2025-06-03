using System.ComponentModel.DataAnnotations;

namespace MessageBroker.AuthService.Contracts;

public record LoginContract(
    [Required] string Email,
    [Required] string Password);