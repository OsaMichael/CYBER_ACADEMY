using CyberAcademy1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Models
{
    public class CourseOfStudyModel
    {
        public int CourseId { get; set; }
        public string Course_Name { get; set; }

        public virtual ICollection<CyberModel> Cyberses { get; set; }


        public CourseOfStudyModel()
        {
            new HashSet<CyberModel>();
        }
        public CourseOfStudyModel(CourseOfStudy course)
        {
            this.Assign(course);
            new HashSet<CyberModel>();
        }
        public CourseOfStudy Create(CourseOfStudyModel model)
        {
            return new CourseOfStudy
            {
                Course_Name = model.Course_Name
            };
        }
    }
}