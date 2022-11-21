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

        public string Job { get; private set; }

        public Employee(string job)
        {
            Job = job;
        }

        public void WorkNextShift()
        {
            if (BalanceSheet.PayEmployee(DayRate))
            {
                DoJob();
            }
        }
        protected virtual void DoJob() { }

    }   
}
