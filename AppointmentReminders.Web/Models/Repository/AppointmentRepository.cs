using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AppointmentReminders.Web.Models.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentRemindersContext _context = new AppointmentRemindersContext();

        public void Create(Appointment appointment)
        {
            if (appointment.CustomerId == 0)
            {
                var x = new Custumer();
                x.Name = appointment.Name;
                x.PhoneNumber = appointment.PhoneNumber;
                x.CountryCode = appointment.CountryCode;
                x.CreatedAt = DateTime.Now;
                x.OperationCenterId = appointment.OperationCenterId;
                x.Active = 1;

                x = _context.Custumers.Add(x);
                _context.SaveChanges();
                appointment.CustomerId = x.CustumerId;
            }    
                appointment.Status = "Pending";

                _context.Appointments.Add(appointment);
                _context.SaveChanges();
        
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Attach(appointment);
            _context.Entry(appointment).State = EntityState.Unchanged;
            _context.Entry(appointment).Property(model => model.CreatedAt).IsModified = false;
         
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointment = FindById(id);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public Appointment FindById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> FindAll()
        {
            return _context.Appointments.Where(x => x.Status == "Pending").ToList();
        }


        public Custumer FindCustomerByPhoneNumber(string phoneNumber)
        {

         return   _context.Custumers.Where(x => x.PhoneNumber.Equals(phoneNumber)).FirstOrDefault();
            //throw new System.NotImplementedException();
        }

        public IEnumerable<Physician> FindAllPhysicianByOC(int operationCenter)
        {
            return _context.Physicians.Where(x => x.OperationCenterId == operationCenter).ToList();
            //throw new System.NotImplementedException();
        }

        public Assistant FindAssistantByUserPassword(string user, string pass) 
        {
            return  _context.Assistants.Where(x=>x.AsistantPassword==pass && x.AsistantUser==user).FirstOrDefault();
        }


        public IEnumerable<CountryCode> GetAllCountriesCodes()
        {
            return _context.CountryCodes.ToList();
        }


        public IEnumerable<Appointment> FindAllByOperationCenter(int operationCenter)
        {
            return _context.Appointments.Where(x => x.OperationCenterId == operationCenter && x.Status == "Pending").ToList();
        }
    }
}