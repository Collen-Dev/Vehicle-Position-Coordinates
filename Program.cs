using System.Diagnostics;

namespace VehiclePositionLookup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching data for the sorted 10 coordinates...");

            // Fetch the sorted 10 coordinates
            Coord[] vehCoordinates = VehicleLookup.GetLookupCoordinates().OrderBy(x => x.Latitude).ToArray();

            Console.WriteLine("Reading binary file data...");
            // Fetch data from file
            List<VehiclePosition> data = DataFileParser.ReadVehiclesDataFile().OrderBy(x=>x.Latitude).ToList();

            Console.WriteLine("Start processing data using binary search algorithm...");
            Console.WriteLine("");
            VehiclePositionFinder.GetClosestVehicleCoordinates(data, vehCoordinates);
        }
    }
}