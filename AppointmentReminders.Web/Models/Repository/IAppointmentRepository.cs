using System.Collections.Generic;

namespace AppointmentReminders.Web.Models.Repository
{
    public interface IAppointmentRepository
    {
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(int id);
        void UpdateStatusOnly(Appointment appointment);
        Appointment FindById(int id);
        IEnumerable<Appointment> FindAll();

        IEnumerable<Appointment> FindAllByOperationCenter(int operationCenter);


        Custumer FindCustomerByPhoneNumber(string phoneNumber);

        IEnumerable<Physician> FindAllPhysicianByOC(int operationCenter);

        Assistant FindAssistantByUserPassword(string user, string pass);

        IEnumerable<CountryCode> GetAllCountriesCodes();
    }
}
