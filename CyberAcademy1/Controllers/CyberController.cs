using CyberAcademy1.Entities;
using CyberAcademy1.Interface;
using CyberAcademy1.Models;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace CyberAcademy1.Controllers
{
//    [Authorize]
    public class CyberController : Controller
    {
        private ICyberManager _cybMgr;
        private ApplicationDbContext context = new ApplicationDbContext();

        public CyberController(ICyberManager cybMgr)
        {
            _cybMgr = cybMgr;
          
        }
        // GET: Employee
        public ActionResult Index()
        {
            //was added to pass the data direct
            ViewBag.Profile = context.Cybers.ToList();

            if (TempData["message"] != null)
            {
                ViewBag.Sucess = (string)TempData["message"];
            }
            var models = _cybMgr.GetCybers();
            if (models.Succeeded == true)
            {
                return View(models.Unwrap().ToList());
            }
            else
            {
                ModelState.AddModelError(string.Empty, "an error occure");
                return View();
            }

        }
        //[Authorize(Roles = "Admin")]
       



        [HttpPost]
        public ActionResult PreviewDocument(int id)
        {
            var model =  _cybMgr.GetCyberById(id);
            
            return PartialView("PreviewDocument", model);

        }
       
        public ActionResult Preview(int id)
        {
            var model = _cybMgr.GetCyberById(id);

            return PartialView("Preview", model.Unwrap());

        }

        public async Task<FileResult> DownloadImage(int id)
        {
            var model = _cybMgr.GetCyberById(id).Result;
            string filepath = "~/uploads/";
            int cyberId = model.CyberId;
            String FileName = model.NYSCFileName;
            //filepath = filepath + @Model.NYSC_upload;
            filepath = filepath + cyberId + "_" + model.NYSCFileName;
            return File(filepath, model.ContentType, model.NYSCFileName
                );
        }


        [HttpGet]
        public ActionResult CreateCyber()
        {
            ViewBag.higher_inst = new SelectList(_cybMgr.GetHigher_Insts().Result, "HigherId", "Instit_Name");
            ViewBag.courseOfdies = new SelectList(_cybMgr.GetCourseOfdies().Result, "CourseId", "Course_Name");
            ViewBag.states = new SelectList(_cybMgr.GetStates().Result, "StateId", "State_Name");
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateCyber(CyberModel model, HttpPostedFileBase file)
        {
                 ViewBag.higher_inst = new SelectList(_cybMgr.GetHigher_Insts().Result, "HigherId", "Instit_Name");
                    ViewBag.courseOfdies = new SelectList(_cybMgr.GetCourseOfdies().Result, "CourseId", "Course_Name");
                    ViewBag.states = new SelectList(_cybMgr.GetStates().Result, "StateId", "State_Name");

            var cyberModel = new Operation<CyberModel>();
            int age = 0;
            DateTime currentDate = DateTime.Now;
            DateTime dob = Convert.ToDateTime(model.DateOfBirth);
            age = (currentDate.Year) - (dob.Year);
            model.Age
                = age;

            if (ModelState.IsValid)
            {
                try
                {

                    //  ViewBag.Name = new SelectList(_userMgr.GetRoles().Result, "RoleId", "RoleName");


                    if(model.NewCourse != null)
                    {
                        model.CourseId = _cybMgr.CreateCourse(model.NewCourse);
                    }

                    if (model.NewHigher != null)
                    {
                        model.HigherId = _cybMgr.CreateHigherInstituion(model.NewHigher);
                    }


                    String FileName = "";
                    if (file.ContentLength > 0)
                    {
                        string Userid = (model.UserId);
                        FileName = Path.GetFileName(file.FileName);
                       
                    }

                    int cyberId = 0;
                    model.CreatedBy = User.Identity.GetUserName();
                    model.NYSCFileName = FileName;
                    model.ContentType = file.ContentType;
                    var result = _cybMgr.CreateCyber(model, ref cyberId);

                    if (file.ContentLength > 0)
                    {                        
                        var path = Path.Combine(Server.MapPath("~/uploads"), cyberId + "_" + FileName);
                        file.SaveAs(path);
                    }
            
                    cyberModel.Succeeded = true;

                    if (cyberModel.Succeeded == true)
                    {
                        ModelState.Clear();
                        ViewBag.Message = $" application{ ""} was successfully";
                        return View();
                      //  return RedirectToAction("Index");
                    }
                    //ModelState.AddModelError(string.Empty, result.Message);
                    //ViewBag.Error = $"Error occured : {result.Message}";
                }

                catch (Exception xe)
                {
                    throw xe;
                }
            }
            return View(model);

        }
        public ActionResult Export()
        {
            //ViewBag.Profile = context.Cybers.ToList();
            var list = context.Cybers.ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "FirstName";
            ws.Cells["B1"].Value = " LastName";
            ws.Cells["C1"].Value = "OtherNames";
            ws.Cells["D1"].Value = "Gender";
            ws.Cells["E1"].Value = "DateOfBirth";
            ws.Cells["F1"].Value = "Address ";
            ws.Cells["G1"].Value = "Email";
            ws.Cells["H1"].Value = "Higher";
            ws.Cells["I1"].Value = "Course";
            ws.Cells["J1"].Value = "ClassOfDigree";
            ws.Cells["k1"].Value = "Qualification";
            ws.Cells["L1"].Value = "YearOfGraduation";
            ws.Cells["M1"].Value = "NYSCCertificate";
            ws.Cells["N1"].Value = "Age";
            ws.Cells["O1"].Value = "State";
            ws.Cells["P1"].Value = "Contact";
          
      

            int rowStart = 2;
            foreach (var item in list)
            {
                //converting expireddate format to string 
                //  var stringDate = item.ExpiringDate;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.FirstName;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.LastName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.OtherNames;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Gender;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.DateOfBirth.ToString();
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Address;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Email;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.HigherInstitution.Instit_Name;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Course.Course_Name;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.ClassOfDigree;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.Qualification;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.YearOfGraduation;
                ws.Cells[string.Format("M{0}", rowStart)].Value = item.NYSCFileName.ToString();
                ws.Cells[string.Format("N{0}", rowStart)].Value = item.Age;
                ws.Cells[string.Format("O{0}", rowStart)].Value = item.State.State_Name;
                ws.Cells[string.Format("P{0}", rowStart)].Value = item.Contact;
           
          

                rowStart++;
            }

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

            return RedirectToAction("Index");


        }
        //[HttpGet]
        //public ActionResult EditCyber(int id = 0)
        //{
        //    var result = _cybMgr.GetCyberById(id);
        //    if (result.Succeeded == true)
        //    {
        //        return View(result.Message);
        //    }
        //    ModelState.AddModelError(string.Empty, result.Message);
        //    return View();
        //}


        //[HttpGet]
        //public ActionResult EditRating(int id = 0)
        //{
        //    var result = _ratMgr.GetRatingById(id);
        //    if (result.Succeeded == true)
        //    {
        //        return View(result.Result);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, result.Message);
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public ActionResult EditRating(CyberModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.ModifiedBy = User.Identity.GetUserId();
        //        var result = _cybMgr.UpdateCyber(model);
        //        if (result.Succeeded == true)
        //        {
        //            TempData["message"] = $"Rating{model.RatId} was successfully added!";
        //            ModelState.AddModelError(string.Empty, "Update was successfully ");
        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError(string.Empty, result.Message);
        //        ViewBag.Error = $"Error occured : {result.Message}";
        //        return View(model);
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}

        [HttpPost]
        public JsonResult DeleteCyber(int id, string ratName)
        {
            int ratId = Convert.ToInt32(id);
            if (ratId > 0)
            {
                var result = _cybMgr.DeleteCyber(ratId);
                if (result.Succeeded == true)
                {

                    return Json(new { status = true, message = $" {ratName} has been successfully deleted!", JsonRequestBehavior.AllowGet });
                }
                return Json(new { status = false, error = result.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = false, error = "Invalid Id" }, JsonRequestBehavior.AllowGet);
        }
        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public ActionResult EditCyber(CyberModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.ModifiedBy = User.Identity.GetUserName();
        //        var result = _cybMgr.UpdateCyber(model);
        //        if (result.Succeeded == true)
        //        {
        //            TempData["message"] = $"Employee{model.CyberId} was successfully added";
        //            ModelState.AddModelError(string.Empty, "Update was successful ");
        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError(string.Empty, result.Message);
        //        ViewBag.Error = $"an error ocure : {result.Message}";
        //        return View(model);
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}



    }
}