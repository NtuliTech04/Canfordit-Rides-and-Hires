using Canfordit_Rides_and_Hires.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(Canfordit_Rides_and_Hires.Startup))]
namespace Canfordit_Rides_and_Hires
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("Super-Admin"))
            {
                //create super admin role
                var role = new IdentityRole("Super-Admin");
                roleManager.Create(role);

                //create default user
                var user = new ApplicationUser();
                user.UserName = "canfordit@hnr.co.za";
                user.Email = "canfordit@hnr.co.za";
                user.FirstName = "Super-Admin";
                user.LastName = "Canfordit R&H";
                user.EmailConfirmed = true;
                string pwd = "CanforditHnR";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Super-Admin");
                }
            }
        }
    }
}
