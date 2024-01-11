using GameZone.Models;

namespace GameZone.Repository.Generic;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    void Add(Game game);
}