using AfrowaveCountriesTools.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace AfrowaveCountriesTools.Shared.Services;

/// <summary>
/// Represents a contract for user-related data access operations.
/// </summary>
/// <remarks>Implement this interface to provide methods for creating, retrieving, updating, or deleting user
/// entities in a data store. The specific operations and their behavior should be defined by the implementing class.
/// This interface is typically used to abstract the underlying data access technology and promote
/// testability.</remarks>
public interface IUserRepository
{
   // Define repository operations as needed
}

/// <summary>
/// Provides an implementation of the IUserRepository interface for accessing and managing user data using an
/// ApplicationDbContext.
/// </summary>
/// <remarks>This class is typically used to encapsulate data access logic related to users, allowing for
/// separation of concerns and easier unit testing. Instances are created with a factory for ApplicationDbContext,
/// enabling efficient context management in scenarios such as dependency injection.</remarks>
/// <remarks>
/// Initializes a new instance of the UserRepository class using the specified database context factory.
/// </remarks>
/// <remarks>Use this constructor to provide a context factory that manages the lifetime and configuration of
/// ApplicationDbContext instances. This enables efficient and thread-safe access to the database, especially in
/// scenarios such as dependency injection or scoped services.</remarks>
/// <param name="factory">A factory used to create instances of ApplicationDbContext for database operations. Cannot be null.</param>
public class UserRepository(IDbContextFactory<ApplicationDbContext> factory) : IUserRepository
{
   private readonly IDbContextFactory<ApplicationDbContext> _factory = factory;
}