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
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The Data Validation class
    /// </summary>
    public class DataValidation
    {

        /// <summary>
        /// To cheeck the given data is valid for given regular expression
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="expressionPartternKey">Regular expression pattern</param>
        /// <returns>The boolian</returns>
        public static bool IsValid(string data, string regularExpression)
        {
            bool isValid = false;
            Regex expression = new Regex(regularExpression);
            if (expression.IsMatch(data))
            {
                isValid = true;
            }

            return isValid;

        }

        /// <summary>
        /// To check the given data is exsist in given list
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="listOfData">The list of data</param>
        /// <returns>The boolian</returns>
        public static bool IsContain(string data, string[] listOfData)
        {
            bool isContain = false;
            if (listOfData.Contains(data.ToUpper()))
            {
                isContain = true;
            }

            return isContain;
        }

        /// <summary>
        /// To validate the age limit
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static bool IsValidAge(string dateOfBirth)
        {
            bool isValidAge = false;
            try
            {
                DateTime birthDate = DateTime.Parse(dateOfBirth);
                DateTime validBirthDate = DateTime.Now.AddYears(-18);
                isValidAge = (birthDate <= validBirthDate) ? true : false;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }

            return isValidAge;
        }


        /// <summary>
        /// To validate is not a future date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsNotFutureDate(string date)
        {
            bool isNotFutureDate = true;
            try
            {
                DateTime enteredDate = DateTime.Parse(date);
                DateTime nowDate = DateTime.Now;
                isNotFutureDate = (enteredDate <= nowDate ? true : false);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }

            return isNotFutureDate;
        }
    }
}
