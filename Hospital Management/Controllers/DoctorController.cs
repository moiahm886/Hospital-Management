using Hospital_Management.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ManagementDataContextClass managementDataContextClass;

        public DoctorController(ManagementDataContextClass managementDataContextClass)
        {
            this.managementDataContextClass = managementDataContextClass;
        }

        public IActionResult DoctorDashboard(int ID)
        {
            HttpContext.Session.SetInt32("DoctorId", ID);
            ViewData["Authorized"] = "Doctor";
            return View();
        }
        public async Task<IActionResult> ViewAppointments()
        {
            int? ID = HttpContext.Session.GetInt32("DoctorId");
            var doctor = await managementDataContextClass.tbAppointment.Where(u => u.DoctorId == ID).ToListAsync();
            ViewData["Authorized"] = "Doctor";
            return View(doctor);
        }
        public async Task<IActionResult> ViewPrescriptions()
        {
            int? ID = HttpContext.Session.GetInt32("DoctorId");
            var doctor = await managementDataContextClass.tbPrescription.Where(u => u.DoctorId == ID).ToListAsync();
            ViewData["Authorized"] = "Doctor";
            return View(doctor);
        }
        public async Task<IActionResult> ViewDetail()
        {
            int? ID = HttpContext.Session.GetInt32("DoctorId");
            var doctor = await managementDataContextClass.tbDoctor.FirstOrDefaultAsync(u => u.DoctorId == ID);
            ViewData["Authorized"] = "Doctor";
            return View(doctor);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "User");
        }
    }
}
