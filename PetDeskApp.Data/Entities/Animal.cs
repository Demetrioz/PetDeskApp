using System.ComponentModel.DataAnnotations.Schema;

namespace PetDeskApp.Data.Entities
{
    [Table(nameof(Animal))]
    public class Animal
    {
        public int AnimalId { get; set; }
        public string FirstName { get; set; }
        public string? Species { get; set; }
        public string? Breed { get; set; }
    }
}
