using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace vue_blog 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Host = CreateWebHostBuilder(args).Build();
            using (var scope = Host.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<Data.AppDbContext>();
                if (!ctx.Users.Any())
                {
                    var userMgr = scope.ServiceProvider
                        .GetRequiredService<UserManager<IdentityUser>>();
                    var admin = new IdentityUser{
                        UserName = "admin"
                    };
                    userMgr.CreateAsync(admin, "password").GetAwaiter().GetResult();
                }
            }
                Host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
