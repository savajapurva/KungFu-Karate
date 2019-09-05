
<img src="img/a (1).png">

# Kung Fu Karate Academy - A student management system

This is a web application for the institutions who wants a system that has variety of functions such as student registration, attendance and progress tracking, payment management and class management. 

## Frameworks - Libraries

1. ASP.NET MVC (version 5)
2. Entity Framework
3. Ninject
4. Automapper
5. Bootstrap 3
6. JQuery
7. Font Awesome

## Running Project

- Open the project with Visual Studio.
- Open .sln file provided in the visual studio.
- Open SQL Server Management Studio(SSMS) and connect it to SQL Server
- Restore the database provided by Right Click on Databases and then click onRestore Database. Then navigate to the database file and import it.
- Open Visual Studio and run the IIS Express to run the project
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

## Snapshots

<img src="img/a (14).png">

---

<img src="img/a (3).png">

---

<img src="img/a (4).png">

---

<img src="img/a (5).png">

---

<img src="img/a (6).png">

---

<img src="img/a (7).png">

---

<img src="img/a (8).png">

---

<img src="img/a (9).png">

---

<img src="img/a (10).png">

---

<img src="img/a (12).png">

---

<img src="img/a (13).png">

---

<img src="img/a (2).png">

---
