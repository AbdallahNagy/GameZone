using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services;

public interface IDeviceSelectListItemService
{
    public List<SelectListItem> ToSelectListItem(); 
}