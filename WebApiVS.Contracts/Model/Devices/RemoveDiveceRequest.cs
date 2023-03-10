using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVS.Contracts.Model.Devices
{
    public class RemoveDiveceRequest
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }
}
