Payroll System Team 3

OVERVIEW:

   The Payroll System is a comprehensive application that streamlines the management of employee payroll. Users can easily access key information, including hourly wages, weekly earnings, and year-to-date totals, alongside generating payroll reports. The system allows users to add, edit, or delete employee information, making payroll management efficient and user-friendly.


FEATURES:

- Add Employee: Input new employee details, including ID, hourly rate, hours worked, and tax information."

- View Employee: Display existing information for current employees using their ID

- Update Employee: Modify existing employee information as necessary

- Delete Employee: Delete employee pay information as necessary

- Calculate Pay: Automatically compute gross pay, total taxes, and net pay based on inputs.


REQUIREMENTS:

 - .NET Framework
 - Windows Forms
 - Visual Studio 2022


INSTALLATION:

1. Clone the Repository:
https://github.com/mward60/Part2Payroll.git

2. Open in Visual Studio.


3. Build and run the application.




USAGE:

 - Add Employee: Fill out employee details in the input boxes and click "Save".

 - View Employee: Click on employee name in table provided and click "View".

 - Update Employee: Enter new information on existing employee profile and click "Save".

 - Delete Employee: Click on employee name on table and click "Delete".

 - Calculate Pay: Enter hours worked, salary, state tax rate, and federal tax rate, then click  "Calculate" to see the total pay, taxes, and YTD figures.



CODE STRUCTURE:

- Form1 Class: The main user interface that handles user interactions.

- DataTable: Holds employee data and supports operations like adding, updating, and deleting records.

- Event Handlers: Manage user actions, such as button clicks and cell formatting in the DataGridView.

- Input Validation: Ensures that all fields are correctly filled before saving or calculating payroll.
