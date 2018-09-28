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
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TrafficViolationTrackingSystem;
    using System.IO;

    /// <summary>
    /// The Traffic Violation Datection Tests
    /// </summary>
    [TestClass()]
    public class TrafficViolationDatectionTests
    {
        /// <summary>
        /// To check the csv file is properly loaded or not
        /// </summary>
        [TestMethod()]
        public void CheckLoadCsvFileTest()
        {
            TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();
            try
            {
                // To check invalid file path
                trafficViolationDetection.LoadCsvFile(@"\\tsclient\E\vinothkanth\Assesment\GovernmentOfIndia\TrafficViolence\TrafficVionRecord.csv");
                
            }
            catch (FileNotFoundException exception)
            {
                string expected = "File Not Found";
                Assert.AreEqual(expected, exception.Message);

            }

            // To check the function can be read the data
            string csvFilePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            List<string> listOfFileData = trafficViolationDetection.LoadCsvFile(csvFilePath);
            string infractionId = listOfFileData[0].Split('#')[0].Split(',')[0];
            Assert.AreEqual("001/2018", infractionId);
        }

        /// <summary>
        /// To Check Traffic Violation List Creation
        /// </summary>
        [TestMethod]
        public void CheckTrafficViolationListCreation()
        {
            // Load Traffic violation datas
            TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();

            string csvFilePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            List<string> trafficViolationDatas = trafficViolationDetection.LoadCsvFile(csvFilePath);

            List<string[]> listOfTrafficViolationData = trafficViolationDetection.Split(trafficViolationDatas, '#');

            List<TrafficViolation> listOfTrafficViolation = trafficViolationDetection.CreateTrafficViolationList(listOfTrafficViolationData);

            // it will be return the first index of driver name
            string driverName = listOfTrafficViolation[0].GetDriver().GetName();
            Assert.AreEqual("RAHMAN", driverName);

        }

        /// <summary>
        /// To  Check the GetTrafficViolationByDriver() function properly fetch the data 
        /// </summary>
        [TestMethod]
        public void CheckGetTrafficViolationByDriver()
        {
            // Load Traffic violation datas
            TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();

            string csvFilePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            List<string> trafficViolationDatas = trafficViolationDetection.LoadCsvFile(csvFilePath);

            List<string[]> listOfTrafficViolationData = trafficViolationDetection.Split(trafficViolationDatas, '#');

            List<TrafficViolation> listOfTrafficViolation = trafficViolationDetection.CreateTrafficViolationList(listOfTrafficViolationData);

            // it will be return the count of driver violation
            int valueCount = trafficViolationDetection.GetUsingDriver("TN5619951232345", listOfTrafficViolation).Count;
            // Invalid data
            int dataNotFoundCount = trafficViolationDetection.GetUsingDriver("TN56195145", listOfTrafficViolation).Count;
            Assert.AreEqual(2, valueCount);
            Assert.AreEqual(0, dataNotFoundCount);

            try
            {
                List<TrafficViolation> list = new List<TrafficViolation>() 
                {
                    new TrafficViolation(null, null, null)
                };

                // It will be throw an object instance null  exception
                trafficViolationDetection.GetUsingDriver("TN56195145", list);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message.ToString());
            }
        }

        /// <summary>
        /// To test driver with particular vehicle violation wise filtering
        /// </summary>
        [TestMethod]
        public void CheckGetTrafficViolationByDriverWithParticularVehicle()
        {
            // Load Traffic violation datas
            TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();

            string csvFilePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            List<string> trafficViolationDatas = trafficViolationDetection.LoadCsvFile(csvFilePath);

            List<string[]> listOfTrafficViolationData = trafficViolationDetection.Split(trafficViolationDatas, '#');

            List<TrafficViolation> listOfTrafficViolation = trafficViolationDetection.CreateTrafficViolationList(listOfTrafficViolationData);

            // it will be return the count of driver violation
            int valueCount = trafficViolationDetection.GetUsingDriverWithParticularVehicle("TN2320029007007", "TN23CN5350", listOfTrafficViolation).Count;
            // Invalid data
            int dataNotFoundCount = trafficViolationDetection.GetUsingDriverWithParticularVehicle("TN232002900707", "TN23CN550", listOfTrafficViolation).Count;
            Assert.AreEqual(3, valueCount);
            Assert.AreEqual(0, dataNotFoundCount);

            // To check exception case
            try
            {
                List<TrafficViolation> list = new List<TrafficViolation>() 
                {
                    new TrafficViolation(null, null, null)
                };

                // It will be throw an object instance null  exception
                trafficViolationDetection.GetUsingDriverWithParticularVehicle("TN56195145","" ,list);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message.ToString());
            }
        }

        /// <summary>
        /// To check the vehicle category wise filtering
        /// </summary>
        [TestMethod]
        public void CheckGetTrafficViolationByVehicleCategory()
        {
            // Load Traffic violation datas
            TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();

            string csvFilePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            List<string> trafficViolationDatas = trafficViolationDetection.LoadCsvFile(csvFilePath);

            List<string[]> listOfTrafficViolationData = trafficViolationDetection.Split(trafficViolationDatas, '#');

            List<TrafficViolation> listOfTrafficViolation = trafficViolationDetection.CreateTrafficViolationList(listOfTrafficViolationData);

            // it will be return the count of traffic violation of specified vehicle category
            int valueCount = trafficViolationDetection.GetUsingVehicleCategory("HMV", listOfTrafficViolation).Count;
            // Invalid data
            int dataNotFoundCount = trafficViolationDetection.GetUsingVehicleCategory("RRT", listOfTrafficViolation).Count;
            Assert.AreEqual(7, valueCount);
            Assert.AreEqual(0, dataNotFoundCount);

            // To check exception case
            try
            {
                List<TrafficViolation> list = new List<TrafficViolation>() 
                {
                    new TrafficViolation(null, null, null)
                };

                // It will be throw an object instance null  exception
                trafficViolationDetection.GetUsingVehicleCategory("TN56195145", list);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message.ToString());
            }
        }

        /// <summary>
        /// To test particular police registered infraction filtering
        /// </summary>
        [TestMethod]
        public void CheckGetTrafficViolationRegisteredByParticularPolice()
        {
            // Load Traffic violation datas
            TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();
            string csvFilePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            List<string> trafficViolationDatas = trafficViolationDetection.LoadCsvFile(csvFilePath);
            List<string[]> listOfTrafficViolationData = trafficViolationDetection.Split(trafficViolationDatas, '#');

            List<TrafficViolation> listOfTrafficViolation = trafficViolationDetection.CreateTrafficViolationList(listOfTrafficViolationData);

            // it will be return the count of particulet police registered infractions
            int valueCount = trafficViolationDetection.GetUsingRegisteredByParticularPolice("PC102", listOfTrafficViolation).Count;
            // Invalid data
            int dataNotFoundCount = trafficViolationDetection.GetUsingRegisteredByParticularPolice("PC110", listOfTrafficViolation).Count;
            Assert.AreEqual(3, valueCount);
            Assert.AreEqual(0, dataNotFoundCount);

            // To check exception case
            try
            {
                List<TrafficViolation> list = new List<TrafficViolation>() 
                {
                    new TrafficViolation(null, null, null)
                };

                // It will be throw an object instance null  exception
                trafficViolationDetection.GetUsingRegisteredByParticularPolice("PC101", list);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message.ToString());
            }
        }

        /// <summary>
        /// To Check CheckCreateTrafficViolationList() method
        /// </summary>
        [TestMethod]
        public void CheckCreateTrafficViolationList()
        {
            try
            {
                TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();
                // duplicate records
                string csvFilePath = @"\\tsclient\E\vinothkanth\Assesment\GovernmentOfIndia\TrafficViolence\dummyRecord.csv";
                List<string> trafficViolationDatas = trafficViolationDetection.LoadCsvFile(csvFilePath);
                List<string[]> listOfTrafficViolationData = trafficViolationDetection.Split(trafficViolationDatas, ',');

                // it will be throw an Index out of boundary exception
                trafficViolationDetection.CreateTrafficViolationList(listOfTrafficViolationData);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Array Index Out Of Bounce", ex.Message.ToString());
            }
        }

        [TestMethod]
        public void CheckWriteIntoCsvFile()
        {

            try
            {

                TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();
                string csvFilePath = @"\\tsclient\E\vinothkanth\Assesment\GovernmentOfIndia\TrafficViolence\dummyRecord.csv";

                TrafficViolation trafficViolation = null;

                // it will be throw an 
                trafficViolationDetection.WriteIntoCsvFile(trafficViolation, csvFilePath );
            }
            catch (Exception ex)
            {

                Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message.ToString());
            }

        }

    }
}
