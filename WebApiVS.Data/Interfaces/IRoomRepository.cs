using System.Threading.Tasks;
using System;
using WebApiVS.Data.Models;
using WebApiVS.Data.Queries;

namespace WebApiVS.Data.Interfaces
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Room в базе 
    /// </summary>
    public interface IRoomRepository
    {
        Task<Room> GetRoomByName(string name);
        Task AddRoom(Room room);
        Task<Room[]> GetRooms();
        Task<Room> GetRoomById(Guid id);
        Task UpdateRoom(Room room, UpdateRoomQuery query);
    }

}
