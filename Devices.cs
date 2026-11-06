namespace HomeApplianceMaintenance
{
    // الوراثة وتعدد الأشكال - 3 فئات فرعية
    public class Refrigerator : Appliance
    {
        private double _compressorCost;
        public Refrigerator(string serialNumber, double baseCost, double compressorCost) : base(serialNumber, baseCost)
        {
            _compressorCost = compressorCost;
        }
        public override double CalculateRepairCost() => BaseCost + _compressorCost + 50000;
    }

    public class WashingMachine : Appliance
    {
        private double _motorCost;
        public WashingMachine(string serialNumber, double baseCost, double motorCost) : base(serialNumber, baseCost)
        {
            _motorCost = motorCost;
        }
        public override double CalculateRepairCost() => BaseCost + _motorCost + 25000;
    }

    public class AirConditioner : Appliance
    {
        private double _cleaningCost;
        public AirConditioner(string serialNumber, double baseCost, double cleaningCost) : base(serialNumber, baseCost)
        {
            _cleaningCost = cleaningCost;
        }
        public override double CalculateRepairCost() => BaseCost + _cleaningCost;
    }
}