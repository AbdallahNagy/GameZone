using GameZone.Models;

namespace GameZone.Repository.Generic;

public class GenericRepository<T>(ApplicationDbContext db) : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _db = db;

    public void Add(Game game)
    {
        _db.Add(game);
        _db.SaveChanges();
    }

    public IEnumerable<T> GetAll() => _db.Set<T>().AsNoTracking();
}