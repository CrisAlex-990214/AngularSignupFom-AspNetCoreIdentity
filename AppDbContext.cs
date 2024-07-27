using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SignupIdentity
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions opts) : base(opts)
        {

        }
    }
}
