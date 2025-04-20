using System.Data;
using Domain.UseCases.AccountOperations.Command.CreateAccount;
using Microsoft.AspNetCore.Identity;
using Storage.Entities;

namespace Storage.Storages.AccountOperation;

public class CreateAcountStorage(DataContext dataContext, UserManager<User> userManager) : ICreateAccountStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly UserManager<User> _userManager = userManager;

    public async Task CreateAccount(string userName, string password, string email, string role, CancellationToken cancellationToken)
    {


        User dbUser = new User()
        {
            UserName = userName,
            Email = email,
        };
        using (var transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                IdentityResult createUserResult = await _userManager.CreateAsync(dbUser, password);
                if (!createUserResult.Succeeded)
                {
                    throw new Exception("User can not be created");
                }
                IdentityResult addRoleResult = await _userManager.AddToRoleAsync(dbUser,role);

                if (!addRoleResult.Succeeded)
                {
                    throw new Exception("Role can not be assignment to User");
                }

                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
