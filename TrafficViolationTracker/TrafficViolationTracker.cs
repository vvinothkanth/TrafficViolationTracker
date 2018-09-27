//-----------------------------------------------
//  Problem Title : Trafic violence
//  Author        : Vinoth Kanth V
//  Date          : 19 / 9 / 2018
//  
//
//
//-----------------------------------------------

namespace TrafficViolence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Traffic Violation Tracker System
    /// </summary>
    public class TrafficViolationTracker
    {
        /// <summary>
        /// User Options
        /// </summary>
        enum Option
        {
            EnterTrafficViolation = 1,
            GetQuery,
            Exit

        }

        /// <summary>
        /// The querys
        /// </summary>
        enum Query
        {
            TrafficViolationByDriver = 1,
            TrafficViolationByDriverWithVehicle,
            TrafficViolationByVehicleCategory,
            TrafficViolationRegisteredByPolice
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-------Traffic Violation Tracker--------");

            bool isFileNotLoaded = true;

            string csvFilePath = string.Empty;

            TrafficViolationDetection trafficViolationDetection = new TrafficViolationDetection();

            List<string> trafficViolationDatas = new List<string>();


            while (isFileNotLoaded)
            {
                Console.WriteLine("Load Your Existing CSV File:");
                Console.Write("Path :");
                csvFilePath = Convert.ToString(Console.ReadLine());
                try
                {
                    trafficViolationDatas = trafficViolationDetection.LoadCsvFile(csvFilePath);
                    isFileNotLoaded = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            List<string[]> listOfTrafficViolationData = trafficViolationDetection.Split(trafficViolationDatas, '#');

            List<TrafficViolation> listOfTrafficViolation = trafficViolationDetection.CreateTrafficViolationList(listOfTrafficViolationData);

            if (listOfTrafficViolation.Count == 0)
            {
                Console.WriteLine("File is empty");
            }

            bool isProcess = true;
            while (isProcess)
            {
                Console.WriteLine("1.) New Violation Entry ");
                Console.WriteLine("2.) Get Query");
                Console.WriteLine("3.) Exit");
                int userChoice = Convert.ToInt16(Console.ReadLine());

                if (userChoice == (int)Option.EnterTrafficViolation)
                {
                    bool IsDataNotStored = true;
                    

                    while (IsDataNotStored)
                    {
                        try
                        {
                            Console.WriteLine("Enter Driver Information:");
                            Console.WriteLine("Eg. #,AB0019951234567,Name,Door Street Place Dist,Licence Type,DD/MM/YYY<(DOB)>,DD/MM/YYYY<DOI>");
                            string driverInfromation = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Enter Vehicle Information");
                            Console.WriteLine("Eg. #,AB00CD1234,OwnerName,Door Street Place Dist,LicenceType,Vehicle Model,DD/MM/YYYY<Expiry Date>");
                            string vehicleInformation = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Enter Infraction Infromation :");
                            Console.WriteLine("000/YYYY<CaseId>,AB000<PCID>,DD/MM/YYYY<Date>,Place,Infraction Type");
                            string infractionInformation = Convert.ToString(Console.ReadLine());

                            string[] driverDatas = driverInfromation.Split(',');
                            string[] vehicleDatas = vehicleInformation.Split(',');
                            string[] infractionDatas = infractionInformation.Split(',');

                            Driver driver = TrafficViolation.CreateDriver(driverDatas);
                            Vehicle vehicle = TrafficViolation.CreateVehicle(vehicleDatas);
                            Infraction infraction = TrafficViolation.CreateInfraction(infractionDatas);
                            TrafficViolation trafficViolation = new TrafficViolation(driver, vehicle, infraction);
                            trafficViolationDetection.WriteIntoCsvFile(trafficViolation, csvFilePath);
                            listOfTrafficViolation.Add(trafficViolation);
                            IsDataNotStored = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Console.WriteLine("The new traffic violation has been succesfully stored.");

                }
                else if (userChoice == (int)Option.GetQuery)
                {
                    Console.WriteLine("1.) Get Traffic Violations By Driver\n2.) Get Traffic Violations By Driver With Vehicle\n3.) Get Traffic Violations By Vehicle\n4.)Get Traffic Violations Registered By Police");
                    Console.Write("Enter Your Option \t:");
                    int queryChoice = Convert.ToInt16(Console.ReadLine());
                    switch (queryChoice)
                    {
                        case (int)Query.TrafficViolationByDriver:
                            Console.WriteLine("Enter Driver Licence Number :Eg.AB0019951234567");
                            string driverLicenseNumber = Convert.ToString(Console.ReadLine());

                            List<TrafficViolation> infractionOfDriver = trafficViolationDetection.GetUsingDriver(driverLicenseNumber, listOfTrafficViolation);
                            if (infractionOfDriver.Count != 0)
                            {
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                Console.WriteLine(@"Id/Police Id/ Date/Place/Violation/VL No/Owner Name/Address/LicenceType/Model/Expiry Date ");
                                foreach (var trafficViolation in infractionOfDriver)
                                {
                                    string infractionData = trafficViolation.GetInfraction().GetIntoCsvFormat();
                                    string vehicleData = trafficViolation.GetVehicle().GetIntoCsvFormat();
                                    Console.WriteLine("{0},{1}", infractionData, vehicleData);
                                }
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found...");
                            }
                            break;

                        case (int)Query.TrafficViolationByDriverWithVehicle:
                            Console.WriteLine("Enter Driver Licence Number :Eg.AB0019951234567");
                            string driverLicenceNumber = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Enter Vehicle Licence Id : Eg. AB00BC1234");
                            string vehicleLicenceNumber = Convert.ToString(Console.ReadLine());

                            List<TrafficViolation> infractionOfDriverWithVehicle = trafficViolationDetection.GetUsingDriverWithParticularVehicle(driverLicenceNumber, vehicleLicenceNumber, listOfTrafficViolation);
                            if (infractionOfDriverWithVehicle.Count != 0)
                            {
                                Console.WriteLine("---------------------------------------------------------------");
                                Console.WriteLine("Infraction Id | Registered Police Id  | Date | Place | Infraction Type");
                                foreach (var trafficViolation in infractionOfDriverWithVehicle)
                                {
                                    
                                    string infractionData = trafficViolation.GetInfraction().GetIntoCsvFormat();
                                    Console.WriteLine(infractionData);                                    
                                }
                                Console.WriteLine("-----------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found...");
                            }
                            break;

                        case (int)Query.TrafficViolationByVehicleCategory:
                            Console.WriteLine("Enter Vehicle type Eg.HMV,LMV");
                            string vehicleType = Convert.ToString(Console.ReadLine());
                            List<TrafficViolation> vehicleWiseInfraction = trafficViolationDetection.GetUsingVehicleCategory(vehicleType, listOfTrafficViolation);
                            if (vehicleWiseInfraction.Count != 0)
                            {
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine("Infraction Id | Registered Police Id  | Date | Place | Infraction Type");
                                foreach (var trafficViolation in vehicleWiseInfraction)
                                {                                    
                                    string infractionData = trafficViolation.GetInfraction().GetIntoCsvFormat();
                                    Console.WriteLine(infractionData);
                                }
                                Console.WriteLine("------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found...");
                            }
                            break;

                        case (int)Query.TrafficViolationRegisteredByPolice:
                            Console.WriteLine("Enter Police Id Eg.PC101");
                            string policeId = Convert.ToString(Console.ReadLine());
                            List<TrafficViolation> policeRegistry = trafficViolationDetection.GetUsingRegisteredByParticularPolice(policeId, listOfTrafficViolation);
                            if (policeRegistry.Count != 0)
                            {
                                if (policeRegistry.Count != 0)
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                                    Console.WriteLine(@"Id/Police Id/ Date/Place/Violation/dL No/Driver Name/Address/ DOB / DOI ");
                                    foreach (var trafficViolation in policeRegistry)
                                    {
                                        string infractionData = trafficViolation.GetInfraction().GetIntoCsvFormat();
                                        string driverData = trafficViolation.GetVehicle().GetIntoCsvFormat();
                                        Console.WriteLine("{0},{1}", infractionData, driverData);
                                    }
                                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found...");
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong");
                            break;
                    }
                }
                else if (userChoice == (int)Option.Exit)
                {
                    isProcess = false;
                }
                else
                {
                    Console.WriteLine("Wrong Entry...");
                }
            }
        }
    }
}
