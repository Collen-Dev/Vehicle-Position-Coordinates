using System.Reflection;
using System.Text;

namespace VehiclePositionLookup
{
    internal static class FileUtil
    {
        internal static DateTime Epoch => new DateTime(1970, 1, 1, 0, 0, 0, 0);

        internal static string GetLocalFilePath(string fileName) => FileUtil.GetLocalFilePath(string.Empty, fileName);

        internal static string GetLocalFilePath(string subDirectory, string fileName) => Path.Combine(FileUtil.GetLocalPath(subDirectory), fileName);

        internal static byte[] ToNullTerminatedString(string registration)
        {
            byte[] bytes = Encoding.Default.GetBytes(registration);
            byte[] terminatedString = new byte[bytes.Length + 1];
            bytes.CopyTo((Array)terminatedString, 0);

            return terminatedString;
        }

        internal static string GetLocalPath(string subDirectory)
        {
            string path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (subDirectory != string.Empty)
                path1 = Path.Combine(path1, subDirectory);

            return path1;
        }

        internal static ulong ToCTime(DateTime time) => Convert.ToUInt64((time - FileUtil.Epoch).TotalSeconds);

        internal static DateTime FromCTime(ulong cTime) => FileUtil.Epoch.AddSeconds((double)cTime);
    }
}
