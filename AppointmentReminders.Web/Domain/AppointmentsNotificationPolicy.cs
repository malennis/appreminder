using System;
using AppointmentReminders.Web.Models;

namespace AppointmentReminders.Web.Domain
{
    public class AppointmentsNotificationPolicy
    {
        private readonly Appointment _appointment;
        private readonly ITimeConverter _timeConverter;

        public AppointmentsNotificationPolicy(Appointment appointment, ITimeConverter timeConverter)
        {
            _appointment = appointment;
            _timeConverter = timeConverter;
        }

        public bool NeedsToBeSent(DateTime currentTime)
        {
            //_appointment.Status!=                                // Notify our appointment attendee
            var reminderLocalTime01 = GetAppointmentLocalTime()    
                .AddMinutes(-Appointment.ReminderTimeMin);         // X minutes before the appointment time

            var reminderLocalTime02 = GetAppointmentLocalTime()
               .AddHours(-Appointment.ReminderTimeHrs);            // X Hrs before the appointment time
                                                         

            return currentTime.ToString("MM/dd/yyyy HH:mm") == reminderLocalTime01.ToString("MM/dd/yyyy HH:mm")||
                   currentTime.ToString("MM/dd/yyyy HH:mm") == reminderLocalTime02.ToString("MM/dd/yyyy HH:mm");
            
            
        }


        public Status StatusToBeChange(DateTime currentTime)
        {
            
            // Notify our appointment attendee
            var reminderLocalTime02 = GetAppointmentLocalTime()
                .AddMinutes(-Appointment.ReminderTimeMin);         // X minutes before the appointment time

            var reminderLocalTime01 = GetAppointmentLocalTime()
               .AddHours(-Appointment.ReminderTimeHrs);            // X Hrs before the appointment time


        //    currentTime.ToString("MM/dd/yyyy HH:mm") == reminderLocalTime01.ToString("MM/dd/yyyy HH:mm") ||

                var endCurrentTime = reminderLocalTime01.AddMinutes(5);
                var startCurrentTime = reminderLocalTime01.Subtract(TimeSpan.FromMinutes(5));

                if (currentTime >= startCurrentTime && currentTime <= endCurrentTime)// 
                    return Status.tomorrow;//"1Reminder";
                else


                    endCurrentTime = reminderLocalTime02.AddMinutes(5);
                 startCurrentTime = reminderLocalTime02.Subtract(TimeSpan.FromMinutes(5));

                 if (currentTime >= startCurrentTime && currentTime <= endCurrentTime)// 
                     return Status.today;
                 else
                     return Status.unknown;

        }
        private DateTime GetAppointmentLocalTime()
        {
            return _timeConverter.ToLocalTime(_appointment.Time, _appointment.Timezone);
        }
    }


    public class AppointmentsStatusChangePolicy
    {
        private readonly Appointment _appointment;

        public AppointmentsStatusChangePolicy(Appointment appointment, string status)
        {
            _appointment = appointment;
        
        }
    }
}