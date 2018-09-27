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
    /// The Infraction Ticket Class
    /// </summary>
    public class Infraction
    {
        /// <summary>
        /// The ticket number
        /// </summary>
        private string _ticketNumber;

        /// <summary>
        /// The police Id
        /// </summary>
        private string _policeId;

        /// <summary>
        /// The Insedent date
        /// </summary>
        private string _date;

        /// <summary>
        /// The location 
        /// </summary>
        private string _location;

        /// <summary>
        /// The infraction type
        /// </summary>
        private string _infractionType;

        /// <summary>
        /// To initialize the class members
        /// </summary>
        /// <param name="ticketNumber">The name</param>
        /// <param name="policeId">The police id</param>
        /// <param name="date">The insedent date</param>
        /// <param name="location">The location</param>
        /// <param name="infractionType">The infraction type</param>
        public Infraction(string ticketNumber, string policeId, string date, string location, string infractionType)
        {
            if(!DataValidation.IsValid(ticketNumber, Patterns.InfractionTicketId))
            {
                throw new ArgumentException("Invalid infraction ticket number");
            }
            if (!DataValidation.IsValid(policeId, Patterns.PoliceId))
            {
                throw new ArgumentException("Invalid police Id");
            }
            if (!DataValidation.IsValid(date, Patterns.Date))
            {
                throw new ArgumentException("Invalid date");
            }
            if (!DataValidation.IsNotFutureDate(date))
            {
                throw new ArgumentException("Invalid DOI Formate");
            }
            if (!DataValidation.IsValid(location, Patterns.CharecterDigitAndSpace))
            {
                throw new ArgumentException("Invalid location");
            }
            if (!DataValidation.IsValid(infractionType, Patterns.CharecterWithSpace))
            {
                throw new ArgumentException("Invalid infraction format");
            }

            _ticketNumber = ticketNumber;
            _policeId = policeId;
            _date = date;
            _location = location;
            _infractionType = infractionType;
        }

        /// <summary>
        /// To get infraction id
        /// </summary>
        /// <returns></returns>
        public string GetTicketNumber()
        {
            return _ticketNumber;
        }

        /// <summary>
        /// To get police id
        /// </summary>
        /// <returns></returns>
        public string GetPoliceId()
        {
            return _policeId;
        }

        /// <summary>
        /// To get insedent date
        /// </summary>
        /// <returns></returns>
        public string GetDate()
        {
            return _date;
        }

        /// <summary>
        /// TO get place
        /// </summary>
        /// <returns></returns>
        public string GetLocation()
        {
            return _location;
        }

        /// <summary>
        /// To get infraction type
        /// </summary>
        /// <returns></returns>
        public string GetInfractionType()
        {
            return _infractionType;
        }

        /// <summary>
        /// To get the infraction data into csv format
        /// </summary>
        /// <returns></returns>
        public virtual string GetIntoCsvFormat()
        {
            return string.Format("{0},{1},{2},{3},{4}", GetTicketNumber(), GetPoliceId(), GetDate(), GetLocation(), GetInfractionType()) ;            
        }

    }
}
