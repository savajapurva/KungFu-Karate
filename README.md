
<img src="img/a (1).png">

# Kung Fu Karate Academy - A student management system

This is a web application for the institutions who wants a system that has variety of functions such as student registration, attendance and progress tracking, payment management and class management. 

# Frameworks - Libraries

1. ASP.NET MVC (version 5)
2. Entity Framework
3. Ninject
4. Automapper
5. Bootstrap 3
6. JQuery

# Running Project

- Open the project with Visual Studio.
- in `web.config`file change the connection string according to your system.
  ```
  <connectionString><add name="ClinicDB" connectionString="data source=Your data source; initial catalog=ClinicDB;Integrated Security=True" providerName="System.Data.SqlClient" /></connectionString>
  ```
- In package manager console run the following commands 
    ```
    - enable-migrations
    -  add-migration "InitialDb"
    -  update-database
   ```
- Open the database
- In `AspNetRoles` table add  Administrator and Doctor.
- Run the project. Go to   http://localhost:xxxx/Account/Register  to add admin user.
