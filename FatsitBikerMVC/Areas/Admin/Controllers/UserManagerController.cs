using FatsitBikerMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FatsitBikerMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagerController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new Dictionary<string, IList<string>>();
            foreach (var user in users)
            {
                userRoles[user.Id] = await _userManager.GetRolesAsync(user);
            }
            ViewBag.UserRoles = userRoles;
            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            ViewBag.RoleList = new SelectList(roles, userRoles.FirstOrDefault());
            ViewBag.CurrentRole = userRoles.FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser model, string SelectedRole, string NewPassword)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return NotFound();

            user.FullName = model.FullName;
            user.Address = model.Address;
            user.Age = model.Age;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                // Handle password change if requested
                if (!string.IsNullOrEmpty(NewPassword))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passResult = await _userManager.ResetPasswordAsync(user, token, NewPassword);
                    if (!passResult.Succeeded)
                    {
                        foreach (var error in passResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(model);
                    }
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                var currentRole = userRoles.FirstOrDefault();

                if (currentRole != SelectedRole)
                {
                    if (currentRole != null)
                    {
                        await _userManager.RemoveFromRoleAsync(user, currentRole);
                    }
                    if (!string.IsNullOrEmpty(SelectedRole))
                    {
                        await _userManager.AddToRoleAsync(user, SelectedRole);
                    }
                }

                TempData["success"] = "Cập nhật người dùng thành công!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.RoleList = new SelectList(roles);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);
            TempData["success"] = "Đã xóa người dùng thành công!";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Create()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.RoleList = new SelectList(roles);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName = model.FullName,
                    Address = model.Address,
                    Age = model.Age,
                    PhoneNumber = model.PhoneNumber,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.SelectedRole))
                    {
                        await _userManager.AddToRoleAsync(user, model.SelectedRole);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_Customer);
                    }

                    TempData["success"] = "Tạo người dùng thành công!";
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.RoleList = new SelectList(roles);
            return View(model);
        }
    }

    public class UserCreateViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Email là bắt buộc")]
        [System.ComponentModel.DataAnnotations.EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [System.ComponentModel.DataAnnotations.StringLength(100, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên", MinimumLength = 6)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Họ và tên là bắt buộc")]
        public string FullName { get; set; }

        public string Address { get; set; }
        public int? Age { get; set; }
        public string PhoneNumber { get; set; }
        public string SelectedRole { get; set; }
    }
}
