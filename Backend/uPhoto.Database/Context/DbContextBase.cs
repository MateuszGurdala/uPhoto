using Microsoft.EntityFrameworkCore;

namespace uPhoto.Database.Context;

public class DbContextBase : DbContext
{
    public DbContextBase(DbContextOptions<DbContextBase> options) : base(options)
    {
    }
}