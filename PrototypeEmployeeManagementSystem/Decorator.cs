using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeEmployeeManagementSystem
{
    internal class Decorator : Employee
    {
        // Decorator output per shift
        public const float CONTAINERS_REFURBISHED_PER_SHIFT = 4f;

        // Cost per shift
        public override float DayRate { get { return 120f; } }

        // Decorator constructor passes through "Decorator" as read-only job property
        public Decorator() : base("Decorator") { }

        // Invoke container refurbishment
        protected override void DoJob()
        {
            BalanceSheet.RefurbishContainer(CONTAINERS_REFURBISHED_PER_SHIFT);
        }
    }
}
