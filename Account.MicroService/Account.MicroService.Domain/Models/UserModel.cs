namespace Account.MicroService.Domain.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required List<string> Roles { get; set; }
}