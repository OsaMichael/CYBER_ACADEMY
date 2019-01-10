using CyberAcademy1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Models
{
    public class CyberModel
    {
        //[Key]
        public int CyberId { get; set; }
    
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public int? HigherId { get; set; }
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
        //public string State { get; set; }
        public string Contact { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string NYSCFileName { get; set; }
        //public virtual RoleModel Role { get; set; }
        //public virtual UserModel User { get; set; }
        public virtual HigherInstitutionModel Higher { get; set; }
        public virtual CourseOfStudyModel Course { get; set; }

        public virtual StateModel State { get; set; }
        public virtual ApplicationUser User { get; set; }

        public CyberModel()
        {
            //new RoleModel();
            //new UserModel();
            new HigherInstitutionModel();
            new CourseOfStudyModel();
            new StateModel();
            new ApplicationUser();
        }

        public CyberModel(Cyber cyber)
        {
            this.Assign(cyber);
            Higher = new HigherInstitutionModel();
            Course = new CourseOfStudyModel();
            State = new StateModel();
            User = new ApplicationUser();
            //HigherId = cyber.HigherId;
            //CourseId = cyber.CourseId;
            //StateId = cyber.StateId;
            //FirstName = cyber.FirstName;
            //LastName = cyber.LastName;
            //OtherNames = cyber.OtherNames;
            //Address = cyber.Address;
            //ClassOfDigree = cyber.ClassOfDigree;
            //Contact = cyber.Contact;

            //DateOfBirth = cyber.DateOfBirth;
            //Email = cyber.Email;
            //Gender = cyber.Gender;
            //NYSC_upload = cyber.NYSC_upload;
            ////SchoolAttended = model.SchoolAttended,
            ////State = model.State,
            //YearOfGraduation = cyber.YearOfGraduation;
            //CreatedDate = DateTime.Now;
            //CreatedBy = cyber.CreatedBy;




        }

        public Cyber Create(CyberModel model)
        {
            return new Cyber
            {

                //UserId = model.UserId,
                HigherId = model.HigherId,
                CourseId = model.CourseId,
                StateId = model.StateId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                OtherNames = model.OtherNames,
                Address = model.Address,
                ClassOfDigree = model.ClassOfDigree,
                Contact = model.Contact,
            
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                Gender = model.Gender,
                NYSC_upload = model.NYSC_upload,
                //SchoolAttended = model.SchoolAttended,
                //State = model.State,
                YearOfGraduation = model.YearOfGraduation,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy,
                 NYSCFileName = model.NYSCFileName
           

            };
        }

        public Cyber Edit(Cyber entity, CyberModel model)
        {
            entity.CyberId = model.CyberId;
      
          
            entity.CourseId = model.CourseId;
            entity.StateId = model.StateId;
            entity.HigherId = model.HigherId;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.OtherNames = model.OtherNames;
            entity.Email = model.Email;
            entity.Contact = model.Contact;
            entity.ClassOfDigree = model.ClassOfDigree;

            entity.DateOfBirth = model.DateOfBirth;
            entity.Email = model.Email;
            entity.Gender = model.Gender;

            entity.Address = model.Address;
     
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = model.ModifiedBy;

            return entity;
        }
    }
}