using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Ajax.Utilities;

namespace AppointmentReminders.Web.Models
{
    public class Appointment
    {
        public static int ReminderTimeMin = 30;
        public static int ReminderTimeHrs = 24;

        public int Id { get; set; }

        public int OperationCenterId{get;set;}
        public virtual OperationCenter OperationCenter{get;set;}

       // [Required]
        public string Name { get; set; }

        
        [ Phone, Display(Name = "Phone number")]
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        //[StringLength(13, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        public int CustomerId { get; set; }
        public virtual Custumer Customer { get; set; }


        //[Required]
        [DateGreaterThan("Timezone", "Date cannot  be in the past")]
        public DateTime Time { get; set; }

      //  [Required]
        public string Timezone { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }
        
        
      //  [Required]
        public int PhysicianId { get; set; }
        public virtual Physician Physician { get; set; }

        public string CountryCode { get; set; }

        public string Status { get; set; }

        public int NumOfNotifications { get; set; }

      
    }

    public enum Status
    {
        tomorrow,
        today,
        unknown

    }
}