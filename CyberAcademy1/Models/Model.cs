using OfficeOpenXml.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Web;

namespace CyberAcademy1.Models
{
    public abstract class Model : IValidatableObject
    {
        public virtual void Validate()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            Validator.ValidateObject(this, context, true);
        }
        public virtual IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            return errors;
        }
    }
}