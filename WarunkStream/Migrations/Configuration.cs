namespace WarunkStream.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WarunkStream.Infrastructures;
    using WarunkStream.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WarunkStream.Infrastructures.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WarunkStream.Infrastructures.ApplicationDBContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDBContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDBContext()));

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Participant" });
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            };
            var author = new ApplicationUser
            {
                PhoneNumber = "+62818271214",
                PhoneNumberConfirmed = true,
                UserName = "admin@warunksofficial.com",
                Email = "admin@warunksofficial.com",
                FullName = "Administrator Warunk Stream",
                Institution = "Warunks Official",
                Title = "CEO"
            };
            if (manager.FindByName("admin@warunksofficial.com") == null)
            {
                manager.Create(author, "Warunks@2020");
                manager.AddToRoles(author.Id, new string[] { "Administrator", "Participant" });
            }
        }
    }
}
