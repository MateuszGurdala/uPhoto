using Microsoft.EntityFrameworkCore;
using uPhoto.Database.Contracts;

namespace uPhoto.Database.Context;

public class DbContextBase : DbContext, IDbContextBase
{
    public DbContextBase(DbContextOptions<DbContextBase> options) : base(options)
    {
    }

    public Task<int> SaveChangesAsync(CancellationToken token)
    {
        return base.SaveChangesAsync(token);
    }
}
