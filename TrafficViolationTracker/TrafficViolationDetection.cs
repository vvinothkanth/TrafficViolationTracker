//-----------------------------------------------
//  Problem Title : Trafic violence
//  Author        : Vinoth Kanth V
//  Date          : 19 / 9 / 2018
//-----------------------------------------------

/// <summary>
///  The Traffic Violation Tracking System NameSpace
/// </summary>
namespace TrafficViolationTrackingSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The Traffic Violation Detection Class
    /// </summary>
    public class TrafficViolationDetection
    {

        /// <summary>
        /// To create the list of traffic violation objects 
        /// </summary>
        /// <param name="trafficViolationList">list of traffic violation data</param>
        /// <returns></returns>
        public virtual List<TrafficViolation> CreateTrafficViolationList(List<string[]> trafficViolationList)
        {
            List<TrafficViolation> listOfTrafficViolationObject = new List<TrafficViolation>();
            try
            {
                foreach (var trafficViolation in trafficViolationList)
                {
                    Infraction infraction = TrafficViolation.CreateInfraction(Split(trafficViolation[0], ','));
                    Driver driver = TrafficViolation.CreateDriver(Split(trafficViolation[1], ','));
                    Vehicle vehicle = TrafficViolation.CreateVehicle(Split(trafficViolation[2], ','));
                    TrafficViolation trafficViolationObject = new TrafficViolation(driver, vehicle, infraction);

                    listOfTrafficViolationObject.Add(trafficViolationObject);
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }

            return listOfTrafficViolationObject;
        }

        /// <summary>
        /// To loadt the data from given csv file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>list of file datas</returns>
        public List<string> LoadCsvFile(string filePath)
        {
            List<string> listOfFileData = new List<string>();
            try
            {
                var reader = new StreamReader(File.OpenRead(filePath));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listOfFileData.Add(line.ToUpper());
                }

                Logger.WriteLine(string.Format("File has been loaded from => {0}", filePath));
            }
            catch (FileNotFoundException exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new FileNotFoundException("File Not Found");
            }

            return listOfFileData;
        }

        /// <summary>
        /// To store the traffic violation data into csv file
        /// </summary>
        /// <param name="trafficViolation">The traffic violation object</param>
        /// <param name="filePath">The file path</param>
        public void WriteIntoCsvFile(TrafficViolation trafficViolation, string filePath)
        {
            try
            {
                string driver = trafficViolation.GetDriver().GetIntoCsvFormat();
                string vehicle = trafficViolation.GetVehicle().GetIntoCsvFormat();
                string infraction = trafficViolation.GetInfraction().GetIntoCsvFormat();
                string trafficViolationCsvFormat = string.Format("{0},#,{1},#,{2}", infraction.ToUpper(), driver.ToUpper(), vehicle.ToUpper());

                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(trafficViolationCsvFormat, streamWriter);
                    Logger.WriteLine("New Traffic violation entry has been successfully stored");
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }
        }

        /// <summary>
        /// To split the given data
        /// </summary>
        /// <param name="rawData">The raw data </param>
        /// <param name="separator">The separator</param>
        /// <returns>List of splited data</returns>
        public string[] Split(string rawData, char separator)
        {
            string[] listOfData = rawData.Split(separator);
            return listOfData;
        }

        /// <summary>
        /// Tho split the given list of data
        /// </summary>
        /// <param name="listOfRawData">The list of string data</param>
        /// <param name="separator">separator</param>
        /// <returns>List Of splited Data</returns>
        public List<string[]> Split(List<string> listOfRawData, char separator)
        {
            List<string[]> listOfData = new List<string[]>();
            foreach (var data in listOfRawData)
            {
                listOfData.Add(Split(data, separator));
            }

            return listOfData;
        }

        /// <summary>
        /// To  Get Traffic Violation By Driver
        /// </summary>
        /// <param name="driverLicenseNumber">Driver license number</param>
        /// <param name="trafficViolations">List of traffic violation</param>
        /// <returns>List of traffic violation</returns>
        public List<TrafficViolation> GetUsingDriver(string driverLicenseNumber, List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> listOfTrafficViolation = new List<TrafficViolation>();
            try
            {
                listOfTrafficViolation = (from trafficViolation in trafficViolations where trafficViolation.GetDriver().GetLicenseNumber().Trim() == driverLicenseNumber.ToUpper() select trafficViolation).ToList();
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }

            return listOfTrafficViolation;
        }

        /// <summary>
        /// To Get Traffic Violation By Driver With Particular Vehicle
        /// </summary>
        /// <param name="driverLicenseNumber">Driver license number</param>
        /// <param name="vehicleLicenseNumber"> vehicle license number</param>
        /// <param name="trafficViolations">List of traffic violation</param>
        /// <returns>List of traffic violation</returns>
        public List<TrafficViolation> GetUsingDriverWithParticularVehicle(string driverLicenseNumber, string vehicleLicenseNumber, List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> listOfTrafficViolation = new List<TrafficViolation>();
            try
            {
                listOfTrafficViolation = (from trafficViolation in trafficViolations where trafficViolation.GetDriver().GetLicenseNumber().Trim() == driverLicenseNumber.ToUpper() && trafficViolation.GetVehicle().GetLicenseNumber() == vehicleLicenseNumber.ToUpper() select trafficViolation).ToList();
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }

            return listOfTrafficViolation;
        }

        /// <summary>
        /// To Get Traffic Violation By Vehicle Category
        /// </summary>
        /// <param name="vehicleCategory">vehicle category</param>
        /// <param name="trafficViolations">List of traffic violation</param>
        /// <returns>List of traffic violation</returns>
        public List<TrafficViolation> GetUsingVehicleCategory(string vehicleCategory, List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> listOfTrafficViolation = new List<TrafficViolation>();
            try
            {
                listOfTrafficViolation = (from trafficViolation in trafficViolations where trafficViolation.GetVehicle().GetCategory().Trim() == vehicleCategory.ToUpper() select trafficViolation).ToList();
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }

            return listOfTrafficViolation;
        }

        /// <summary>
        /// To Get Traffic Violation Registered By Particular Police
        /// </summary>
        /// <param name="policeId"></param>
        /// <param name="trafficViolations">List of traffic violation</param>
        /// <returns>List of traffic violation</returns>
        public List<TrafficViolation> GetUsingRegisteredByParticularPolice(string policeId, List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> listOfTrafficViolation = new List<TrafficViolation>();
            try
            {
                listOfTrafficViolation = (from trafficViolation in trafficViolations where trafficViolation.GetInfraction().GetPoliceId().Trim() == policeId.ToUpper() select trafficViolation).ToList();
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }

            return listOfTrafficViolation;
        }
    }
}
