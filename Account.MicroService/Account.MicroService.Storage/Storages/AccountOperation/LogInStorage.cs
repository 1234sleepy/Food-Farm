using Account.MicroService.Domain.Models;
using Account.MicroService.Domain.UseCases.AccountOperation.LogIn;
using Account.MicroService.Storage.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Account.MicroService.Storage.Storages.AccountOperation;

public class LogInStorage(UserManager<User> userManager, DataContext dataContext) : ILogInStorage
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly DataContext _dataContext = dataContext;

    public async Task<UserModel> GetUserByUsername(string username, CancellationToken cancellationToken)
    {
        var model = await _userManager.FindByNameAsync(username);

        if (model == null) 
        {
            throw new Exception("User is not found");
        }

        model.UserRole = await _dataContext.UserRoles.Include(x => x.Role).Where(x => x.UserId == model.Id).ToListAsync();

        return new UserModel { Id = model!.Id, Email = model.Email!, Roles = model.UserRole!.Select(x => x.Role!.Name).ToList()!, Username = model.UserName!};
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
