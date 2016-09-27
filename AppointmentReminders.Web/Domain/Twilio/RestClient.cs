using System.Web.Configuration;
using Twilio;

namespace AppointmentReminders.Web.Domain.Twilio
{
    public class RestClient
    {
        private readonly TwilioRestClient _client;

        private readonly string _accountSid = WebConfigurationManager.AppSettings["AccountSid"];
        private readonly string _authToken = WebConfigurationManager.AppSettings["AuthToken"];
        private readonly string _twilioNumber = WebConfigurationManager.AppSettings["TwilioNumber"];

        public RestClient()
        {
            _client = new TwilioRestClient(_accountSid, _authToken);
        }

        public string SendSmsMessage(string phoneNumber, string message)
        {
            string statusCallback=string.Empty;
            
            
                return _client.SendSmsMessage(_twilioNumber, phoneNumber, message,statusCallback).Status;
               
        }
    }



    public enum MessageStatusValues 
    {
        accepted,
        queued,
        sending	,
        sent,
        receiving,
        received,
        delivered,
        undelivered,
        failed

    }
}