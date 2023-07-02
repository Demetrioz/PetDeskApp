namespace PetDeskApp.Api.DTOs
{
    public class AppointmentSummary
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTimeOffset Date { get; set; }
        public bool? IsConfirmed { get; set; }
        public string PetParent { get; set; }
        public string Pet { get; set; }
        public string Breed { get; set; }
    }
}
