using GameZone.Models;
using GameZone.Services;
using GameZone.Services.GamesService;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers;

public class GamesController(ApplicationDbContext db,
    IDeviceSelectListItemService deviceService,
    ICategorySelectListItemService categoryService,
    IGamesService gameService) : Controller
{
    private readonly ApplicationDbContext _db = db;
    private readonly IDeviceSelectListItemService _deviceService = deviceService;
    private readonly ICategorySelectListItemService _categoryService = categoryService;
    private readonly IGamesService _gameService = gameService;


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        var categories = _categoryService.ToSelectListItem();

        var devices = _deviceService.ToSelectListItem();

        var createGameVM = new CreateGameFormVM()
        {
            Categories = categories,
            Devices = devices
        };

        return View(createGameVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameFormVM model)
    {
        model.Categories = _categoryService.ToSelectListItem();
        model.Devices = _deviceService.ToSelectListItem();

        if (!ModelState.IsValid) return View(model);

        await _gameService.Create(model);

        return RedirectToAction(nameof(Index));
    }
}