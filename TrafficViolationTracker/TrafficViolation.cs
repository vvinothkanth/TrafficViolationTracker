//-----------------------------------------------
//  Problem Title : Trafic violence
//  Author        : Vinoth Kanth V
//  Date          : 19 / 9 / 2018
//  
//
//
//-----------------------------------------------

namespace TrafficViolationTrackingSystem
{
    using System;

    /// <summary>
    /// The Traffic Violation Class
    /// </summary>
    public class TrafficViolation
    {
        /// <summary>
        /// The driver object
        /// </summary>
        private Driver _driver;

        /// <summary>
        /// The vehicle object
        /// </summary>
        private Vehicle _vehicle;

        /// <summary>
        /// The infraction object
        /// </summary>
        private Infraction _infraction;

        /// <summary>
        /// To initialize the class members
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="vehicle"></param>
        /// <param name="infraction"></param>
        public TrafficViolation(Driver driver, Vehicle vehicle, Infraction infraction)
        {
            _driver = driver;
            _vehicle = vehicle;
            _infraction = infraction;
        }

        /// <summary>
        /// To get driver license
        /// </summary>
        /// <returns></returns>
        public Driver GetDriver()
        {
            return _driver;
        }

        /// <summary>
        /// To get vehicle license
        /// </summary>
        /// <returns></returns>
        public Vehicle GetVehicle()
        {
            return _vehicle;
        }

        /// <summary>
        /// To  get infraction ticket object
        /// </summary>
        /// <returns></returns>
        public Infraction GetInfraction()
        {
            return _infraction;
        }

        /// <summary>
        /// To create infraction object
        /// </summary>
        /// <param name="infractionDatas">infraction datas</param>
        /// <returns>infraction object</returns>
        public static Infraction CreateInfraction(string[] infractionDatas)
        {
            Infraction infraction = null;
            try
            {
                infraction = new Infraction(infractionDatas[0].Trim(), infractionDatas[1].Trim(), infractionDatas[2].Trim(), infractionDatas[3].Trim(), infractionDatas[4].Trim());
            }
            catch (IndexOutOfRangeException exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new IndexOutOfRangeException("Array Index Out Of Bounce");
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message);
            }

            return infraction;
        }

        /// <summary>
        /// To create driver object
        /// </summary>
        /// <param name="driverDatas">The driver license datas</param>
        /// <returns>The driver license object</returns>
        public static Driver CreateDriver(string[] driverDatas)
        {
            Driver driver = null;
            try
            {
                driver = new Driver(driverDatas[1].Trim(), driverDatas[2].Trim(), driverDatas[3].Trim(), driverDatas[5].Trim(), driverDatas[6].Trim(), driverDatas[4].Trim());
            }
            catch (IndexOutOfRangeException exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new IndexOutOfRangeException("Array Index Out Of Bounce");
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }

            return driver;
        }

        /// <summary>
        /// To create vehicle object
        /// </summary>
        /// <param name="vehicleDatas">The vehicle datas</param>
        /// <returns>The vehicle license object</returns>
        public static Vehicle CreateVehicle(string[] vehicleDatas)
        {
            Vehicle vehicle = null;
            try
            {
                vehicle = new Vehicle(vehicleDatas[1].Trim(), vehicleDatas[2].Trim(), vehicleDatas[3].Trim(), vehicleDatas[4].Trim(), vehicleDatas[5].Trim(), vehicleDatas[6].Trim());
            }
            catch (IndexOutOfRangeException exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new IndexOutOfRangeException("Array Index Out Of Bounce");
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }

            return vehicle;
        }
    }
}   
