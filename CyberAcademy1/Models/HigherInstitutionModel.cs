using CyberAcademy1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Models
{
    public class HigherInstitutionModel
    {
        public int HigherId { get; set; }
        public string Instit_Name { get; set; }

        public virtual ICollection<CyberModel> Cyberses { get; set; }
        public HigherInstitutionModel()
        {
            new HashSet<CyberModel>();

        }
        public HigherInstitutionModel(HigherInstitution higher)
        {
            this.Assign(higher);
            new HashSet<CyberModel>();
        }
        public HigherInstitution Create(HigherInstitutionModel model)
        {
            return new HigherInstitution
            {
                Instit_Name = model.Instit_Name
            };
        }
    }
}