using System;
using System.IO;
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
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "AvaloniaReader");
            }

            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".config", "AvaloniaReader");
        }
    }
}