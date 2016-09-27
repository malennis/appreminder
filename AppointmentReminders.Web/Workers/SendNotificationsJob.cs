using System;
using System.Collections.Generic;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;
using WebGrease.Css.Extensions;

namespace AppointmentReminders.Web.Workers
{
    public class SendNotificationsJob
    {
        private const string MessageTemplate =
            //"Hi {0}. Just a reminder that you have an appointment  with {1} coming up at {2}.";
            "{0} tu cita con {1}  es {3} {2}.";
        //Your appointment with Dr. Smith is tomorrow @ 4 PM.  Reply with 1 to confirm or 5 to cancel." answers all of these questions, assuming they remember where Dr. Smith's office is.
        public void Execute()
        {
            var twilioRestClient = new Domain.Twilio.RestClient();

            //AvailableAppointments().ForEach(appointment =>
              
            //  twilioRestClient.SendSmsMessage(
            //   appointment.CountryCode+ appointment.PhoneNumber,
            //    string.Format(MessageTemplate, appointment.Name, appointment.Physician.PhysicianName, appointment.Time.ToString("t"))) );

             var appList=AvailableAppointments();

            foreach (var appointment in appList)
            {
                var status = new AppointmentsNotificationPolicy(appointment, new TimeConverter())
                            .StatusToBeChange(DateTime.Now);

                //var value == 1? Status.tomorrow: (value == (int)Status.today? Status.today: );

                string stat = (status == (int)Status.tomorrow ? Status.tomorrow.ToString() : ( status.Equals(Status.today) ? Status.today.ToString():Status.unknown.ToString()));
                    
                

                //    Status.today.ToString());
                
               twilioRestClient.SendSmsMessage(
               appointment.CountryCode+ appointment.PhoneNumber,
               string.Format(MessageTemplate, appointment.Name, appointment.Physician.PhysicianName, appointment.Time.ToString("t"), stat));

              
               ChangeStatus(appointment);
            }

            //AvailableAppointments().ForEach(appointment =>
            //    appointment.Status = twilioRestClient.SendSmsMessage(
            //    appointment.PhoneNumber,
            //    string.Format(MessageTemplate, appointment.Name, appointment.Physician.PhysicianName, appointment.Time.ToString("t"))));
        }

        private static IEnumerable<Appointment> AvailableAppointments()
        {
            return new AppointmentsFinder(new AppointmentRepository(), new TimeConverter())
                .FindAvailableAppointments(DateTime.Now);
        }


        private static bool ChangeStatus(Appointment app)
        {
             new AppointmentsFinder(new AppointmentRepository(), new TimeConverter()).ChangeAppStatus(app, DateTime.Now);

             return true;
        }

    }


   
}