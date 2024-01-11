using GameZone.Models;
using GameZone.Repository.Generic;
using GameZone.ViewModels;

namespace GameZone.Repository.Game_Repository;

public class GameRepository : GenericRepository<Game>, IGameRepository
{
    private readonly IWebHostEnvironment _webHostEnv;
    private readonly ApplicationDbContext _db;
    private readonly string _coverPath;
    public GameRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnv) : base(db)
    {
        _webHostEnv = webHostEnv;
        _db = db;
        _coverPath = $"{_webHostEnv.WebRootPath}/assets/images/games";
    }
}