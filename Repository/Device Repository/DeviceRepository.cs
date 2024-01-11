using GameZone.Models;
using GameZone.Repository.Generic;

namespace GameZone.DeviceRepository;

public class DeviceRepository(ApplicationDbContext db) : GenericRepository<Device>(db), IDeviceRepository
{
    
}