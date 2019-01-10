using CyberAcademy1.Interface;
using CyberAcademy1.Manager;
using Ninject.Modules;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Infrastructure
{
    public class Manager : NinjectModule
    {
        public override void Load()
        {
            Bind<ICyberManager>().To<CyberManager>();
        }
    }
}