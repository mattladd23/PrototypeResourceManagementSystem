using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeEmployeeManagementSystem
{
    internal static class BalanceSheet
    {        
        // Declare variables to determine financial outlook
        public const float RISK_CONSIDERATION = .85f;
        public const float WARNING_BALANCE = 1000f;
        public static float balance = 10000f;
        private static float refurbishedContainers = 50f;
        private static float usedContainers = 100f;

        // Container collection method usually invoked by driver instances
        public static void CollectContainer(float quantity)
        {
            // Check quantity passed through is a positive value
            if (quantity > 0f) usedContainers += quantity;
        }

        // Container refurbishment method usually invoked by decorators
        public static void RefurbishContainer(float quantity)
        {
            // Assign quantity argument to variable
            float containersToRefurbish = quantity;
            
            // One less used container
            usedContainers -= containersToRefurbish;

            // Increment refurbished containers while allowing for up to 15% of containers to be rejected
            refurbishedContainers += containersToRefurbish * RISK_CONSIDERATION;
        }
              
        // Method to pay employee according to day rate variable which is declared in the sublasses of employee
        public static bool PayEmployee(float amount)
        {
            // Check budget constraints
            if (balance > amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        // Method to print a message reporting containers stock and a budget warning if necessary
        public static string StatusReport
        {
            get
            {
                string status = $"{refurbishedContainers} refurbished containers\n" +
                                $"{usedContainers} used containers";

                string warnings = "";

                if (balance < WARNING_BALANCE) warnings +=
                        "\nLOW BALANCE - Please contact accounts";

                return status + warnings;
            }
        }
    }
}
