using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WarunkStream.Models;

namespace WarunkStream.Infrastructures
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public static ApplicationDBContext Create()
        {
            return new ApplicationDBContext();
        }
        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.Team> Teams { get; set; }
        public DbSet<Models.MemberTeam> MemberTeams { get; set; }
        public DbSet<Models.Certificate> Certificates { get; set; }
    }
}