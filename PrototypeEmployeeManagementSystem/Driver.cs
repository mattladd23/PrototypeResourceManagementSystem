using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeEmployeeManagementSystem
{
    internal class Driver : Employee
    {
        // To amend container inventory
        public const float CONTAINERS_COLLECTED_PER_SHIFT = 5f;

        // To amend budget
        public override float DayRate { get { return 300f; } }
        
        // Constructor passes through "Driver" as read-only job property
        public Driver() : base("Driver") { }

        // Invokes container collection
        protected override void DoJob()
        {
            BalanceSheet.CollectContainer(CONTAINERS_COLLECTED_PER_SHIFT);
        }
    }
}
