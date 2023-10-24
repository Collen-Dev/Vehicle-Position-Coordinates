using System.Collections.Generic;
using System.Diagnostics;

namespace VehiclePositionLookup
{
    internal class VehiclePositionFinder
    {

        ////internal static void GetClosestVehicleCoordinates
        ////    (List<VehiclePosition> data,
        ////    Coord[] vehCoordinates)
        ////{
        ////    // Here we sort data in array form, to be used for Binary searching
        ////    // It's easier this way!

        ////    Stopwatch sw = Stopwatch.StartNew();

        ////    List<VehicleSummary> vehicleData = new List<VehicleSummary>();
        ////    var VehicleArray = data.OrderBy (v => v.Latitude).ToArray();
        ////    float[] sortedLatitudeCoordinates = data.Select(x => x.Latitude).OrderBy(x => x).ToArray();
        ////    float[] sortedLongitudeCoordinates = data.Select(x => x.Longitude).OrderBy(x => x).ToArray();
        ////    string[] sortedRegistration = data.Select(x => x.Registration).OrderBy(x => x).ToArray();

        ////    for (int i = 0; i < vehCoordinates.Length; i++)
        ////    {
        ////        int closestLatitudeIndex = VehiclePositionFinder.UseBinarySearchAlgorithm(sortedLatitudeCoordinates, vehCoordinates[i].Latitude);
        ////        float closestLatitudeCoordinate = sortedLatitudeCoordinates[closestLatitudeIndex];

        ////        int closestLongitudeIndex = VehiclePositionFinder.UseBinarySearchAlgorithm(sortedLongitudeCoordinates, vehCoordinates[i].Longitude);
        ////        float closestLongitudeCoordinate = sortedLongitudeCoordinates[closestLongitudeIndex];

        ////        vehicleData.Add(new VehicleSummary
        ////        {
        ////            LatitudePos = sortedLatitudeCoordinates[closestLatitudeIndex],
        ////            LongitudePos = sortedLongitudeCoordinates[closestLongitudeIndex],
        ////            Registration = sortedRegistration[closestLatitudeIndex]
        ////        });

        ////    }
        ////    sw.Stop();

        ////    foreach (var d in vehicleData)
        ////    {
        ////        // Print stats
        ////        Console.WriteLine(string.Concat(VehiclePosition.GetTextSummary(d.LatitudePos, 
        ////            d.LongitudePos,  
        ////            d.Registration)));
        ////    }

        ////    sw.Stop();

        ////    Console.WriteLine($"Time take to execute vehicle lookup: {sw.ElapsedMilliseconds}ms.");
        ////    Console.ReadLine();
        ////}

        //private static int UseBinarySearchAlgorithm(float[] sortedVehicleCoordinates,
        //    float targetCoordinate)
        //{
        //    int left = 0;
        //    int right = sortedVehicleCoordinates.Length - 1;
        //    int closestIndex = -1;

        //    while (left <= right)
        //    {
        //        int mid = left + (right - left) / 2;

        //        if (sortedVehicleCoordinates[mid] == targetCoordinate)
        //        {
        //            // Exact match found
        //            return mid; 
        //        }

        //        if (closestIndex == -1 || Math.Abs(sortedVehicleCoordinates[mid] - targetCoordinate) < Math.Abs(sortedVehicleCoordinates[closestIndex] - targetCoordinate))
        //        {
        //            // Update the closest index if this coordinate is closer
        //            closestIndex = mid; 
        //        }

        //        if (sortedVehicleCoordinates[mid] < targetCoordinate)
        //        {
        //            // closest match is toward the right side
        //            left = mid + 1;
        //        }
        //        else
        //        {
        //            // closest match is toward the left side
        //            right = mid - 1;
        //        }
        //    }

        //    return closestIndex;
        //}

        internal static void GetClosestVehicleCoordinates(
            List<VehiclePosition> vehiclePositionCoordinates
            , Coord[] lookupCoordinates)
        {

            var minLatitude = lookupCoordinates.Select(x => x.Latitude).Min();
            var maxLatitude = lookupCoordinates.Select(x => x.Latitude).Max();

            vehiclePositionCoordinates = vehiclePositionCoordinates
                    .Where(x => x.Latitude <= minLatitude
                    && x.Latitude <= maxLatitude).ToList();

            List<VehiclePosition> closestCoordinates = new List<VehiclePosition>();
            foreach (Coord lookup in lookupCoordinates)
            {

                foreach (VehiclePosition coordinate in vehiclePositionCoordinates
                                    .Where(x => x.Latitude <= lookup.Latitude))
                {                    
                    closestCoordinates.Add(coordinate);
                    break;
                }              
            }

            foreach (var d in closestCoordinates)
            {
                // Print stats
                Console.WriteLine(string.Concat(VehiclePosition.GetTextSummary(d.Latitude,
                    d.Longitude,
                    d.Registration)));
            };
        }

    }
}
