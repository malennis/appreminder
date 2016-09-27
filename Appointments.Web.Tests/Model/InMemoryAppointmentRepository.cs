using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;

namespace Appointments.Web.Tests.Model
{
    public class InMemoryAppointmentRepository : IAppointmentRepository
    {
        private readonly IList<Appointment> _db = new List<Appointment>();

        public void Create(Appointment appointment)
        {
            _db.Add(appointment);
        }

        public void Update(Appointment appointment)
        {

            if (_db.Any(x => x.Id == appointment.Id))
            {
                _db.Remove(FindById(appointment.Id));
                _db.Add(appointment);    
            }
        }

        public void Delete(int id)
        {
            _db.Remove(FindById(id));
        }

        public Appointment FindById(int id)
        {
            return _db.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Appointment> FindAll()
        {
            return _db.ToList();
        }


        public IEnumerable<Appointment> FindAllByOperationCenter(int operationCenter)
        {
            return _db.Where(x => x.OperationCenterId == operationCenter && x.Status == "Pending").ToList();
        }

        public Custumer FindCustomerByPhoneNumber(string phoneNumber)
        {
           //return _db.Where(x=>x.)
            throw new NotImplementedException();
        }

        public IEnumerable<Physician> FindAllPhysicianByOC(int operationCenter)
        {
            throw new NotImplementedException();
        }

        public Assistant FindAssistantByUserPassword(string user, string pass)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryCode> GetAllCountriesCodes()
        {
            throw new NotImplementedException();
        }
    }
}
