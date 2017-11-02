using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RoleBased1.Models;

[assembly: OwinStartupAttribute(typeof(RoleBased1.Startup))]
namespace RoleBased1
{
    public partial class Startup
    {
     
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);

            //calling CreateRole Function for generating roles by diksha.
            createRolesandUsers();
            }
  //tghui
        /// <summary>
        ///  Creating Roles as Admin User and manager and Employe
        ///  In this method we will create default User roles and Admin user for login
        /// </summary>


        private void createRolesandUsers()
            {
                ApplicationDbContext context = new ApplicationDbContext();

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


                // In Startup iam creating first Admin Role and creating a default Admin User 
                if (!roleManager.RoleExists("Admin"))
                {

                    // first we create Admin rool
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website				

                    var user = new ApplicationUser();
                    user.UserName = "admin";
                    user.Email = "admin@smartdatainc.net";

                    string userPWD = "Password@123";

                    var chkUser = UserManager.Create(user, userPWD);

                    //Add default User to Role Admin
                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Admin");

                    }
                }

            // creating Creating User role 
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
            // creating Creating Manager role 
            if (!roleManager.RoleExists("Manager"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Manager";
                    roleManager.Create(role);

                }

                // creating Creating Employee role 
                if (!roleManager.RoleExists("Employee"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Employee";
                    roleManager.Create(role);

                }
            }
        }
}
