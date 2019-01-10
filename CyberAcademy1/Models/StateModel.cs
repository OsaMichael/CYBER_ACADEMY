using CyberAcademy1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberAcademy1.Models
{
    public class StateModel
    {
        public int StateId { get; set; }
        public string State_Name { get; set; }

        public virtual ICollection<CyberModel> Cyberses { get; set; }


        public StateModel()
        {
            new HashSet<CyberModel>();
        }
        public StateModel(State course)
        {
            this.Assign(course);
            new HashSet<CyberModel>();
        }
        public State Create(StateModel model)
        {
            return new State
            {
                State_Name = model.State_Name
            };
        }
    }
}