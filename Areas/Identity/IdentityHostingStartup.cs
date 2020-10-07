using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrationAndLogin.Areas.Identity.Data;
using RegistrationAndLogin.Data;

[assembly: HostingStartup(typeof(RegistrationAndLogin.Areas.Identity.IdentityHostingStartup))]
namespace RegistrationAndLogin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RegistrationAndLoginDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RegistrationAndLoginDbContextConnection")));

                services.AddDefaultIdentity<AppUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    
                 })
                    .AddEntityFrameworkStores<RegistrationAndLoginDbContext>();
            });
        }
    }
}