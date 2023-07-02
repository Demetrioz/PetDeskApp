using PetDeskApp.Data.Entities;

namespace PetDeskApp.Services.ApiService.AppointmentApiService
{
    public class AppointmentApiService : ApiService, IAppointmentApiService
    {
        public AppointmentApiService(HttpClient httpClient) : base(httpClient) 
        {
            // TODO: Add IOptions / Config and use that
            HttpClient.BaseAddress = new Uri("https://723fac0a-1bff-4a20-bdaa-c625eae11567.mock.pstmn.io");
        }

        public async Task<IEnumerable<Appointment>> RetrieveAppointments()
            => await Request<List<Appointment>>(HttpMethod.Get, "appointments");
    }
}
