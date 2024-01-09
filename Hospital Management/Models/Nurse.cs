using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class Nurse
    {
        [Key]
        public int NurseId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
