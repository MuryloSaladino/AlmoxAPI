using Almox.Domain.Entities;
using Almox.Persistence.Config;
using Almox.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Seeding;

public static class SeedingExtensions
{
    private static readonly string AlmoxName = DotEnv.Get("ALMOX_NAME");
    private static readonly string AdminUsername = DotEnv.Get("ADMIN_USERNAME");
    private static readonly string AdminEmail = DotEnv.Get("ADMIN_EMAIL");
    private static readonly string AdminPassword = DotEnv.Get("ADMIN_PASSWORD");

    public static async Task SeedData(this AlmoxContext context)
    {
        var departments = context.Set<Department>();
        var almoxExists = await departments.AnyAsync(d => d.Name == AlmoxName);
        
        if(!almoxExists)
        {
            var almoxDepartment = new Department()
            {
                Name = AlmoxName,
            };
            departments.Add(almoxDepartment);

            var users = context.Set<User>();
            var adminExists = await users.AnyAsync(u => u.Username == AdminUsername);

            if(!adminExists)
            {
                var adminUser = new User()
                {
                    DepartmentId = almoxDepartment.Id,
                    Username = AdminUsername,
                    Email = AdminEmail,
                    Password = AdminPassword,
                    IsAdmin = true,
                };

                PasswordHasher<User> hasher = new();
                adminUser.Password = hasher.HashPassword(adminUser, adminUser.Password); 
                
                users.Add(adminUser);
            }

            await context.SaveChangesAsync();
        }
    }
}