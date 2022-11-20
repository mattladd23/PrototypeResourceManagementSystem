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
        public const float RISK_CONSIDERATION = .75f;
        public const float WARNING_BALANCE = 1000f;
        private static float balance = 10000f;
        private static float refurbishedContainers = 50f;
        private static float usedContainers = 100f;

        public static void CollectContainer(float quantity)
        {
            if (quantity > 0f) usedContainers += quantity;
        }

        public static void RefurbishContainer(float quantity)
        {
            float containersToRefurbish = quantity;            
            usedContainers -= containersToRefurbish;
            refurbishedContainers += containersToRefurbish * RISK_CONSIDERATION;
        }

        public static bool PayEmployee(float amount)
        {
            if (balance > amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

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
