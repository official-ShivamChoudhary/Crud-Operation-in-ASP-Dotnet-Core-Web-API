using DoctorPatientProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DoctorPatientProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        
        {
        
         
        }


        public DbSet<Patient> patients { get; set; }

    }
}
