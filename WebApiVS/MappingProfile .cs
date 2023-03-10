using AutoMapper;
using WebApiVS.Configuration;
using WebApiVS.Contracts.Devices;
using WebApiVS.Contracts.Home;
using WebApiVS.Contracts.Model.Devices;
using WebApiVS.Contracts.Model.Rooms;
using WebApiVS.Data.Models;

namespace WebApiVS
{
    /// <summary>
    /// Настройки маппинга всех сущностей приложения
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));

            CreateMap<AddDeviceRequest, Device>()
               .ForMember(d => d.Location,
                   opt => opt.MapFrom(r => r.RoomLocation));
            CreateMap<AddRoomRequest, Room>();
            CreateMap<Device, DeviceView>();
            CreateMap<Room, RoomView>();
        }
    }
}
