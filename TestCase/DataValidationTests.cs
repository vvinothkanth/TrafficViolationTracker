//-----------------------------------------------
//  Problem Title : Trafic violence
//  Author        : Vinoth Kanth V
//  Date          : 19 / 9 / 2018
//-----------------------------------------------

/// <summary>
///  The Traffic Violation TestCase NameSpace
/// </summary>
namespace TrafficViolationTestCase
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TrafficViolationTrackingSystem;

    /// <summary>
    /// The Data Validation Tests Class
    /// </summary>
    [TestClass]
    public class DataValidationTests
    {
        /// <summary>
        /// To test the IsValidTest() method
        /// </summary>
        [TestMethod()]
        public void IsValidTest()
        {
            bool isValidName = DataValidation.IsValid("name", Patterns.Charecter);
            bool isInvalidName = DataValidation.IsValid("90+name", Patterns.Charecter);
            Assert.IsTrue(isValidName);
            Assert.IsFalse(isInvalidName);

            bool isValidDL = DataValidation.IsValid("TN0019961234567", Patterns.DrivingLicenseNumber);
            bool isInvalidValidDL = DataValidation.IsValid("TN0011234567", Patterns.DrivingLicenseNumber);
            Assert.IsTrue(isValidDL);
            Assert.IsFalse(isInvalidValidDL);

            bool isValidDate = DataValidation.IsValid("04/03/2000", Patterns.Date);
            bool isInValidDate = DataValidation.IsValid("34/13/2000", Patterns.Date);
            Assert.IsTrue(isValidDate);
            Assert.IsFalse(isInValidDate);

            bool isValidAddress = DataValidation.IsValid("2nd Street Salem", Patterns.CharecterDigitAndSpace);
            bool isInValidAddress = DataValidation.IsValid("2nd S_+80tre+-et Salem", Patterns.CharecterDigitAndSpace);
            Assert.IsTrue(isValidAddress);
            Assert.IsFalse(isInValidAddress);

            bool isCharWithDigit = DataValidation.IsValid("3Rd", Patterns.CharecterWithDigit);
            bool isNotCharWithDigit = DataValidation.IsValid("3R_+d", Patterns.CharecterWithDigit);

            Assert.IsTrue(isCharWithDigit);
            Assert.IsFalse(isNotCharWithDigit);

            bool isValidVehicle = DataValidation.IsContain("HMV", Patterns.VehicleCategorys);
            bool isInValidVehicle = DataValidation.IsContain("LLV", Patterns.VehicleCategorys);
            Assert.IsTrue(isValidVehicle);
            Assert.IsFalse(isInValidVehicle);

            bool isValidDLCategory = DataValidation.IsContain("HGV", Patterns.DrivingLicenseCategorys);
            bool isInValidDLCategory = DataValidation.IsContain("+GV", Patterns.DrivingLicenseCategorys);
            Assert.IsTrue(isValidDLCategory);
            Assert.IsFalse(isInValidDLCategory);
        }

        /// <summary>
        /// To test IsContainTest() method
        /// </summary>
        [TestMethod()]
        public void IsContainTest()
        {
            bool isValidVehicle = DataValidation.IsContain("HMV", Patterns.VehicleCategorys);
            bool isInValidVehicle = DataValidation.IsContain("LLV", Patterns.VehicleCategorys);
            Assert.IsTrue(isValidVehicle);
            Assert.IsFalse(isInValidVehicle);

            bool isValidDLCategory = DataValidation.IsContain("HGV", Patterns.DrivingLicenseCategorys);
            bool isInValidDLCategory = DataValidation.IsContain("PV", Patterns.DrivingLicenseCategorys);
            Assert.IsTrue(isValidDLCategory);
            Assert.IsFalse(isInValidDLCategory);
        }

        /// <summary>
        /// To test IsValidAgeTest() method
        /// </summary>
        [TestMethod]
        public void IsValidAgeTest()
        {

            bool isValidAge = DataValidation.IsValidAge("08/09/1999");
            bool isInvalidAge = DataValidation.IsValidAge("08/08/2018");
            Assert.IsTrue(isValidAge);
            Assert.IsFalse(isInvalidAge);

            try
            {
                // invalid age formate
                DataValidation.IsValidAge("28/08/2018");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("String was not recognized as a valid DateTime.", exception.Message);
            }
        }

        /// <summary>
        /// To test IsNotFutureDateTest() method
        /// </summary>
        [TestMethod]
        public void IsNotFutureDateTest()
        {

            bool isNotFutureDate = DataValidation.IsNotFutureDate("08/09/2018");
            bool isFutureDate = !DataValidation.IsNotFutureDate("08/08/2019");
            Assert.IsTrue(isNotFutureDate);
            Assert.IsTrue(isFutureDate);

            try
            {
                // invalid age formate
                DataValidation.IsNotFutureDate("28/08/2018");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("String was not recognized as a valid DateTime.", exception.Message);
            }
        }
    }
}
