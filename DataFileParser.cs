
namespace VehiclePositionLookup
{
    public static class DataFileParser
    {
        internal static List<VehiclePosition> ReadVehiclesDataFile()
        {
            byte[] data = DataFileParser.ReadFileData();
            List<VehiclePosition> vehiclePositionList = new List<VehiclePosition>();
            int offset = 0;
            while (offset < data.Length)
                vehiclePositionList.Add(DataFileParser.ReadVehiclePosition(data, ref offset));
            return vehiclePositionList;
        }

        internal static List<VehiclePosition> ReadDataFile()
        {
            byte[] data = DataFileParser.ReadFileData();
            List<VehiclePosition> vehiclePositionList = new List<VehiclePosition>();
            int offset = 0;
            while (offset < data.Length)
                vehiclePositionList.Add(DataFileParser.ReadVehiclePosition(data, ref offset));
            return vehiclePositionList;
        }

        private static byte[] ReadFileData()
        {
            string localFilePath = FileUtil.GetLocalFilePath("VehiclePositions.dat");
            if (File.Exists(localFilePath))
                return File.ReadAllBytes(localFilePath);
            Console.WriteLine("Data file not found.");
            return (byte[])null;
        }

        private static VehiclePosition ReadVehiclePosition(byte[] data, ref int offset) => VehiclePosition.FromBytes(data, ref offset);
    }
}
