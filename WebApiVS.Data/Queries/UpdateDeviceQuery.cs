using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVS.Data.Queries
{
    public class UpdateDeviceQuery
    {
        public UpdateDeviceQuery(string name = null, string serial = null)
        {
            NewName= name;
            NewSerial= serial;
        }
        public string NewName { get; set; }
        public string NewSerial { get; set; }
    }
}
