using Microsoft.EntityFrameworkCore;
using PetDeskApp.Data.Entities;

namespace PetDeskApp.Data.Context
{
    public class PetDeskContext : DbContext
    {
        public PetDeskContext(DbContextOptions<PetDeskContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
