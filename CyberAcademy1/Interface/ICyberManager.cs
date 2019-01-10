using CyberAcademy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Interface
{
    public interface ICyberManager
    {
        // Operation<CyberModel> CreateCyber(CyberModel model);
        bool CreateCyber(CyberModel model, ref int cyberid);
        Operation<CyberModel[]> GetCybers();
        Operation<HigherInstitutionModel[]> GetHigher_Insts();
        Operation<CourseOfStudyModel[]> GetCourseOfdies();
        Operation<StateModel[]> GetStates();
        Operation<CyberModel> GetCyberById(int cyberId);
        Operation DeleteCyber(int id);
    }
}