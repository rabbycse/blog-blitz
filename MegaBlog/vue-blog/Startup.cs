using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using vue_blog.Data;
using Microsoft.AspNetCore.SpaServices.Webpack;

namespace vue_blog
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config) 
        {
            _config = config;
        } 
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _config["Connection"];
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });
            
            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<AppDbContext>();
            
            services.AddMvc();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                 app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }

            app.UseAuthentication();

            app.UseMvc(router => 
            {
                router.MapSpaFallbackRoute("spa-fallback", new
                {
                    controller = "Home", Action = "Index"
                });

                router.MapRoute("Default", 
                      "{controller}=Home/{action}=Index/{id?}");
            });
        }
    }
}
