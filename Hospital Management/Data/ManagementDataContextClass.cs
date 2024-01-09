using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Data
{
    public class ManagementDataContextClass:DbContext 
    {
        public ManagementDataContextClass(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User>tbUser { get; set; }
        public DbSet<Appointment> tbAppointment { get; set; }
        public DbSet<Doctor> tbDoctor { get; set; }
        public DbSet<Message> tbMessage { get; set; }
        public DbSet<Nurse> tbNurse { get; set; }
        public DbSet<Patient> tbPatient { get; set; }
        public DbSet<Prescription> tbPrescription { get; set; }
        public DbSet<Receptionist> tbReceptionist { get; set; }

    }

}
