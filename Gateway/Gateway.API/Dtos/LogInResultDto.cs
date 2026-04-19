namespace Gateway.API.Dtos;

public class LoginResultDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public List<string> Roles { get; set; }
}

