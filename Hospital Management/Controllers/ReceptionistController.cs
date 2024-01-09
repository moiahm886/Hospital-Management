using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Controllers
{
    public class ReceptionistController : Controller
    {
        private readonly ManagementDataContextClass managementDataContextClass;

        public ReceptionistController(ManagementDataContextClass managementDataContextClass)
        {
            this.managementDataContextClass = managementDataContextClass;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReceptionistDashboard(int ID) {
            HttpContext.Session.SetInt32("ReceptionistId", ID);
            ViewData["Authorized"] = "Receptionist";
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("LoginPage", "User");
        }
        public async Task<IActionResult> AddAppointments() {
            ViewBag.Doctors = await managementDataContextClass.tbDoctor.ToListAsync();
            ViewBag.Patients = await managementDataContextClass.tbPatient.ToListAsync();
            ViewData["Authorized"] = "Receptionist";
            return View();
        }
        public async Task<IActionResult> AppointmentAdded(Appointment appointment)
        {
            Appointment appointment1 = new Appointment
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDateTime = appointment.AppointmentDateTime,
                Purpose = appointment.Purpose
            };
            await managementDataContextClass.tbAppointment.AddAsync(appointment1);
            await managementDataContextClass.SaveChangesAsync();
            ViewBag.Doctors = await managementDataContextClass.tbDoctor.ToListAsync();
            ViewBag.Patients = await managementDataContextClass.tbPatient.ToListAsync();
            ViewData["Authorized"] = "Receptionist";
            return View("AddAppointments");
        }
        public async Task<IActionResult> ViewPrescription()
        {
            var prescription = await managementDataContextClass.tbPrescription.ToListAsync();
            ViewData["Authorized"] = "Receptionist";
            return View(prescription);
        }
        public async Task<IActionResult> ViewAppointments()
        {
            var appointments = await managementDataContextClass.tbAppointment.ToListAsync();
            ViewData["Authorized"] = "Receptionist";
            return View(appointments);
        }
        public async Task<IActionResult> ViewDetail()
        {
            int? ID = HttpContext.Session.GetInt32("ReceptionistId");
            var receptionist = await managementDataContextClass.tbReceptionist.FirstOrDefaultAsync(u => u.ReceptionistId == ID);
            ViewData["Authorized"] = "Doctor";
            return View(receptionist);
        }
    }
}
