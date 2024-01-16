using System;
using System.ComponentModel.DataAnnotations;
using Hospital_Management.Models;
using NUnit.Framework;

namespace Hospital_Management.Test
{
    public class PatientModelTest
    {
        [Test]
        public void PatientModel_PropertiesAreSetCorrectly()
        {
            var patient = new Patient
            {
                PatientId = 1,
                UserId = 1001,
                Name = "John Doe",
                DateOfBirth = new DateTime(1990, 5, 15),
                ContactNumber = "123-456-7890",
                Email = "john.doe@example.com",
                Address = "123 Main Street"
            };

            Assert.Equals(1, patient.PatientId);
            Assert.Equals(1001, patient.UserId);
            Assert.Equals("John Doe", patient.Name);
            Assert.Equals(new DateTime(1990, 5, 15), patient.DateOfBirth);
            Assert.Equals("123-456-7890", patient.ContactNumber);
            Assert.Equals("john.doe@example.com", patient.Email);
            Assert.Equals("123 Main Street", patient.Address);
        }

        [Test]
        public void PatientModel_Validation_Successful()
        {
            var patient = new Patient
            {
                PatientId = 1,
                UserId = 1001,
                Name = "John Doe",
                DateOfBirth = new DateTime(1990, 5, 15),
                ContactNumber = "123-456-7890",
                Email = "john.doe@example.com",
                Address = "123 Main Street"
            };

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(patient);
            var validationResult = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = Validator.TryValidateObject(patient, validationContext, validationResult, true);

            Assert.Equals(isValid,"true");
            Assert.Equals(validationResult, "true");
        }
    }
}
