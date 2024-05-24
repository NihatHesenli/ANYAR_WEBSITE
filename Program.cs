using ANYAR_WEBSITE.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ANYAR_WEBSITE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLenght = 8;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._"
                opt.Lockout.AllowedForNewUsers = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                opt.User.RequireUniqueEmail = true;
            }) .AddEntityFrameworkStores<AppDbContext>();
          builder.Services.AddDbContext<AppDbContext>(opt =>
          {
              opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
          
          }
              
              
            
             
            
            
            );
            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );




            app.MapControllerRoute(
                name:"default",
                pattern:"{controller=Home}/{action=index}");
                
                


            app.Run();
        }
    }
}
