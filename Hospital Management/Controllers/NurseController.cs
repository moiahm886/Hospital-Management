using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Controllers
{
    public class NurseController : Controller
    {
        private readonly ManagementDataContextClass managementDataContextClass;

        public NurseController(ManagementDataContextClass managementDataContextClass)
        {
            this.managementDataContextClass = managementDataContextClass;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NurseDashboard(int ID)
        {
            HttpContext.Session.SetInt32("NurseId", ID);
            ViewData["Authorized"] = "Nurse";
            return View();  
        }
        public async Task<IActionResult> AddPrescription()
        {
            ViewBag.Doctors = await managementDataContextClass.tbDoctor.ToListAsync();
            ViewBag.Patients = await managementDataContextClass.tbPatient.ToListAsync();
            ViewData["Authorized"] = "Nurse";
            return View();
        }
        public async Task<IActionResult> PrescriptionAdded(Prescription prescription)
        {
            Prescription prescription1 = new Prescription()
            {
                PrescriptionId = prescription.PrescriptionId,
                DoctorId = prescription.DoctorId,
                PatientId = prescription.PatientId,
                DatePrescribed = prescription.DatePrescribed,
                Medications = prescription.Medications,
                DosageInstructions = prescription.DosageInstructions
            };
            await managementDataContextClass.tbPrescription.AddAsync(prescription1);
            await managementDataContextClass.SaveChangesAsync();
            ViewData["Authorized"] = "Nurse";
            return View("ViewPrescription");
        }
        public async Task<IActionResult> ViewPrescription()
        {
            var prescription = await managementDataContextClass.tbPrescription.ToListAsync();
            ViewData["Authorized"] = "Nurse";
            return View(prescription);
        }
        public async Task<IActionResult> ViewAppointment()
        {
            var appointments = await managementDataContextClass.tbAppointment.ToListAsync();
            ViewData["Authorized"] = "Nurse";
            return View(appointments);
        }
        public async Task<IActionResult> ViewDetail()
        {
            int? ID = HttpContext.Session.GetInt32("NurseId");
            var nurse = await managementDataContextClass.tbNurse.FirstOrDefaultAsync(u => u.NurseId == ID);
            ViewData["Authorized"] = "Nurse";
            return View(nurse);
        }
        public IActionResult Logout()
        {
            return RedirectToAction("LoginPage", "User");
        }
    }
}
