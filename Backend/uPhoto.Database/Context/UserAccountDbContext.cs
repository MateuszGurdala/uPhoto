using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;
using uPhoto.Database.Contracts;

namespace uPhoto.Database.Context;

public class UserAccountDbContext : DbContextBase, IUserAccountDbContext
{
    public virtual DbSet<UserAccount> UserAccount { get; set; }
    public virtual DbSet<AccountType> AccountType { get; set; }

    public UserAccountDbContext(DbContextOptions<DbContextBase> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnUserAccountModelCreating(modelBuilder);
        OnAccountTypeModelCreating(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void OnUserAccountModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccount>()
            .HasOne(e => e.AccountType)
            .WithMany(e => e.UserAccounts)
            .HasForeignKey(e => e.AccountTypeId)
            .IsRequired();

        modelBuilder.Entity<UserAccount>()
            .HasMany(e => e.UserAlbumAccesses)
            .WithOne(e => e.UserAccount)
            .HasForeignKey(e => e.UserAccountId);
    }

    private void OnAccountTypeModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountType>()
            .HasMany(e => e.UserAccounts)
            .WithOne(e => e.AccountType)
            .HasForeignKey(e => e.AccountTypeId)
            .IsRequired();
    }
}
