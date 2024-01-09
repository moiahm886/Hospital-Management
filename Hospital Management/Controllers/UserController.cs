using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Controllers
{
    public class UserController : Controller
    {
        private readonly ManagementDataContextClass managementDataContextClass;

        public UserController(ManagementDataContextClass managementDataContextClass)
        {
            this.managementDataContextClass = managementDataContextClass;
        }

        public IActionResult LoginPage()
        {
            return View();
        }
        public async Task<IActionResult> ManageLogin(User user) {
            var user1 = await managementDataContextClass.tbUser.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (user.Username == "Admin" && user.Password == "Admin")
            {
                return RedirectToAction("AdminDashboard", "Admin");
            }
            else
            {
                if(user.Password != user1.Password)
                {
                    ViewData["LoginResult"] = "Incorrect Username or Password";
                    return RedirectToAction("LoginPage");
                }
                else
                {
                    if (user1.Role == "Doctor")
                    {
                        var doctor = await managementDataContextClass.tbDoctor.FirstOrDefaultAsync(u => u.UserId == user1.UserId);
                        return RedirectToAction("DoctorDashboard", "Doctor", new { ID = doctor.DoctorId });
                    }
                    else if(user1.Role == "Nurse")
                    {
                        var nurse = await managementDataContextClass.tbNurse.FirstOrDefaultAsync(u => u.UserId == user1.UserId);
                        return RedirectToAction("NurseDashboard", "Nurse", new { ID = nurse.NurseId });
                    }
                    else if (user1.Role == "Patient")
                    {
                        var patient = await managementDataContextClass.tbPatient.FirstOrDefaultAsync(u => u.UserId == user1.UserId);
                        return RedirectToAction("PatientDashboard", "Patient", new {ID = patient.PatientId});
                    }
                    else
                    {
                        var receptionist = await managementDataContextClass.tbReceptionist.FirstOrDefaultAsync(u => u.UserId == user1.UserId);
                        return RedirectToAction("ReceptionistDashboard", "Receptionist", new { ID = receptionist.ReceptionistId });
                    }
                }
            }
            ViewData["LoginResult"] = "Incorrect Username or Password";
            return View("LoginPage");
        }
        public async Task<IActionResult> Logout()
        {

            return View("LoginPage");
        }
        public IActionResult UserDashboard() {
            return View();
        }
    }
}
