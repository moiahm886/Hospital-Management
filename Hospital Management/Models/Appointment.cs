using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Purpose { get; set; }
    }
}
