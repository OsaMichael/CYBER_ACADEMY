using CyberAcademy1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Entities
{
    public partial class Cyber
    {
        [Key]
        public int CyberId { get; set; }
     
        public int CourseId { get; set; }
        public int? HigherId { get; set; }
        public string UserId { get; set; }
        public int? StateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        //public string SchoolAttended { get; set; }
        public string ClassOfDigree { get; set; }
        public string YearOfGraduation { get; set; }
        public string NYSC_upload { get; set; }
        public string Email { get; set; }
 
        public string Contact { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string NYSCFileName { get; set; }
        public virtual HigherInstitution HigherInstitution { get; set; }
        public virtual CourseOfStudy Course { get; set; }
        public virtual State State { get; set; }
        //public virtual ApplicationUser User { get; set; }

        public Cyber()
        {
            new HashSet<HigherInstitution>();
            new HashSet<CourseOfStudy>();
            new HashSet<State>();
        }
    }
}