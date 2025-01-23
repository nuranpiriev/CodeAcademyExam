using ExamCake.BL.DTOs.ChiefDTO;
using ExamCake.BL.Services.Abstracts;
using ExamCake.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListRace.PL.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ChiefController : Controller
{
    readonly IChiefService _service;
    readonly IDesignationService _categoryService;

    public ChiefController(IChiefService service, IDesignationService categoryService)
    {
        _service = service;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            IEnumerable<GetChiefDTO> list = await _service.GetAllChiefAsync();

            return View(list);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            ViewData["Designation"] = new SelectList(await _categoryService.GetAllDesignationAsync(), "Id", "Title");
            return View();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostChiefDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Designation"] = new SelectList(await _categoryService.GetAllDesignationAsync(), "Id", "Title");
            return View(dto);
        }

        try
        {
            await _service.CreateChiefAsync(dto);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            ViewData["Designation"] = new SelectList(await _categoryService.GetAllDesignationAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Update(int id)
    {
        try
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllDesignationAsync(), "Id", "Title");
            return View(await _service.GetChiefByIdAsync(id));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, PutChiefDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Designation"] = new SelectList(await _categoryService.GetAllDesignationAsync(), "Id", "Title");
            return View(dto);
        }

        try
        {
            await _service.UpdateChiefAsync(id, dto);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            ViewData["Designation"] = new SelectList(await _categoryService.GetAllDesignationAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.HardDeleteChiefAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            return View(await _service.GetChiefByIdAsync(id));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
}
