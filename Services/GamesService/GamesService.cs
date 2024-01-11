using GameZone.Models;
using GameZone.Repository.Game_Repository;
using GameZone.ViewModels;

namespace GameZone.Services.GamesService;

public class GamesService : IGamesService
{
    private readonly IWebHostEnvironment _webHostEnv;
    private readonly string _coverPath;
    private readonly IGameRepository _gameRepository;
    public GamesService(IWebHostEnvironment webHostEnv, IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
        _webHostEnv = webHostEnv;
        _coverPath = $"{_webHostEnv.WebRootPath}/assets/images/games";
    }
    public async Task Create(CreateGameFormVM model)
    {
        var coverName = $"{Guid.NewGuid()}-{model.Cover.FileName}";
        var path = Path.Combine(_coverPath, coverName);

        using var stream = File.Create(path);
        await model.Cover.CopyToAsync(stream);

        // save game to db
        var game = new Game()
        {
          Name = model.Name,
          Description = model.Description,
          Cover = coverName,
          CategoryId = model.CategoryId,
          GamesDevices = model.SelectedDevices.Select(d => new GameDevice {DeviceId = d}).ToList()  
        };

        _gameRepository.Add(game);        
    }
}