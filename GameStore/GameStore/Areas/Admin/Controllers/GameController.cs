using GameStore.Context;
using GameStore.Extensions;
using GameStore.Models;
using GameStore.ViewModels.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace GameStore.Areas.Admin.Controllers;
[Area("Admin")]
public class GameController(IWebHostEnvironment _env, GamingStoreDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await _context.Games.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(GameCreateVM vm)
    {
        if (vm.File != null)
        {
            if (!vm.File.IsValidType("image"))
                ModelState.AddModelError("File", "File must be an image");
            if (!vm.File.IsValidSize(400))
                ModelState.AddModelError("File", "File must be less than 400kb");
        }
        if (!ModelState.IsValid) return View(vm);
        Game game = vm;
        game.CoverImg = await vm.File!.UploadAsync(_env.WebRootPath, "imgs", "games");
        await _context.Games.AddAsync(game);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        Game product = await _context.Games.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        string filePath = Path.Combine(_env.WebRootPath, "imgs", "games", product.CoverImg);
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }

        _context.Games.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int? id)
    {
        if (id is null) return BadRequest();
        var data = await _context.Games
            .Where(x => x.Id == id)
            .Select(x => new GameUpdateVM
            {
                Id = x.Id,
                CostPrice = x.CostPrice,
                Description = x.Description,
                FileUrl = x.CoverImg,
                Name = x.Title,
                Quantity = x.Quantity,
                SellPrice = x.SellPrice
            })
            .FirstOrDefaultAsync();
        if (data is null) return NotFound();
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> Update(int? id, GameUpdateVM vm)
    {

        Game? game = await _context.Games.FindAsync(id);
        if (game is null) return NotFound();
        if (!ModelState.IsValid) return View(vm);

        game.Title = vm.Name;
        game.Description = vm.Description;
        game.CostPrice = vm.CostPrice;
        game.SellPrice = vm.SellPrice;
        game.Quantity = vm.Quantity;
        game.GameId = vm.GameId;

        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
