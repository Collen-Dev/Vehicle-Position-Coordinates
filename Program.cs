using System.Diagnostics;

namespace VehiclePositionLookup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching data for the sorted 10 coordinates...");

            Stopwatch sw = Stopwatch.StartNew();
                        
            // Fetch the sorted 10 coordinates
            Coord[] vehCoordinates = VehicleLookup.GetLookupCoordinates().OrderBy(x => x.Latitude).ToArray();

            Console.WriteLine("Reading binary file data...");
            // Fetch data from file
            List<VehiclePosition> data = DataFileParser.ReadVehiclesDataFile().OrderBy(x=>x.Latitude).ToList();

            // Focus on positions of interest
            VehiclePositionFinder.GetClosestVehicleCoordinates(data, vehCoordinates);

            // Check the duration
            sw.Stop();

            Console.WriteLine($"time taken: {sw.ElapsedMilliseconds}ms");

            Console.Read();            
        }
    }
}