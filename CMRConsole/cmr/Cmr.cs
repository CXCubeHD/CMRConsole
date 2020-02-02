using Chrones.Cmr.Imports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Chrones.Cmr
{
    public class cmr
    {
        public static void EnableVirtualTerminalProcessing()
        {
            IntPtr hOut = Import.GetStdHandle(-11);
            UInt32 dwMode;
            Import.GetConsoleMode(hOut, out dwMode);
            Import.SetConsoleMode(hOut, dwMode | 0x4);
        }

        public static void cout()
        {

        }

        public static string cin()
        {
            return "";
        }

        public static void cli()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        #region ConsoleText

        public static string cf(uint r, uint g, uint b)
        {
            string _return = "\x1b[38;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }
        public static string cf(int r, int g, int b)
        {
            string _return = "\x1b[38;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }

        public static string cb(uint r, uint g, uint b)
        {
            string _return = "\x1b[48;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }
        public static string cb(int r, int g, int b)
        {
            string _return = "\x1b[48;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }

        public static string cr()
        {
            var _return = cfr() + cbr();
            return _return;
        }
        public static string cfr()
        {
            string _return = "\x1b[39m";
            return _return;
        }

        public static string cbr()
        {
            string _return = "\x1b[49m";
            return _return;
        }

        public static string tb()
        {
            string _return = "\x1b[1m";
            return _return;
        }

        public static string tu()
        {
            string _return = "\x1b[4m";
            return _return;
        }

        public static string tn()
        {
            string _return = "\x1b[7m";
            return _return;
        }

        public static string tr()
        {
            string _return = "\x1b[0m";
            return _return;
        }

        #region var
        public static readonly string esc = "\x1b[";
        #endregion

        #endregion

        #region ConsoleWindow
        public static void CenterConsole()
        {
            IntPtr hwnd = Import.GetConsoleWindow();
            Import.RECT rectWindow;
            Import.GetWindowRect(hwnd, out rectWindow);

            int screen_width = Import.GetSystemMetrics(Import.SystemMetric.SM_CXSCREEN);
            int screen_height = Import.GetSystemMetrics(Import.SystemMetric.SM_CYSCREEN);
            int console_width = (rectWindow.right - rectWindow.left);
            int console_height = (rectWindow.bottom - rectWindow.top);

            Import.SetWindowPos(hwnd,(IntPtr)0,(screen_width - console_width) / 2, (screen_height - console_height) / 2, 0, 0, 1);
        }
        
        public static void MaximizeConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 3);
        }

        public static void MinimizeConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 6);
        }

        public static void HideConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 0);
        }

        public static void RestoreConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 9);
        }

        public static void FullscreenConsole()
        {
            Import.COORD zero = new Import.COORD(100,100);
            Import.SetConsoleDisplayMode(Import.GetStdHandle(Import.STD_OUTPUT_HANDLE), 1, out zero);

            IntPtr hConsole = Import.GetStdHandle(-11);   // get console handle
            Import.COORD xy = new Import.COORD(100, 100);
            //Import.SetConsoleDisplayMode(hConsole, 1, out xy); // set the console to fullscreen
            Import.SetConsoleDisplayMode(hConsole, 2, out xy);
        }

        public static void FullscreenWindowedConsole()
        {

        }
        #endregion

        public static bool DownloadFileFromURL()
        {
            return false;
        }
    }
}
