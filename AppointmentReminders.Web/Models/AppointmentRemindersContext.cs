using System.Data.Entity;

namespace AppointmentReminders.Web.Models
{
    public class AppointmentRemindersContext : DbContext
    {
        public AppointmentRemindersContext()
            : base("DefaultConnection")
        {
        }

        
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Custumer> Custumers { get; set; }
        public DbSet<OperationCenter>OperationCenters{get;set;}
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }

    }
}