using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentReminders.Web.Models
{
    public class Custumer
    {
        public int CustumerId { get; set; }
        
        public int OperationCenterId { get; set; }
        public virtual OperationCenter OperationCenter { get; set; }
        
        public int Active { get; set; }
        [Required]
        public string Name { get; set; }

        [Required, Phone, Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        public virtual List<Appointment> Appointment { get; set; }

    }
}
