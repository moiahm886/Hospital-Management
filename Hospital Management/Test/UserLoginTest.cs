using System;
using System.Threading.Tasks;
using Hospital_Management.Controllers;
using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Hospital_Management.Test
{
    public class UserControllerTests
    {
        private ManagementDataContextClass managementDataContextClass;
        private UserController userController;

        [SetUp]
        public void Setup()
        {
            managementDataContextClass = new ManagementDataContextClass(new DbContextOptions<ManagementDataContextClass>());
            userController = new UserController(managementDataContextClass);
        }

        [Test]
        public async Task ManageLogin_AdminCredentials_RedirectsToAdminDashboard()
        {
            var adminCredentials = new User { Username = "Admin", Password = "Admin" };
            var result = await userController.ManageLogin(adminCredentials) as RedirectToActionResult;

            Assert.Equals("AdminDashboard", result?.ActionName);
            Assert.Equals("Admin", result?.ControllerName);
        }

        [Test]
        public async Task ManageLogin_InvalidCredentials_ReturnsLoginView()
        {
            var invalidCredentials = new User { Username = "InvalidUsername", Password = "InvalidPassword" };

            var mockDbSet = new Mock<DbSet<User>>();
            mockDbSet.Setup(d => d.FindAsync(It.IsAny<object[]>()));
            var mockDbContext = new Mock<ManagementDataContextClass>();
            mockDbContext.Setup(c => c.tbUser).Returns(mockDbSet.Object);
            using (var context = new ManagementDataContextClass(new DbContextOptions<ManagementDataContextClass>()))
            {
                context.tbUser.Add(new User { Username = "DifferentUsername", Password = "DifferentPassword", Role = "SomeRole" });
                await context.SaveChangesAsync();
            }
            var result = await userController.ManageLogin(invalidCredentials) as ViewResult;
            Assert.Equals("LoginPage", result?.ViewName);
            Assert.Equals("Incorrect Username or Password", result?.ViewData["LoginResult"]);
        }
    }
}
