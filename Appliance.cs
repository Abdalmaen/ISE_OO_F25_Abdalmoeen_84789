using System;

namespace HomeApplianceMaintenance
{
    // الفئة المجردة (Abstract Class) وتطبيق التغليف (Encapsulation)
    public abstract class Appliance : IApplianceOperations
    {
        public static int TotalRepairedAppliances { get; private set; } = 0;
        
        private readonly string _serialNumber;
        private string _status;
        private double _baseCost;

        public event MaintenanceStatusHandler OnMaintenanceCompleted;

        public string SerialNumber => _serialNumber;
        public string Status { get => _status; protected set => _status = value; }
        public double BaseCost { get => _baseCost; set => _baseCost = value > 0 ? value : 0; }

        public Appliance(string serialNumber, double baseCost)
        {
            if (!DataValidator.IsValidSerialNumber(serialNumber))
                throw new ArgumentException("Invalid Serial Number.");
            
            _serialNumber = serialNumber;
            _baseCost = baseCost;
            _status = "Pending";
        }

        public abstract double CalculateRepairCost();

        public void StartMaintenance()
        {
            Status = "In Progress";
            Console.WriteLine($"Appliance {SerialNumber} maintenance started.");
        }

        public void CompleteMaintenance()
        {
            Status = "Completed";
            TotalRepairedAppliances++;
            OnMaintenanceCompleted?.Invoke($"Repair completed for {this.GetType().Name} (SN: {SerialNumber}). Total Cost: {CalculateRepairCost()} SYP");
        }
    }
}