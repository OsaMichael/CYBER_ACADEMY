using CyberAcademy1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Models
{
    public class CyberModel : Model
    {
        //[Key]
        public int CyberId { get; set; }

        public string UserId { get; set; }
        public int CourseId { get; set; }
        public int? HigherId { get; set; }
        public int? StateId { get; set; }
        [Required]
        public string FirstName { get; set; }
       
        public string ContentType { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string OtherNames { get; set; }
    
        public string Gender { get; set; }
        //[Range(1999, 2000,
        // ErrorMessage = "Applicant age must be between 1991 and 2000")]
        //[CustomValidation(typeof(ValidationResult), "Validate")]

        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        //public string SchoolAttended { get; set; }
        [Required]
        public string ClassOfDigree { get; set; }
        [Required]
        public string Qualification { get; set; }
       
        public string Grade { get; set; }
        [Required]
        public string YearOfGraduation { get; set; }
       
        public string NYSC_upload { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        //public string State { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string NewCourse { get; set; }
        public string NewHigher { get; set; }
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

        }

        public Cyber Create(CyberModel model)
        {
            int age = 0;
            DateTime currentDate = DateTime.Now;
            DateTime dob = Convert.ToDateTime(model.DateOfBirth);
            age = (currentDate.Year) - (dob.Year);
            model.Age = age;


            return new Cyber
            {

                //UserId = model.UserId,
                HigherId = model.HigherId,
                CourseId = model.CourseId,
                StateId = model.StateId,
                ContentType = model.ContentType,
                FirstName = model.FirstName,
                LastName = model.LastName,
                OtherNames = model.OtherNames,
                Address = model.Address,
                ClassOfDigree = model.ClassOfDigree,
                Contact = model.Contact,
                Qualification = model.Qualification,
                  Grade = model.Grade,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                Gender = model.Gender,
                NYSC_upload = model.NYSC_upload,
                Age=model.Age,
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

            public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
            {
                if ((DateTime.Now.Year - DateOfBirth.Year) <= 18 || (DateTime.Now.Year - DateOfBirth.Year) > 28)
                    return new[] 
                    {
                        new ValidationResult("Date of Birth must be above 18 years and not more than 28 years of age", new[] { "DateOfBirth" })
                    };
                else return base.Validate(validationContext);
            }
        }
    }
