using GarbageDay.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarbageDay.Startup))]
namespace GarbageDay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        public void CreateRoles()
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Customer"))

            {

                var role = new IdentityRole();

                role.Name = "Customer";

                roleManager.Create(role);

            }


            if (!roleManager.RoleExists("Trash Collector"))

            {

                var role = new IdentityRole();

                role.Name = "Trash Collector";

                roleManager.Create(role);

            }
        }
    }
}
