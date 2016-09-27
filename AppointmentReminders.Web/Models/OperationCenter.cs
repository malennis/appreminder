using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentReminders.Web.Models
{
   public class OperationCenter
    {
       
       public int OperationCenterId { get; set; }
       
       public string OperationCenterName{get;set;}

       public string OperationCenterType { get; set; }

       public int Active { get; set; }

       public virtual List<Appointment> Appointment { get; set; }
       public virtual List<Custumer> Custumer { get; set; }
       public virtual List<Physician> Physician { get; set; }

       public virtual List<Assistant> Assistant { get; set; }
    }
}
