﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace MTRSalesBoard.Models.Repository
{
    public class ApplicationDBContext : IdentityDbContext
    {
        // Constructor
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Sale> Sales { get; set; }

        // Creates the admin account from Appsettings.json
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration) {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();

            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Getting user info out of Appsettings.json   
            string username = configuration["Data:AdminUser:UserName"];
            string name = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];
            string uRole = configuration["Data:AdminUser:UserRole"];

            if (await userManager.FindByNameAsync(username) == null) {
                if (await roleManager.FindByNameAsync(role) == null) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                AppUser user = new AppUser
                {
                    Name = name,
                    UserName = username,
                    Email = email
                };
                IdentityResult result = await userManager
                .CreateAsync(user, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            if (await roleManager.FindByNameAsync(uRole) == null) {
                await roleManager.CreateAsync(new IdentityRole(uRole));
            }
        }
    }
}
