using GameZone.DeviceRepository;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services;

public class DevicesSelectListItemService(IDeviceRepository deviceRepo) : IDeviceSelectListItemService
{
    private readonly IDeviceRepository _deviceRepo = deviceRepo;
    public List<SelectListItem> ToSelectListItem()
        => _deviceRepo.GetAll().Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            .OrderBy(d => d.Text)
            .ToList();
}