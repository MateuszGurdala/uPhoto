using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;
using uPhoto.Database.Contracts;

namespace uPhoto.API.Controllers;

public class UserAccountController(IUserAccountDbContext userAccountDbContext)
{
    [HttpGet("account-types")]
    public async Task<IEnumerable<AccountType>> GetAccountTypes(CancellationToken cancellationToken)
    {
        return await userAccountDbContext.AccountType.ToListAsync(cancellationToken);
    }

    [HttpGet("user-accounts")]
    public async Task<IEnumerable<UserAccount>> GetUserAccountsTypes(CancellationToken cancellationToken)
    {
        return await userAccountDbContext.UserAccount.ToListAsync(cancellationToken);
    }
}