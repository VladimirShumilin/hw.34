using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVS.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при обновлении устройства
    /// </summary>
    public class UpdateRoomQuery
    {
        public string NewName { get; }
        public int NewArea { get; }
        public bool NewGasConnected { get; }
        public int NewVoltage { get; }

        public UpdateRoomQuery(string newName = null, int newArea = 0, int newVoltage = 0, bool newGasConnected = false)
        {
            NewName = newName;
            NewArea = newArea;
            NewGasConnected = newGasConnected;
            NewVoltage = newVoltage;
        }
    }
}
