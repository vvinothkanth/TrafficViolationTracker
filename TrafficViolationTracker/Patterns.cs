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
    /// <summary>
    /// The Regular Expression class
    /// </summary>
    public static class Patterns
    {
        /// <summary>
        /// Regular expression for charecter
        /// </summary>
        public static readonly string Charecter = @"^[a-zA-Z][a-zA-Z\\s]+$";

        /// <summary>
        /// Regular expression for to check charecter and digit
        /// </summary>
        public static readonly string CharecterWithDigit = @"^[a-zA-Z0-9][a-zA-Z0-9\\s]+$";

        /// <summary>
        /// Regular expression for to check driving license number
        /// </summary>
        public static readonly string DrivingLicenseNumber = @"^(?<intro>[A-Z]{2})(?<numeric>\d{2})(?<year>\d{4})(?<tail>\d{7})$";

        /// <summary>
        /// Regular expression for to check vehicle license number
        /// </summary>
        public static readonly string VehicleLicenseNumber = @"^(?<intro>[A-Z]{2})(?<numeric>\d{2})(?<year>[A-Z]{2})(?<tail>\d{4})$";

        /// <summary>
        /// Regular expression for to check date
        /// </summary>
        public static readonly string Date = @"(((0[1-9]|1[0-2])\/(0|1)[0-9]|2[0-9]|3[0-1])\/((19|20)\d\d))$";

        /// <summary>
        /// Regular ecpression for to check infraction ticket number
        /// </summary>
        public static readonly string InfractionTicketId = @"^(?<intro>\d{3})([/])((19|20))(?<year>\d{2})$";

        /// <summary>
        /// Regular expression for to check police id
        /// </summary>
        public static readonly string PoliceId = @"^(?<intro>[A-Za-z]{2,4})(?<rank>\d{3})$";

        /// <summary>
        /// Regular expression for to check charecter and space
        /// </summary>
        public static readonly string CharecterWithSpace = @"^(?<intro>[A-Za-z ]*)$";

        /// <summary>
        /// Regular expression for to check charecter , digit with space
        /// </summary>
        public static readonly string CharecterDigitAndSpace = @"^(?<intro>[A-Za-z0-9 ]*)$";

        /// <summary>
        /// The vehicle license categorys
        /// </summary>
        public static readonly string[] VehicleCategorys = new string[]
        {
            "MC", "MCW", "MCWOG", "LMV", "LMV-NT", "LMV-TR", "HMV"
        };

        /// <summary>
        /// The driving license categorys
        /// </summary>
        public static readonly string[] DrivingLicenseCategorys = new string[]
        {
            "MCW", "MCWG", "M/CYCL.WG", "MCWOG", "ARNT", "LMV-NT", "LMV-T", "HMV", "ART", "MGV", "MGP", "HGV", "HPV", "HTV", "HZRD", "TR ", "RDRLR"
        };

    }
}
