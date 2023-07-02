using System.ComponentModel.DataAnnotations.Schema;

namespace PetDeskApp.Data.Entities
{
    [Table(nameof(User))]
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VetDataId { get; set; }
    }
}
