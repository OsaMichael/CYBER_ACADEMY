using CyberAcademy1.Entities;
using CyberAcademy1.Interface;
using CyberAcademy1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Manager
{
    public class CyberManager : ICyberManager
    {
        private ApplicationDbContext _context;
        public CyberManager(ApplicationDbContext context)
        {
            _context = context; 
        }

        public bool  CreateCyber(CyberModel model, ref int cyberid)
        {
            //return Operation.Create(() =>
            //{

                model.Validate();
                //var valid = model.Validate(new ValidationContext(this, serviceProvider: null, items: null));
               // if (valid.Any()) throw new Exception(valid.FirstOrDefault().ToString());
                var isExist = _context.Cybers.Where(e => e.Email == model.Email).FirstOrDefault();
                if (isExist != null) throw new Exception("email already exist");

                var entity = model.Create(model);
                //if(entity.DateOfBirth >)

                _context.Cybers.Add(entity);

                //_context.Set<Cyber>().Add(entity);
                _context.SaveChanges();
            cyberid = entity.CyberId;
                return true;
            //});
        }



        //public Operation UpdateCyber(CyberModel model)
        //{
        //    return Operation.Create(() =>
        //    {
        //        var ementity = _context.Cybers.Find(model.CyberId);
        //        if (ementity == null) throw new Exception($"{model.CyberId} Empolyee does not exist");

        //        var entity = model.Edit(ementity, model);
        //        _db.Update(entity);
        //        var result = _db.SaveChanges();
        //        if (result.Succeeded == false)
        //        {
        //            throw new Exception(result.Message);
        //        }
        //        return model;
        //    });
        //}
        public Operation<CyberModel[]> GetCybers()
        {
            return Operation.Create(() =>
            {

                var entities = _context.Cybers.ToList();

                var models = entities.Select(e => new CyberModel(e)
                {
                    Higher = new HigherInstitutionModel(),
                    Course = new CourseOfStudyModel(),
                    State = new StateModel(),
                    User = new ApplicationUser(),
                     Address = e.Address,
                      ClassOfDigree = e.ClassOfDigree,
                       Contact = e.Contact,
                         YearOfGraduation = e.YearOfGraduation,
                     
                           CreatedBy = e.CreatedBy,
                            DateOfBirth = e.DateOfBirth,
                             Email = e.Email,
                              CourseId = e.CourseId,
                                FirstName = e.FirstName,
                                 Gender = e.Gender,
                                  HigherId =  e.HigherId,
                                   LastName = e.LastName,
                                    NYSC_upload = e.NYSC_upload,
                                     OtherNames = e.OtherNames,
                                      //SchoolAttended =e.SchoolAttended,
                                       StateId = e.StateId,
                                 
                                         
                }
                ).ToArray();
                return models;
            });
        }
        public Operation<HigherInstitutionModel[]> GetHigher_Insts()
        {
            return Operation.Create(() =>
            {
                var entities = _context.HigherInstitutions.ToList();

                var models = entities.Select(e => new HigherInstitutionModel(e)
                {
                    Instit_Name = e.Instit_Name  
            }
                   ).ToArray();

                return models;
            });
        }

        public int CreateHigherInstituion(string name) { 


            var isExist = _context.HigherInstitutions.Where(e => e.Instit_Name == name).FirstOrDefault();
            if (isExist != null) throw new Exception("Instistion already exist");

            var entity = new HigherInstitution { Instit_Name = name,  HigherId = 0};

            _context.HigherInstitutions.Add(entity);

            var higherInstitutionId = _context.SaveChanges();
            return entity.HigherId;
        }

        public int CreateCourse(string name)
        {


            var isExist = _context.CourseOfStudies.Where(e => e.Course_Name == name).FirstOrDefault();
            if (isExist != null) throw new Exception("course already exist");

            var entity = new CourseOfStudy { Course_Name = name, CourseId = 0 };

            _context.CourseOfStudies.Add(entity);

            var higherInstitutionId = _context.SaveChanges();
            return entity.CourseId;
        }

        public Operation<CourseOfStudyModel[]> GetCourseOfdies()
        {
            return Operation.Create(() =>
            {
                var entities = _context.CourseOfStudies.ToList();

            var models = entities.Select(e => new CourseOfStudyModel(e)
            {
                Course_Name = e.Course_Name
            }
                ).ToArray();
            return models;
        });
        }
        public Operation<StateModel[]> GetStates()
        {
            return Operation.Create(() =>
            {
                var entities = _context.States.ToList();

            var models = entities.Select(e => new StateModel(e)
            {
                 State_Name = e.State_Name
            }
             ).ToArray();
                return models;
            });
        }
        public Operation<CyberModel> GetCyberById(int cyberId)
        {
            return Operation.Create(() =>
            {
                var entity = _context.Cybers.Where(e => e.CyberId == cyberId).FirstOrDefault();
                if (entity == null) throw new Exception("employee is not valid ");
                return new CyberModel(entity);
            });
        }
        public Operation DeleteCyber(int id)
        {
            return Operation.Create(() =>
            {
                var entity = _context.Cybers.Where(e => e.CyberId == id).FirstOrDefault();
                if (entity == null) throw new Exception("employee does not exist");

                _context.Cybers.Remove(entity);
                _context.SaveChanges();
            });
        }


    }
}