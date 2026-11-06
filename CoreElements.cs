namespace HomeApplianceMaintenance
{
    // تعريف التفويض (Delegate)
    public delegate void MaintenanceStatusHandler(string message);

    // واجهة (Interface) تحتوي على العمليات الأساسية
    public interface IApplianceOperations
    {
        void StartMaintenance();
        void CompleteMaintenance();
    }

    // فئة ثابتة (Static Class) للتحقق من البيانات
    public static class DataValidator
    {
        public static bool IsValidSerialNumber(string serialNumber)
        {
            return !string.IsNullOrEmpty(serialNumber) && serialNumber.Length >= 5;
        }
    }
}