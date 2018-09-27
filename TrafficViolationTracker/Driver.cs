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

    /// <summary>
    /// The Driver Class
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// The Driver License Number
        /// </summary>
        private string _licenseNumber;

        /// <summary>
        /// The Driver Name
        /// </summary>
        private string _name;

        /// <summary>
        /// The Address
        /// </summary>
        private string _address;

        /// <summary>
        /// The date of birth
        /// </summary>
        private string _dateOfBirth;

        /// <summary>
        /// The date of issue
        /// </summary>
        private string _dateOfIssue;

        /// <summary>
        /// The license category
        /// </summary>
        private string _category;

        /// <summary>
        /// To initialize the class members
        /// </summary>
        /// <param name="licenseNumber">The DL number</param>
        /// <param name="name">The name</param>
        /// <param name="address">The Address</param>
        /// <param name="dateOfBirth">The Date Of Birth</param>
        /// <param name="dateOfIssue">The Date Of Issue</param>
        /// <param name="category">The License Category</param>
        public Driver(string licenseNumber, string name, string address, string dateOfBirth, string dateOfIssue, string category)
        {
            if(!DataValidation.IsValid(licenseNumber, Patterns.DrivingLicenseNumber))
            {
                throw new ArgumentException("Invalid Driver License Id");
            }
            if(!DataValidation.IsValid(name, Patterns.CharecterWithSpace))
            {
                throw new ArgumentException("Invalid Name");
            }
            if(!DataValidation.IsValid(address, Patterns.CharecterDigitAndSpace))
            {
                throw new ArgumentException("Invalid Address");
            }
            if(!DataValidation.IsValid(dateOfBirth, Patterns.Date))
            {
                throw new ArgumentException("Invalid DOB Formate");
            }
            if (!DataValidation.IsValidAge(dateOfBirth))
            {
                throw new ArgumentException("Invalid DOB Formate");
            }
            if(!DataValidation.IsValid(dateOfIssue, Patterns.Date))
            {
                throw new ArgumentException("Invalid DOI Formate");
            }
            if (!DataValidation.IsNotFutureDate(dateOfIssue))
            {
                throw new ArgumentException("Invalid DOI Formate");
            }
            if(!DataValidation.IsContain(category, Patterns.DrivingLicenseCategorys))
            {
                throw new ArgumentException("License Category Is Not Found");
            }

            _licenseNumber = licenseNumber;
            _name = name;
            _address = address;
            _dateOfBirth = dateOfBirth;
            _dateOfIssue = dateOfIssue;
            _category = category;
        }

        /// <summary>
        /// To get driver name
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// To get license number
        /// </summary>
        /// <returns></returns>
        public string GetLicenseNumber()
        {
            return _licenseNumber;
        }

        /// <summary>
        /// To get address
        /// </summary>
        /// <returns></returns>
        public string GetAddress()
        {
            return _address;
        }

        /// <summary>
        /// To get DOB
        /// </summary>
        /// <returns></returns>
        public string GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        /// <summary>
        /// To get DOI
        /// </summary>
        /// <returns></returns>
        public string GetDateOfIssue()
        {
            return _dateOfIssue;
        }

        /// <summary>
        /// To get license category
        /// </summary>
        /// <returns></returns>
        public string GetCategory()
        {
            return _category;
        }

        /// <summary>
        /// To get license information into csv format
        /// </summary>
        /// <returns></returns>
        public virtual string GetIntoCsvFormat()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", GetLicenseNumber(), GetName(), GetAddress(), GetCategory(), GetDateOfBirth(), GetDateOfIssue());
        }
    }
}
