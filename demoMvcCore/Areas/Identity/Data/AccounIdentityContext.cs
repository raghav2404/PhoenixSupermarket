using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace demoMvcCore.Areas.Identity.Data;

public class AccounIdentityContext : IdentityDbContext<IdentityUser>
{
    public AccounIdentityContext(DbContextOptions<AccounIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
