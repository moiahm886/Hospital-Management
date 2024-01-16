using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management.Controllers;
using Hospital_Management.Data;

namespace Hospital_Management.Test
{
    [TestFixture]
    public class PatientControllerTest
    {
        private ManagementDataContextClass? managementDataContextClass;
        private PatientController controller;

        [SetUp]
        public void Setup()
        {
            controller = new PatientController(managementDataContextClass);
        }

        [Test]
        public void ViewAppointments_ReturnsViewResult()
        {
            var result = controller.ViewAppointments();
            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.Equals("ViewAppointments", viewResult.ViewName);
        }

        [Test]
        public void ViewDetail_ReturnsViewResult()
        {
            var result = controller.ViewDetail();
            Assert.That(result, Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.Equals("ViewDetail", viewResult.ViewName);
        }
    }
}
