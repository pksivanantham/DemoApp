using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Entities
{
   public  class Equipment
    {
       [Key]
        public int EquipmentID { get; set; }
        public string EquipmentTagName { get; set; }
        public string EquipmentName { get; set; }
        public string PlantType { get; set; }
    }
}
