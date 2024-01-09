using Hospital_Management.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Controllers
{
    public class PatientController : Controller
    {
        private readonly ManagementDataContextClass managementDataContextClass;

        public PatientController(ManagementDataContextClass managementDataContextClass)
        {
            this.managementDataContextClass = managementDataContextClass;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientDashboard(int ID)
        {
            HttpContext.Session.SetInt32("PatientId", ID);
            ViewData["Authorized"] = "Patient";
            return View();
        }
        public async Task<IActionResult> ViewAppointments()
        {
            int? ID = HttpContext.Session.GetInt32("PatientId");
            var patient = await managementDataContextClass.tbAppointment.Where(u => u.PatientId == ID).ToListAsync();
            ViewData["Authorized"] = "Patient";
            return View(patient);
        }
        public async Task<IActionResult> ViewPrescriptions()
        {
            int? ID = HttpContext.Session.GetInt32("PatientId");
            var patient = await managementDataContextClass.tbPrescription.Where(u => u.PatientId == ID).ToListAsync();
            ViewData["Authorized"] = "Patient";
            return View(patient);
        }
        public async Task<IActionResult> ViewDetail()
        {
            int? ID = HttpContext.Session.GetInt32("PatientId");
            var patient = await managementDataContextClass.tbPatient.FirstOrDefaultAsync(u => u.PatientId == ID);
            ViewData["Authorized"] = "Patient";
            return View(patient);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "User");
        }
    }
}
