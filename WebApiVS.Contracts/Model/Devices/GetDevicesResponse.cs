using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVS.Contracts.Model.Devices
{
    public class GetDevicesResponse
    {
        public int DeviceAmount { get; set; }
        public DeviceView[] Devices { get; set; }
    }
}
