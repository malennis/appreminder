using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentReminders.Web.Models
{
    public class Assistant
    {
        public int OperationCenterId { get; set; }
        public virtual OperationCenter OperationCenter { get; set; }

        public int AssistantId { get; set; }

        public string AsistantName { get; set; }
        
        public string AsistantUser { get; set; }
        
        public string AsistantPassword{get;set;}
        public int Active { get; set; }
        
        public DateTime CreatedAt { get; set; }


    }
}
