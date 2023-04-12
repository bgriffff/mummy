﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mummy.Areas.Identity.Data;

namespace mummy.Data;

public class mummyDbContext : IdentityDbContext<ApplicationUser>
{
    public mummyDbContext(DbContextOptions<mummyDbContext> options)
        : base(options)
    { 
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
