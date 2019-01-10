using CyberAcademy1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberAcademy1.Controllers
{
    public class StateController : Controller
    {

        private ICyberManager _cybMgr;

        public StateController(ICyberManager cybMgr)
        {
            _cybMgr = cybMgr;
        }
        // GET: State
        public ActionResult Index()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Success = (string)TempData["message"];
            }
            var result = _cybMgr.GetStates();
            if (result.Succeeded == true)
            {
                return View(result.Unwrap());
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occure");
                return View();
            }
        }
    }
}