using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeEmployeeManagementSystem
{
    internal class Manager : Employee
    {
        // Start employees as an empty array
        private Employee[] employees = new Employee[0];

        // Number of employees to be appended to array
        private float unassignedEmployees = 3;

        // Property to access status report
        public string StatusReport { get; private set; }

        // Manager's wage
        public override float DayRate { get { return 200f; } }

        public Manager() : base("Manager")
        {
            AssignEmployee("Driver");
            AssignEmployee("Decorator");
        }

        private void AddEmployee(Employee employee)
        {
            if (unassignedEmployees >= 1)
            {             
                unassignedEmployees--;
                // Increase memory of array to include additional value 
                Array.Resize(ref employees, employees.Length + 1);

                // Append employee to end of array
                employees[employees.Length - 1] = employee;
            }
        }

        private void UpdateStatusReport()
        {
            // First line returns the container inventory
            StatusReport = $"Status report:\n{BalanceSheet.StatusReport}\n" +
                $"\nUnassigned employees: {unassignedEmployees:0.0}\n" +
                $"{EmployeeStatus("Driver")}\n{EmployeeStatus("Decorator")}" +
                $"\nTotal number of employees: {employees.Length}";
        }


        // Methods to amend the inventory's balance (changed accessibility to public)
        public void IncreaseBalance(float amount)
        {
            if (amount > 0)
            {
                BalanceSheet.balance += amount;
            }
        }

        public void DecreaseBalance(float amount)
        {
            if (amount > 0)
            {
                BalanceSheet.balance -= amount;
            }
        }

        // A breakdown of all assigned employees
        private string EmployeeStatus(string job)
        {
            int count = 0;
            foreach (Employee employee in employees)
                if (employee.Job == job) count++;

            // Check for pluralisation
            string s = "s";            
            if (count == 1) s = "";
            return $"{count} {job} employee{s}";
        }

        // Creating new objects while assigning new employees
        public void AssignEmployee(string job)
        {
            switch (job)
            {
                case "Driver":
                    AddEmployee(new Driver());
                    break;

                case "Decorator":
                    AddEmployee(new Decorator());
                    break;
            }
            UpdateStatusReport();
        }

        // Adding new or existing employees to shifts
        protected override void DoJob()
        {
            foreach (Employee employee in employees)
            {
                employee.WorkNextShift();
            }
            UpdateStatusReport();
        }
    }
}
