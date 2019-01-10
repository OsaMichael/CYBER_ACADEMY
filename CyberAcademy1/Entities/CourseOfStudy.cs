using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Entities
{

    public class CourseOfStudy
    {
        [Key]
        public int CourseId { get; set; }
        public string Course_Name { get; set; }


        public virtual ICollection<Cyber> Cyberses { get; set; }
    }
}