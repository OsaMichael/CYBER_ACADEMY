using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Entities
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string State_Name { get; set; }
    }
}