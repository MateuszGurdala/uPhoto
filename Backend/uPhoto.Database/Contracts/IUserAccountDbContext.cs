using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;

namespace uPhoto.Database.Contracts;

public interface IUserAccountDbContext
{
    public DbSet<UserAccount> UserAccount { get; set; }
    public DbSet<AccountType> AccountType { get; set; }
}