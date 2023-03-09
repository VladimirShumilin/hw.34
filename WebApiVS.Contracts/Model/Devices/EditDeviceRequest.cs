namespace WebApiVS.Contracts.Devices
{
    /// <summary>
    /// Запрос для обновления свойств подключенного устройства
    /// </summary>
    public class EditDeviceRequest
    {
        public string NewRoom { get; set; }
        public string NewName { get; set; }
        public string NewSerial { get; set; }
    }
}
