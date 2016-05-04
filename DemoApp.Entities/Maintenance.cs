using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Entities
{
  public  class Maintenance
    {
        public int MaintenanceID { get; set; }
        public string  EquipmentTagName { get; set; }
        public string EquipmentName { get; set; }

        public string AttendedBy { get; set; }
        public System.Nullable<DateTime> AtendedDate { get; set; }
        public string Action { get; set; }
        public string Material { get; set; }
        public string PlantType { get; set; }
        public bool EntryCompleted { get; set; }

    }

}
