using System.Text;

namespace VehiclePositionLookup
{
    internal class VehiclePosition
    {
        public int ID;
        public string Registration;
        public float Latitude;
        public float Longitude;
        public DateTime RecordedTimeUTC;

        internal byte[] GetBytes()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange((IEnumerable<byte>)BitConverter.GetBytes(this.ID));
            byteList.AddRange((IEnumerable<byte>)FileUtil.ToNullTerminatedString(this.Registration));
            byteList.AddRange((IEnumerable<byte>)BitConverter.GetBytes(this.Latitude));
            byteList.AddRange((IEnumerable<byte>)BitConverter.GetBytes(this.Longitude));
            byteList.AddRange((IEnumerable<byte>)BitConverter.GetBytes(FileUtil.ToCTime(this.RecordedTimeUTC)));
            
            return byteList.ToArray();
        }

        internal static string GetTextSummary(float vehLatitude, float vehLongitude, string vehReg) 
            => string.Concat( $"{vehReg}".PadRight(15), $"{vehLatitude}".PadRight(10), $"{vehLongitude}".PadRight(10));

        internal static VehiclePosition FromBytes(byte[] buffer, ref int offset)
        {
            VehiclePosition vehiclePosition = new VehiclePosition();
            vehiclePosition.ID = BitConverter.ToInt32(buffer, offset);
            offset += 4;

            StringBuilder stringBuilder = new StringBuilder();

            while (buffer[offset] != (byte)0)
            {
                stringBuilder.Append((char)buffer[offset]);
                ++offset;
            }

            vehiclePosition.Registration = stringBuilder.ToString();
            ++offset;

            vehiclePosition.Latitude = BitConverter.ToSingle(buffer, offset);
            offset += 4;

            vehiclePosition.Longitude = BitConverter.ToSingle(buffer, offset);
            offset += 4;

            ulong uint64 = BitConverter.ToUInt64(buffer, offset);
            vehiclePosition.RecordedTimeUTC = FileUtil.FromCTime(uint64);
            offset += 8;

            return vehiclePosition;
        }

    }
}
