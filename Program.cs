using System;
using System.Collections.Generic;

namespace HomeApplianceMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            // استخدام قائمة لمعالجة الكائنات بتعدد الأشكال
            List<Appliance> maintenanceList = new List<Appliance>();

            var fridge = new Refrigerator("REF10023", 150000, 300000);
            var washer = new WashingMachine("WSH99211", 100000, 250000);
            var ac = new AirConditioner("AC55443", 80000, 50000);

            // الاشتراك بالحدث
            fridge.OnMaintenanceCompleted += ShowNotification;
            washer.OnMaintenanceCompleted += ShowNotification;
            ac.OnMaintenanceCompleted += ShowNotification;

            maintenanceList.Add(fridge);
            maintenanceList.Add(washer);
            maintenanceList.Add(ac);

            Console.WriteLine("--- Starting Daily Maintenance ---");
            foreach (var device in maintenanceList)
            {
                device.StartMaintenance();
            }

            Console.WriteLine("\n--- Processing Completed Tasks ---");
            double totalDailyRevenue = 0;
            
            foreach (var device in maintenanceList)
            {
                device.CompleteMaintenance();
                totalDailyRevenue += device.CalculateRepairCost();
            }

            Console.WriteLine($"\n[Summary] Total Repaired: {Appliance.TotalRepairedAppliances}");
            Console.WriteLine($"[Summary] Total Revenue: {totalDailyRevenue} SYP");
        }

        static void ShowNotification(string message)
        {
            Console.WriteLine($"[EVENT NOTIFICATION]: {message}");
        }
    }
}