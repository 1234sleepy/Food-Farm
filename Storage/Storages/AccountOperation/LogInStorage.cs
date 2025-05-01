using Domain.UseCases.AccountOperations.Command.LogIn;
using Microsoft.AspNetCore.Identity;
using Storage.Entities;

namespace Storage.Storages.AccountOperation;

public class LogInStorage(UserManager<User> userManager) : ILogInStorage
{
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Guid> GetUserIdByUsername(string username, CancellationToken cancellationToken)
    {
        return (await _userManager.FindByNameAsync(username))!.Id;
    }

    public async Task LogIn(LogInCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(command.username);
        if (!await _userManager.CheckPasswordAsync(user!, command.password))
        {
            throw new Exception("Invalid password or username");
        }
    }


}
