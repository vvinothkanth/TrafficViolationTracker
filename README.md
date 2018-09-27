# TrafficViolationTracker
It is a tracking system for detecting traffic violations, It will be loaded a traffic violation  CSV file and  converted the data into list of traffic violation objects.  So we can able to filter the data  like , traffic violations of  driver, driver with vehicle , vehicle category and police id.
 
**Driver Class :**

    This class contains the driver property and methods.
    GetName() ,GetAddress() ,GetDateOfBirth(), GetDateOfIssue(), GetCategory(), GetIntoCsvFormat(), GetLicenseNumber()
    
**Vehicle Class :**

    This class contains the vehicle property and methods.
    GetLicenseNumber(), GetOwnerName(), GetAddress(), GetCategory(), GetModel(), GetExpiryDate(), GetIntoCsvFormat()
    
**Infraction Class :**

    This class contains the infraction property and methods.
    GetTicketNumber(), GetPoliceId(), GetDate(), GetLocation(), GetInfractionType(), GetIntoCsvFormat()
    
**Traffic Violation Class :**

   This class contains the driver , vehicle and infraction objects, and object creation methods.
   
**Patterns Clas :**

It have some basic regular expression patterns and license category list.patterns are charecter, charecter with space, charecter with digit , charecter digit and space, driver license id, vehicle license id, date, vehicle category and driving license category.

**Data Validataion Class :**

```
   It contains validation methods . 
   IsValid( data, regularExpression), IsContain( data, listOfData ), IsValidAge(age), IsNotFutureDate(date).
   ```
**Traffic Violation Detection Class**

    It is used to load an csv file and convert into list of traffic violation object, and also it have some query methods 
    
    ..* CreateTrafficViolationList()     // Used to create traffic violation list
    ..* LoadCsvFile( )                   // To load CSV file
    ..* WriteIntoCsvFile()               // To write a new data into CSV file
    ..* Split( )                         // Split the data
    ..* GetUsingDriver()                 // Get driver infractions   
    ..* GetUsingDriverWithParticularVehicle()  // Get driver infractions using   particular vehicle
    ..* GetUsingVehicleCategory()	             // Get traffic infractions by using vehicle category
    ..* GetUsingRegisteredByParticularPolice() // Get Traffic violations registered b particular police 
