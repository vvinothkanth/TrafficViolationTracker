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
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    [TestClass()]
    public class TrafficViolationDetectionTests
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
                trafficViolationDetection.LoadCsvFile(@"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\Trafficord.csv");
                Assert.Fail("An exception should have been thrown");
            }
            catch (FileNotFoundException exception)
            {
                string expected = "File Not Found";
                Assert.AreEqual(expected, exception.Message);
                
            }

            // To check the function can be read the data
            string csvFilePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            List<string> listOfFileData =  trafficViolationDetection.LoadCsvFile(csvFilePath);
            string infractionId =  listOfFileData[0].Split('#')[0].Split(',')[0];
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
            Assert.AreEqual(2, valueCount);
            Assert.AreEqual(0, dataNotFoundCount);
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
            Assert.AreEqual(6, valueCount);
            Assert.AreEqual(0, dataNotFoundCount);
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
        }        

    }
}