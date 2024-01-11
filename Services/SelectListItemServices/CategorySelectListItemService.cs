using System.Reflection.Metadata.Ecma335;
using GameZone.Models;
using GameZone.Repository.CategoryRepository;
using GameZone.Repository.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services;

public class CategorySelectListItemService(ICategoryRepository categoryRepo) : ICategorySelectListItemService
{
    private readonly ICategoryRepository _categoryRepo = categoryRepo;
    public List<SelectListItem> ToSelectListItem()
        => _categoryRepo.GetAll().Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            .OrderBy(d => d.Text)
            .ToList();
}