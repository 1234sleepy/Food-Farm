namespace Gateway.Domain.Models;

public class UserModel
{
    public string? Token { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public List<string>? Roles { get; set; }
}
