using PetDeskApp.Data.Entities;

namespace PetDeskApp.Services.ApiService.AppointmentApiService
{
    public interface IAppointmentApiService : IApiService
    {
        Task<IEnumerable<Appointment>> RetrieveAppointments();
    }
}
