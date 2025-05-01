using Digitalantiz.Modules.Users.Application.Abstractions.Data;
using Digitalantiz.Modules.Users.Domain.Users;
using Digitalantiz.Modules.Users.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace Digitalantiz.Modules.Users.Infrastructure.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
    }
}
