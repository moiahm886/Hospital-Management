using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime DatePrescribed { get; set; }
        public string Medications { get; set; }
        public string DosageInstructions { get; set; }
    }
}
