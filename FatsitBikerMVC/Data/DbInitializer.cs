using FatsitBikerMVC.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FatsitBikerMVC.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Đảm bảo các role tồn tại
            if (!await roleManager.RoleExistsAsync(SD.Role_Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
            }
            if (!await roleManager.RoleExistsAsync(SD.Role_Customer))
            {
                await roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
            }

            // Tạo hoặc cập nhật Admin
            var existingAdmin = await userManager.FindByEmailAsync("admin@gmail.com");
            if (existingAdmin == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FullName = "Admin Quản Trị",
                    Address = "Hà Nội",
                    Age = 30,
                    PhoneNumber = "0987654321",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, SD.Role_Admin);
                }
            }
            else
            {
                existingAdmin.PhoneNumber = "0987654321";
                await userManager.UpdateAsync(existingAdmin);
            }

            // Tạo hoặc cập nhật 5 Customer
            for (int i = 1; i <= 5; i++)
            {
                string email = $"user{i}@gmail.com";
                var existingCustomer = await userManager.FindByEmailAsync(email);
                if (existingCustomer == null)
                {
                    var customer = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FullName = $"Người dùng {i}",
                        Address = "Hồ Chí Minh",
                        Age = 20 + i,
                        PhoneNumber = $"012345678{i}",
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(customer, "User@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(customer, SD.Role_Customer);
                    }
                }
                else
                {
                    existingCustomer.PhoneNumber = $"012345678{i}";
                    await userManager.UpdateAsync(existingCustomer);
                }
            }
        }
    }
}
