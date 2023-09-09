namespace VehiclePositionLookup
{
    internal struct Coord
    {
        public float Latitude;
        public float Longitude;
    }

    internal class VehicleLookup
    {

        internal static Coord[] GetLookupCoordinates() => VehicleLookup.GetLookupPositions();
        // <summary>
        /// This method sets up the 10 coordinate to be used to search the data file
        /// for closest vehicles positions
        /// </summary>
        private static Coord[] GetLookupPositions()
        {
            Coord[] lookupPositions = new Coord[10];
            lookupPositions[0].Latitude = 34.544909f;
            lookupPositions[0].Longitude = -102.100843f;
            lookupPositions[1].Latitude = 32.345544f;
            lookupPositions[1].Longitude = -99.123124f;
            lookupPositions[2].Latitude = 33.234235f;
            lookupPositions[2].Longitude = -100.214124f;
            lookupPositions[3].Latitude = 35.195739f;
            lookupPositions[3].Longitude = -95.348899f;
            lookupPositions[4].Latitude = 31.895839f;
            lookupPositions[4].Longitude = -97.789573f;
            lookupPositions[5].Latitude = 32.895839f;
            lookupPositions[5].Longitude = -101.789573f;
            lookupPositions[6].Latitude = 34.115839f;
            lookupPositions[6].Longitude = -100.225732f;
            lookupPositions[7].Latitude = 32.335839f;
            lookupPositions[7].Longitude = -99.992232f;
            lookupPositions[8].Latitude = 33.535339f;
            lookupPositions[8].Longitude = -94.792232f;
            lookupPositions[9].Latitude = 32.234235f;
            lookupPositions[9].Longitude = -100.222222f;

            return lookupPositions;
        }
    }
}