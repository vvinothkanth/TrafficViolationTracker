//-----------------------------------------------
//  Problem Title : Trafic violence
//  Author        : Vinoth Kanth V
//  Date          : 19 / 9 / 2018
//  
//
//
//-----------------------------------------------

namespace TrafficViolence.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TrafficViolence;
    using System;

    /// <summary>
    /// The Check Traffic Violation Data Class
    /// </summary>
    [TestClass()]
    public class TrafficViolationDetectionTests
    {
        /// <summary>
        /// To check vehicle datas
        /// </summary>
        [TestMethod]
        public void CheckVehicleData()
        {
            // To check currect data 
            Vehicle validVehicle = new Vehicle("TN31CT5052", "RAM", "GUINDY NH45 MAIN ROAD", "LMV", "BAJAJ R16", "23/07/2025");
            string actualValue = @"TN31CT5052,RAM,GUINDY NH45 MAIN ROAD,LMV,BAJAJ R16,23/07/2025";
            string expectedValue = validVehicle.GetIntoCsvFormat();
            Assert.AreEqual(expectedValue, actualValue);

            try
            {
                // to test invalid vehicle data
                Vehicle vehicle = new Vehicle(" ", " ", " ", " ", " ", " ");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid Vehicle License Number", exception.Message);
            }

            try
            {
                // to test invalid vehicle license number, the real value eg. TN12AB1234
                Vehicle vehicle = new Vehicle("T3C52", "RAM", "GUINDY MAIN ROAD", "LMV", "BAJAJ R16", "23/07/2025");                
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {   
                Assert.AreEqual("Invalid Vehicle License Number", exception.Message);
            }

            try
            {
                // to check invalid name , the name formate RAM
                Vehicle vehicle = new Vehicle("TN32CT5252", "R]AM +3", "GUINDY MAIN ROAD", "LMV", "BAJAJ R16", "23/07/2025");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid name format", exception.Message);
            }

            try
            {
                // to check invalid address, the adderss formate 2nd main road chennai
                Vehicle vehicle = new Vehicle("TN32CN5252", "Krish", "+;.GUINDY- MAIN ROA]D", "LMV", "BAJAJ R16", "23/07/2025");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid address format", exception.Message);
            }

            try
            {
                // to check invalid category
                Vehicle vehicle = new Vehicle("TN32CN5252", "Krish", "2nd MainRoad Salem", "RT", "BAJAJ R16", "23/07/2025");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid vehicle category", exception.Message);
            }

            try
            {
                // to check invalid model,  it not contain any special charecter
                Vehicle vehicle = new Vehicle("TN32CN5252", "Krish", "2nd MainRoad Salem", "LMV", "B[-AJAJ +R16", "23/07/2025");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid vehicle model formate", exception.Message);
            }

            try
            {
                // to check invalid date
                Vehicle vehicle = new Vehicle("TN32NC5252", "Krish", "2nd MainRoad Salem", "LMV", "Bajaj R15", "32/00/2125");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid expiry date formate", exception.Message);
            }

            try
            {
                // to check empty list
                TrafficViolation.CreateVehicle(new string[] { });
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException exception)
            {
                Assert.AreEqual("Array Index Out Of Bounce", exception.Message);
            }

            try
            {
                // to check out of boundary data
                TrafficViolation.CreateVehicle(new string[] { "data" , "data"});
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException exception)
            {
                Assert.AreEqual("Array Index Out Of Bounce", exception.Message);
            }

        }

        /// <summary>
        /// To check driver datas
        /// </summary>
        [TestMethod]
        public void CheckDriverData()
        {
            //to check currect data
            Driver validDriver = new Driver("TN5619951234567", "Ravanan", "Address 2nd street", "03/03/2018", "07/07/2018", "HMV");
            string actualValue = validDriver.GetIntoCsvFormat();
            string expectedValue = @"TN5619951234567,Ravanan,Address 2nd street,HMV,03/03/2018,07/07/2018";
            Assert.AreEqual(expectedValue, actualValue);

            try
            {
                // test Invalid Driver
                Driver driver = new Driver(" ", " ", " ", " ", " ", " ");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid Driver License Id", exception.Message);
            }

            try
            {
                // test Invalid Driver license id, the id formate is TN0019991234567
                Driver driver = new Driver("TN56151235", "Ravanan", "Address 2nd street", "03/03/2018", "07/07/2018", "HMV");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid Driver License Id", exception.Message);
            }

            try
            {
                // test Invalid name, the name formate Ravanan , it dont have any special charecter
                Driver driver = new Driver("TN5619951234567", "23*Ravanan", "Address 2nd street", "03/03/2018", "07/07/2018", "HMV");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid Name", exception.Message);
            }

            try
            {
                // test Invalid address formate, it not contain any special charecter
                Driver driver = new Driver("TN5619951234567", "Ravanan", "-=Addre32ss = 2nd street", "03/03/2018", "07/07/2018", "HMV");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid Address", exception.Message);
            }

            try
            {
                // test Invalid DOB date
                Driver driver = new Driver("TN5619951234567", "Ravanan", "Address 2nd street", "32/15/2100", "07/07/2018", "HMV");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid DOB Formate", exception.Message);
            }

            try
            {
                // test Invalid DOI date
                Driver driver = new Driver("TN5619951234567", "Ravanan", "Address 2nd street", "03/05/2000", "00/23/2018", "HMV");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Invalid DOI Formate", exception.Message);
            }

            try
            {
                // test Invalid License Category 
                Driver driver = new Driver("TN5619951234567", "Ravanan", "Address 2nd street", "03/05/2000", "07/06/2018", "LLL");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("License Category Is Not Found", exception.Message);
            }

            try
            {
                // to check enpty list
                TrafficViolation.CreateDriver(new string[] { });
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException exception)
            {
                Assert.AreEqual("Array Index Out Of Bounce", exception.Message);
            }

            try
            {
                // to check out of boundary data
                TrafficViolation.CreateDriver(new string[] { "data", "data" });
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException exception)
            {
                Assert.AreEqual("Array Index Out Of Bounce", exception.Message);
            }
        }

        /// <summary>
        /// To check infraction datas
        /// </summary>
        [TestMethod]
        public void CheckInfractionData()
        {
            // To check the currect data
            Infraction validInfraction = new Infraction("001/2018", "PC220", "09/09/2013", "Chennai", "speeding");
            string actualValue = validInfraction.GetIntoCsvFormat();
            string expectedValue = @"001/2018,PC220,09/09/2013,Chennai,speeding";
            Assert.AreEqual(expectedValue, actualValue);

            try
            {
                // to cheack empty fields
                Infraction infraction = new Infraction(" ", " ", " ", " ", " ");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid infraction ticket number", ex.Message);
            }

            try
            {
                // to cheack invalid infraction id, the real formate is 0000/1234 
                Infraction infraction = new Infraction("0670","PC101", "03/03/2018", "Chennai", "Speeding");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid infraction ticket number", ex.Message);
            }

            try
            {
                // to cheack invalid police id , the real formate is AB000
                Infraction infraction = new Infraction("001/2018", "LL-101", "03/03/2018", "Chennai", "Speeding");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid police Id", ex.Message);
            }

            try
            {
                // to cheack invalid date
                Infraction infraction = new Infraction("001/2018", "PC101", "-3/+3/218", "Chennai", "Speeding");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid date", ex.Message);
            }

            try
            {
                // to cheack invalid place, it dont have any special charecter
                Infraction infraction = new Infraction("001/2018", "PC101", "08/09/2018", "Chenna=-sd11#", "Speeding");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid location", ex.Message);
            }

            try
            {
                // to cheack invalid infraction format,it dont have any special charecter
                Infraction infraction = new Infraction("001/2018", "PC101", "23/12/2018", "Madhurai", "S--pe@eding");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid infraction format", ex.Message);
            }

            try
            {
                // to check empty values
                TrafficViolation.CreateInfraction(new string[] { });
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException exception)
            {
                Assert.AreEqual("Array Index Out Of Bounce", exception.Message);
            }

            try
            {
                // to check out of boundary data
                TrafficViolation.CreateInfraction(new string[] { "data", "data" });
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException exception)
            {
                Assert.AreEqual("Array Index Out Of Bounce", exception.Message);
            }

            try
            {
                // to check null object
                Driver driver = null;
                Vehicle vehicle = null;
                Infraction infraction = null;
                TrafficViolation trafficViolation = new TrafficViolation(driver, vehicle, infraction);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Value cannot be null.", exception.Message);
                
            }
        }
    }
}