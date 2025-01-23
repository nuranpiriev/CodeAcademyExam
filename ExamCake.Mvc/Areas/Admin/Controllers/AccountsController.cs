using ExamCake.BL.Services.Abstracts;
using ExamCake.BL.DTOs;
using Microsoft.AspNetCore.Mvc;
using ExamCake.BL.DTOs.UserDTOs;

namespace ListRace.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class AccountController : Controller
{
    readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
            return Redirect("/admin");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginUserDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _service.LoginAsync(dto);
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }

        return Redirect("/admin");
    }

    public IActionResult Register()
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
            return Redirect("/admin");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _service.RegisterAsync(dto);
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }

        return Redirect("/admin/account/login");
    }

    public async Task<IActionResult> Logout()
    {
        try
        {
            await _service.LogoutAsync();
            return Redirect("/");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
}
