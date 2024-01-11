using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services;

public interface ICategorySelectListItemService
{
    public List<SelectListItem> ToSelectListItem(); 
}