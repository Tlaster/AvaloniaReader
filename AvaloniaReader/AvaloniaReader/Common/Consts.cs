using System.Runtime.InteropServices;

namespace AvaloniaReader.Common;

internal static class Consts
{
    public static string DocumentDirectory
    {
        get
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return System.IO.Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                    "AvaloniaReader");
            }
            return System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile),
                ".config", "AvaloniaReader");   
        }
    }
}
