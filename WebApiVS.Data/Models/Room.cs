using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVS.Data.Models
{
    [Table("Rooms")]
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime AddDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public int Area { get; set; }
        public bool GasConnected { get; set; }
        public int Voltage { get; set; }
    }
}
