using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVS.Data.Models;
using WebApiVS.Data.Queries;

namespace WebApiVS.Data.Interfaces
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Device в базе
    /// </summary>
    public interface IDeviceRepository
    {
        Task<Device[]> GetDevices();
        Task<Device> GetDeviceByName(string name);
        Task<Device> GetDeviceById(Guid id);
        Task SaveDevice(Device device, Room room);
        Task UpdateDevice(Device device, Room room, UpdateDeviceQuery query);
        Task DeleteDevice(Device device);
    }
        
}
