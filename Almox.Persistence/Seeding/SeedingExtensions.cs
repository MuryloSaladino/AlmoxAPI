using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace Almox.Persistence.Seeding;

public static class SeedingExtensions
{
    private static readonly string AlmoxName = Environment.GetEnvironmentVariable("ALMOX_NAME")
        ?? throw new InvalidConfigurationException("The environment needs \"ALMOX_NAME\" variable");
    private static readonly string AdminUsername = Environment.GetEnvironmentVariable("ADMIN_USERNAME")
        ?? throw new InvalidConfigurationException("The environment needs \"ADMIN_USERNAME\" variable");
    private static readonly string AdminEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL")
        ?? throw new InvalidConfigurationException("The environment needs \"ADMIN_EMAIL\" variable");
    private static readonly string AdminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD")
        ?? throw new InvalidConfigurationException("The environment needs \"ADMIN_PASSWORD\" variable");

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
                    Department = almoxDepartment,
                    Username = AdminUsername,
                    Email = AdminEmail,
                    Password = AdminPassword,
                    Role = UserRole.Admin,
                };

                PasswordHasher<User> hasher = new();
                adminUser.Password = hasher.HashPassword(adminUser, adminUser.Password); 
                
                users.Add(adminUser);
            }

            await context.SaveChangesAsync();
        }
    }
}