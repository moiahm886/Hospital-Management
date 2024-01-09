using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public  int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
