namespace uPhoto.Database.Contracts;

public interface IDbContextBase
{
	public Task<int> SaveChangesAsync(CancellationToken token);
}
