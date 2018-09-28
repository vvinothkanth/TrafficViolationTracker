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
    /// The Vehicle Class
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// The license number
        /// </summary>
        private string _licenseNumber;

        /// <summary>
        /// The owner name
        /// </summary>
        private string _ownerName;

        /// <summary>
        /// The address
        /// </summary>
        private string _addess;

        /// <summary>
        /// The category
        /// </summary>
        private string _category;

        /// <summary>
        /// The vehicle model
        /// </summary>
        private string _model;

        /// <summary>
        /// The vehicle expiry date
        /// </summary>
        private string _expiryDate;

        /// <summary>
        /// To initialize the class member
        /// </summary>
        /// <param name="licenseNumber">The name</param>
        /// <param name="ownerName">The owner name</param>
        /// <param name="address">The adderss</param>
        /// <param name="category">The category</param>
        /// <param name="model">The model</param>
        /// <param name="expiryDate">The expiry date</param>
        public Vehicle(string licenseNumber, string ownerName, string address, string category, string model, string expiryDate)
        {
            if (!DataValidation.IsValid(licenseNumber, Patterns.VehicleLicenseNumber))
            {
                throw new ArgumentException("Invalid Vehicle License Number");
            }
            if (!DataValidation.IsValid(ownerName, Patterns.CharecterWithSpace))
            {
                throw new ArgumentException("Invalid name format");
            }
            if (!DataValidation.IsValid(address, Patterns.CharecterDigitAndSpace))
            {
                throw new ArgumentException("Invalid address format");
            }
            if (!DataValidation.IsContain(category, Patterns.VehicleCategorys))
            {
                throw new ArgumentException("Invalid vehicle category");
            }
            if (!DataValidation.IsValid(model, Patterns.CharecterDigitAndSpace))
            {
                throw new ArgumentException("Invalid vehicle model formate");
            }
            if (!DataValidation.IsValid(expiryDate, Patterns.Date))
            {
                throw new ArgumentException("Invalid expiry date formate");
            }

            _licenseNumber = licenseNumber;
            _ownerName = ownerName;
            _addess = address;
            _category = category;
            _model = model;
            _expiryDate = expiryDate;
        }

        /// <summary>
        /// TO get license number
        /// </summary>
        /// <returns></returns>
        public string GetLicenseNumber()
        {
            return _licenseNumber;
        }

        /// <summary>
        /// The owner name
        /// </summary>
        /// <returns></returns>
        public string GetOwnerName()
        {
            return _ownerName;
        }

        /// <summary>
        /// The address
        /// </summary>
        /// <returns></returns>
        public string GetAddress()
        {
            return _addess;
        }

        /// <summary>
        /// The category
        /// </summary>
        /// <returns></returns>
        public string GetCategory()
        {
            return _category;
        }

        /// <summary>
        /// The model
        /// </summary>
        /// <returns></returns>
        public string GetModel()
        {
            return _model;
        }

        /// <summary>
        /// The expiry date
        /// </summary>
        /// <returns></returns>
        public string GetExpiryDate()
        {
            return _expiryDate;
        }

        /// <summary>
        /// To get the vehicle information into csv format
        /// </summary>
        /// <returns></returns>
        public virtual string GetIntoCsvFormat()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", GetLicenseNumber(), GetOwnerName(), GetAddress(), GetCategory(), GetModel(), GetExpiryDate());
        }
    }
}
