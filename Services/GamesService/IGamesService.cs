using GameZone.ViewModels;

namespace GameZone.Services.GamesService;

public interface IGamesService
{
    Task Create(CreateGameFormVM model);
}