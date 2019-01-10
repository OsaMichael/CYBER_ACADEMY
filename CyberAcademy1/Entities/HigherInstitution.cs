using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Entities
{
    public class HigherInstitution
    {
        [Key]
        public int HigherId { get; set; }
        public string Instit_Name { get; set; }

        public virtual ICollection<Cyber> Cyberses { get; set; }

    }
}