using GameZone.Models;
using GameZone.Repository.Generic;

namespace GameZone.Repository.CategoryRepository;

public class CategoryRepository(ApplicationDbContext db) : GenericRepository<Category>(db), ICategoryRepository
{

}
