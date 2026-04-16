using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public static class DisplaySwitch
{
    private const int ENUM_CURRENT_SETTINGS = -1;
    private const int CDS_UPDATEREGISTRY = 0x00000001;
    private const int CDS_SET_PRIMARY = 0x00000010;
    private const int CDS_NORESET = 0x10000000;
    private const int DISP_CHANGE_SUCCESSFUL = 0;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct DEVMODE
    {
        private const int CCHDEVICENAME = 32;
        private const int CCHFORMNAME = 32;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;

        public int dmPositionX;
        public int dmPositionY;
        public int dmDisplayOrientation;
        public int dmDisplayFixedOutput;

        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
        public string dmFormName;

        public short dmLogPixels;
        public int dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;

        public int dmDisplayFlags;
        public int dmDisplayFrequency;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct DISPLAY_DEVICE
    {
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        public int StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }

    [DllImport("user32.dll")]
    private static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

    [DllImport("user32.dll")]
    private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

    [DllImport("user32.dll")]
    private static extern int ChangeDisplaySettingsEx(string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd, uint dwFlags, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern int ChangeDisplaySettingsEx(string lpszDeviceName, IntPtr lpDevMode, IntPtr hwnd, uint dwFlags, IntPtr lParam);

    public static void SwitchToNextMonitor()
    {
        var displays = GetActiveDisplays();
        if (displays.Count <= 1)
            return;

        int currentPrimaryIndex = displays.FindIndex(d => d.IsPrimary);
        int nextIndex = (currentPrimaryIndex + 1) % displays.Count;

        var nextPrimary = displays[nextIndex];

        // Guarda posições originais
        var positions = new Dictionary<string, (int X, int Y)>();
        foreach (var d in displays)
            positions[d.DeviceName] = (d.DevMode.dmPositionX, d.DevMode.dmPositionY);

        // Coloca próximo monitor principal em 0,0
        nextPrimary.DevMode.dmPositionX = 0;
        nextPrimary.DevMode.dmPositionY = 0;

        ChangeDisplaySettingsEx(nextPrimary.DeviceName, ref nextPrimary.DevMode, IntPtr.Zero, CDS_SET_PRIMARY | CDS_UPDATEREGISTRY | CDS_NORESET, IntPtr.Zero);

        // Ajusta os outros monitores sem inverter posições
        foreach (var d in displays)
        {
            if (d.DeviceName == nextPrimary.DeviceName)
                continue;

            var pos = positions[d.DeviceName];
            d.DevMode.dmPositionX = pos.X - positions[nextPrimary.DeviceName].X;
            d.DevMode.dmPositionY = pos.Y - positions[nextPrimary.DeviceName].Y;

            ChangeDisplaySettingsEx(d.DeviceName, ref d.DevMode, IntPtr.Zero, CDS_UPDATEREGISTRY | CDS_NORESET, IntPtr.Zero);
        }

        // Aplica todas as mudanças
        ChangeDisplaySettingsEx(null, IntPtr.Zero, IntPtr.Zero, 0, IntPtr.Zero);
    }

    private static List<DisplayInfo> GetActiveDisplays()
    {
        var list = new List<DisplayInfo>();
        uint i = 0;
        DISPLAY_DEVICE dd = new DISPLAY_DEVICE();
        dd.cb = Marshal.SizeOf(dd);

        while (EnumDisplayDevices(null, i, ref dd, 0))
        {
            if ((dd.StateFlags & 0x1) != 0) // DISPLAY_DEVICE_ACTIVE
            {
                DEVMODE dm = new DEVMODE();
                dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
                if (EnumDisplaySettings(dd.DeviceName, ENUM_CURRENT_SETTINGS, ref dm))
                {
                    list.Add(new DisplayInfo
                    {
                        DeviceName = dd.DeviceName,
                        DevMode = dm,
                        IsPrimary = (dd.StateFlags & 0x4) != 0
                    });
                }
            }
            i++;
            dd = new DISPLAY_DEVICE();
            dd.cb = Marshal.SizeOf(dd);
        }

        return list;
    }

    private class DisplayInfo
    {
        public string DeviceName;
        public DEVMODE DevMode;
        public bool IsPrimary;
    }
}