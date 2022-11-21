using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrototypeEmployeeManagementSystem
{
    internal class Employee
    {

        public virtual float DayRate { get; }

        // Read-only job property
        public string Job { get; private set; }

        // Constructor only sets read-only job property
        public Employee(string job)
        {
            Job = job;
        }

        // Check budget constraints before paying employee day rate
        public void WorkNextShift()
        {
            if (BalanceSheet.PayEmployee(DayRate))
            {
                DoJob();
            }
        }

        // Method to be overidden by subclasses
        protected virtual void DoJob() { }

    }   
}
