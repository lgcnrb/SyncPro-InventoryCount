using System;
using System.Management;

public static class HardwareIdHelper
{
    public static string GetHardwareId()
    {
        string hardwareId = string.Empty;

        try
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    hardwareId = obj["UUID"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving hardware ID: {ex.Message}");
        }

        return hardwareId;
    }
}
