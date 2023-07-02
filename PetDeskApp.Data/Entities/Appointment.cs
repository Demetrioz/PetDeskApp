using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetDeskApp.Data.Entities
{
    [Table(nameof(Appointment))]
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string AppointmentType { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTimeOffset RequestedDateTimeOffset { get; set; }

        [JsonProperty("user_UserId")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [JsonProperty("animal_AnimalId")]
        public int AnimalId { get; set; }
        [ForeignKey(nameof(AnimalId))]
        public Animal? Animal { get; set; }

        public bool? IsConfirmed { get; set; }
    }
}
