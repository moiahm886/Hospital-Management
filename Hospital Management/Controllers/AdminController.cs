using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Controllers
{
    public class AdminController : Controller
    {
        private readonly ManagementDataContextClass managementDataContextClass;

        public AdminController(ManagementDataContextClass managementDataContextClass)
        {
            this.managementDataContextClass = managementDataContextClass;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            ViewData["Authorized"] = "Admin";
            return View();
        }
        public IActionResult AddUser()
        {
            ViewData["Authorized"] = "Admin";
            return View();
        }
        public IActionResult AddDoctor(int UserId)
        {
            ViewData["UserID"] = UserId;
            ViewData["Authorized"] = "Admin";
            return View();
        }
        public IActionResult AddNurse(int UserId)
        {
            ViewData["UserID"] = UserId;
            ViewData["Authorized"] = "Admin";
            return View();
        }
        public async Task<IActionResult> AddPatient(int UserId)
        {
            ViewData["UserID"] = UserId;
            ViewData["Authorized"] = "Admin";
            return View();
        }
        public IActionResult AddReceptionist(int UserId)
        {
            ViewData["UserID"] = UserId;
            ViewData["Authorized"] = "Admin";
            return View();
        }
        public async Task<IActionResult> UserAdded(User user) {
            User user1 = new User()
            {
                Username = user.Username,
                UserId = user.UserId,
                Password = user.Password,
                Role = user.Role,
            };
            await managementDataContextClass.tbUser.AddAsync(user1);
            await managementDataContextClass.SaveChangesAsync();
            if (user.Role == "Doctor")
            {
                return RedirectToAction("AddDoctor", new {UserId = user1.UserId});
            }
            if (user.Role == "Nurse")
            {
                return RedirectToAction("AddNurse", new { UserId = user1.UserId });
            }
            if (user.Role == "Patient")
            {
                return RedirectToAction("AddPatient", new { UserId = user1.UserId });
            }
            if (user.Role == "Receptionist")
            {
                return RedirectToAction("AddReceptionist", new { UserId = user1.UserId });
            }
            ViewData["Authorized"] = "Admin";
            return View("AddUser");
        }
        public async Task<IActionResult> DoctorAdded(Doctor doctor)
        {
            Doctor doctor1 = new Doctor()
            {
                DoctorId = doctor.DoctorId,
                UserId = doctor.UserId,
                Name = doctor.Name,
                DateOfBirth = doctor.DateOfBirth,
                Specialization = doctor.Specialization,
                ContactNumber = doctor.ContactNumber,
                Email = doctor.Email,
            };
            if(doctor1.UserId == 0)
            {
                ViewData["Authorized"] = "Admin";
                return View("AddUser");
            }
            else
            {
                await managementDataContextClass.tbDoctor.AddAsync(doctor1);
                await managementDataContextClass.SaveChangesAsync();
            }
            ViewData["Authorized"] = "Admin";
            return View("AddUser");
        }
        public async Task<IActionResult> NurseAdded(Nurse nurse)
        {
            Nurse nurse1 = new Nurse()
            {
                NurseId = nurse.NurseId,
                UserId = nurse.UserId,
                Name = nurse.Name,
                DateOfBirth= nurse.DateOfBirth,
                Department  = nurse.Department,
                ContactNumber= nurse.ContactNumber,
                Email = nurse.Email
            };
            if (nurse1.UserId == 0)
            {
                ViewData["Authorized"] = "Admin";
                return View("AddUser");
            }
            else
            {
                await managementDataContextClass.tbNurse.AddAsync(nurse1);
                await managementDataContextClass.SaveChangesAsync();
            }
            ViewData["Authorized"] = "Admin";
            return View("AddUser");
        }
        public async Task<IActionResult> ReceptionistAdded(Receptionist receptionist)
        {
            Receptionist receptionist1 = new Receptionist()
            {
                ReceptionistId = receptionist.ReceptionistId,
                UserId = receptionist.UserId,
                Name = receptionist.Name,
                DateOfBirth = receptionist.DateOfBirth,
                ContactNumber   = receptionist.ContactNumber,
                Email = receptionist.Email
            };
            if (receptionist1.UserId == 0)
            {
                ViewData["Authorized"] = "Admin";
                return View("AddUser");
            }
            else
            {
                await managementDataContextClass.tbReceptionist.AddAsync(receptionist1);
                await managementDataContextClass.SaveChangesAsync();
            }
            ViewData["Authorized"] = "Admin";
            return View("AddUser");
        }
        public async Task<IActionResult> PatientAdded(Patient patient)
        {
            Patient patient1 = new Patient()
            {
                PatientId = patient.PatientId,
                UserId  = patient.UserId,
                Name = patient.Name,   
                DateOfBirth = patient.DateOfBirth,
                ContactNumber = patient.ContactNumber,
                Email = patient.Email,
                Address = patient.Address
            };
            if (patient1.UserId == 0)
            {
                ViewData["Authorized"] = "Admin";

                return View("AddUser");
            }
            else
            {
                await managementDataContextClass.tbPatient.AddAsync(patient1);
                await managementDataContextClass.SaveChangesAsync();
            }
            ViewData["Authorized"] = "Admin";
            return View("AddUser");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("LoginPage", "User");
        }
    }
}
