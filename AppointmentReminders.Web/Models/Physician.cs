using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentReminders.Web.Models
{
    public class Physician
    {
        public int PhysicianId { get; set; }

        [Required]
        public string PhysicianName { get; set; }

        public virtual List<Appointment> Appointment { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        public int OperationCenterId { get; set; }
        public virtual OperationCenter OperationCenter { get; set; }

        public int Active { get; set; }

    }
}
