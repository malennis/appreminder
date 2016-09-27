namespace AppointmentReminders.Web.Migrations
{
    using AppointmentReminders.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppointmentReminders.Web.Models.AppointmentRemindersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppointmentReminders.Web.Models.AppointmentRemindersContext context)
        {
              //This method will be called after migrating to the latest version.

              //You can use the DbSet<T>.AddOrUpdate() helper extension method 
              //to avoid creating duplicate seed data. E.g.

            //context.OperationCenters.AddOrUpdate(
            //  p => p.OperationCenterName,
            //  new OperationCenter
            //  {
            //      OperationCenterName = "Medica Del Mar",
            //      OperationCenterType = "Centro Medico",
            //      Active = 1
            //  });

            //context.Physicians.AddOrUpdate(
            //    p => p.PhysicianName,
            //    new Physician
            //    {
            //        PhysicianName = "Dra. Graciela Varela",
            //        Active = 1,
            //        OperationCenterId = 1,
            //        CreatedAt = DateTime.Now
            //    });

            //context.Physicians.AddOrUpdate(
            //   p => p.PhysicianName,
            //   new Physician
            //   {
            //       PhysicianName = "Dra. Velazquez",
            //       Active = 1,
            //       OperationCenterId = 1,
            //       CreatedAt = DateTime.Now
            //   });
            //context.Custumers.AddOrUpdate(
            //p => p.Name,
            //new Custumer
            //{
            //    Name = "Rodolfo Solano",
            //    CountryCode = "+1",
            //    Active = 1,
            //    PhoneNumber = "5044052473",
            //    CreatedAt = DateTime.Now,
            //    OperationCenterId = 1

            //});

            //context.Assistants.AddOrUpdate(
            //    p => p.AsistantName,
            //    new Assistant
            //    {
            //        AsistantName = "Luna Manri",
            //        OperationCenterId = 1,
            //        CreatedAt = DateTime.Now,
            //        AsistantUser = "lau",
            //        AsistantPassword = "Pass",
            //        Active = 1
            //    });

            //context.CountryCodes.AddOrUpdate(c => c.Country,
            //    new CountryCode
            //    {
            //        Country = "Mexico",
            //        Code = "+521"

            //    },
            //     new CountryCode
            //     {
            //         Country = "USA",
            //         Code = "+1"
            //     }
            //    );
            
        }
    }
}
