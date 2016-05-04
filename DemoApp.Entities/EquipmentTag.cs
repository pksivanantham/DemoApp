using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Entities
{
   public    class EquipmentTag
    {
       [Key]
        public int EquipmentTagID { get; set; }
        public string EquipmentTagName { get; set; }
        public string PlanType { get; set; }
    }
}
