using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using WebApiVS.Configuration;
using WebApiVS.Contracts.Devices;
using WebApiVS.Contracts.Model.Devices;
using WebApiVS.Data.Interfaces;
using WebApiVS.Data.Models;
using WebApiVS.Data.Queries;

namespace WebApiVS.Controllers
{
    /// <summary>
    /// Контроллер статусов устройств
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;
        private IDeviceRepository _devices;
        private IRoomRepository _rooms;

        public DevicesController(IOptions<HomeOptions> options, IDeviceRepository devices, IRoomRepository rooms, IMapper mapper)
        {
            _options = options;
            _devices = devices;
            _rooms = rooms;
            _mapper = mapper;
        }



        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _devices.GetDevices();

            var resp = new GetDevicesResponse
            {
                DeviceAmount = devices.Length,
                Devices = _mapper.Map<Device[], DeviceView[]>(devices)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add(AddDeviceRequest request)
        {
            var room = await _rooms.GetRoomByName(request.RoomLocation);
            if (room == null)
                return StatusCode(400, $"Ошибка: Комната {request.RoomLocation} не подключена. Сначала подключите комнату!");

            var device = await _devices.GetDeviceByName(request.Name);
            if (device != null)
                return StatusCode(400, $"Ошибка: Устройство {request.Name} уже существует.");

            var newDevice = _mapper.Map<AddDeviceRequest, Device>(request);
            await _devices.SaveDevice(newDevice, room);

            return StatusCode(201, $"Устройство {request.Name} добавлено. Идентификатор: {newDevice.Id}");
        }

        /// <summary>
        /// Обновление существующего устройства
        /// </summary>
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Edit(
            [FromRoute] Guid id,
            [FromBody] EditDeviceRequest request)
        {
            var room = await _rooms.GetRoomByName(request.NewRoom);
            if (room == null)
                return StatusCode(400, $"Ошибка: Комната {request.NewRoom} не подключена. Сначала подключите комнату!");

            var device = await _devices.GetDeviceById(id);
            if (device == null)
                return StatusCode(400, $"Ошибка: Устройство с идентификатором {id} не существует.");

            var withSameName = await _devices.GetDeviceByName(request.NewName);
            if (withSameName != null)
                return StatusCode(400, $"Ошибка: Устройство с именем {request.NewName} уже подключено. Выберите другое имя!");

            await _devices.UpdateDevice(
                device,
                room,
                new UpdateDeviceQuery(request.NewName, request.NewSerial)
            );

            return StatusCode(200, $"Устройство обновлено!  Имя — {device.Name}, Серийный номер — {device.SerialNumber},  Комната подключения  —  {device.Room.Name}");
        }


        #region на память
        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        //[HttpGet]
        //[Route("")]
        //public IActionResult Get()
        //{
        //    return StatusCode(200, "Устройства отсутствуют");
        //}
        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        //     [HttpPost]
        //     [Route("Add")]
        //     public IActionResult Add(
        //       [FromBody] // Атрибут, указывающий, откуда брать значение объекта
        //AddDeviceRequest request // Объект запроса
        //     )
        //     {
        //         //if (request.CurrentVolts < 120)
        //         //{
        //         //    return StatusCode(403, $"Устройства с напряжением меньше 120 вольт не поддерживаются!");
        //         //}

        //         //if (request.CurrentVolts < 120)
        //         //{
        //         //    // Добавляем для клиента информативную ошибку
        //         //    ModelState.AddModelError("currentVolts", "Устройства с напряжением меньше 120 вольт не поддерживаются!");
        //         //    return BadRequest(ModelState);
        //         //}

        //         return StatusCode(200, $"Устройство {request.Name} добавлено!");
        //     }
        #endregion


    }
}
