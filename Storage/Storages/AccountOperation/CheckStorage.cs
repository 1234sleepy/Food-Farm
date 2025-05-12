using Domain.UseCases.AccountOperations.Command.Check;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.AccountOperation;

public class CheckStorage(DataContext dataContext) : ICheckStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<string> Check(Guid UserId, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users.FirstAsync(x => x.Id == UserId, cancellationToken);
        return user.UserName!;
    }

}
