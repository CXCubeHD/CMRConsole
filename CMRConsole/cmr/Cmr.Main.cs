﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chrones.Cmr;
using Chrones.Cmr.Font;
using Chrones.Cmr.NotUpdatedDownloadSource;

namespace Chrones.Cmr.Main
{
    public class cmr_main
    {
        public static void CMR_MAIN(string[] args)
        {
            Console.Title = @"CMRConsole";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            cmr.EnableVirtualTerminalProcessing();
            cmr_notupdateddownloadsource.StartScreen();
        }

        public static void StartScreen()
        {
            cmr_font.SetConsoleFont("Consolas", 9, 19);
            cmr.CenterConsole();
            cmr.MaximizeConsole();
            Console.Write(cmr.cb(70,70,70) + cmr.cf(70,70,70));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cf(198, 148, 255));
            Console.Write(" Welcome to the                                                                       \n"); Console.Write(cmr.cf(70, 70, 70));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cf(148, 209, 255));
            Console.Write("                          ██████████  ██        ██  ████████                          \n");
            Console.Write("                          ██          ████    ████  ██    ██                          \n");
            Console.Write("                          ██          ██  ████  ██  ████████                          \n");
            Console.Write("                          ██          ██        ██  ████                              \n");
            Console.Write("                          ██          ██        ██  ██  ██                            \n");
            Console.Write("                          ██████████  ██        ██  ██    ██                          \n"); Console.Write(cmr.cf(70, 70, 70));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cf(255, 228, 138));
            Console.Write(" ██████████  ██████████  ██        ██  ██████████  ██████████  ██          ██████████ \n");
            Console.Write(" ██          ██      ██  ████      ██  ██          ██      ██  ██          ██         \n");
            Console.Write(" ██          ██      ██  ██  ██    ██  ██████████  ██      ██  ██          ██████████ \n");
            Console.Write(" ██          ██      ██  ██    ██  ██          ██  ██      ██  ██          ██         \n");
            Console.Write(" ██          ██      ██  ██      ████          ██  ██      ██  ██          ██         \n");
            Console.Write(" ██████████  ██████████  ██        ██  ██████████  ██████████  ██████████  ██████████ \n"); Console.Write(cmr.cf(70, 70, 70));
            Console.Write("######################################################################################\n");
            Console.Write("######################################################################################\n");
            Console.Write("######################################################################################\n"); Console.Write(cmr.cr());
            Console.ReadKey();
        }

    }
}
