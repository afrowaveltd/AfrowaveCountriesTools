using AfrowaveCountriesTools.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace AfrowaveCountriesTools.Shared.Services;

public interface IUserRepository
{
	// Define repository operations as needed
}

public class UserRepository : IUserRepository
{
	private readonly IDbContextFactory<ApplicationDbContext> _factory;

	public UserRepository(IDbContextFactory<ApplicationDbContext> factory)
	{
		_factory = factory;
	}
}
