using CyberAcademy1.Entities;
using CyberAcademy1.Interface;
using CyberAcademy1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Infrastructure
{
    public class DataAccess : NinjectModule
    {
        public override void Load()
        {

            Bind<DbContext>().ToMethod(ctx => ApplicationDbContext.Create()).InRequestScope();
            Bind<ApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
            Bind<IDataRepository>().To<EntityRepository>().InRequestScope();
            Bind<ApplicationSignInManager>().To<ApplicationSignInManager>().InRequestScope();
            //Bind<ApplicationUserManager>().To < ApplicationUserManager().InRequestScope();

            // Bind<IVoterManager>().To<VoterManager>();

            Bind<UserManager<ApplicationUser>>().ToSelf();
            Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            //Kernel.Bind<ApplicationUserManager>().ToSelf();

            //Bind<ApplicationSignInManager>().ToMethod((context) =>
            //{
            //    var cbase = new HttpContextWrapper(HttpContext.Current);
            //    return cbase.GetOwinContext().Get<ApplicationSignInManager>();
            //});


            
        }
    }
}