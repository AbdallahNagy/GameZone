using GameZone.Repository.CategoryRepository;
using GameZone.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Models;

public class Category : BaseEntity
{
    public ICollection<Game> Games { get; set; } = new List<Game>();
}
