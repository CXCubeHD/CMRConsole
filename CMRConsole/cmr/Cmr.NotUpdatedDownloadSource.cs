using Chrones.Cmr.Font;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chrones.Cmr.NotUpdatedDownloadSource
{
    public class cmr_notupdateddownloadsource
    {
        public static void StartScreen()
        {
            cmr_font.SetConsoleFont("Consolas", 9, 28);
            cmr.CenterConsole();
            cmr.MaximizeConsole();

            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = 50;

            Console.Title = @"CMRConsole - Install the new installer";
            Console.Write(cmr.cb(70, 70, 70) + cmr.cf(70, 70, 70));
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
            #region Wrong Version
            cmr.cli();
            Console.Write("Please download the new installer - the downloadsource of the CMRConsole has been changed!\n");
            Console.Write(cmr.cf(255, 245, 56) + "Press" + cmr.cfr() + " [" + cmr.cf(255, 71, 71) + "1" + cmr.cfr() + "] " + cmr.cf(235, 255, 184) + "to download the new installer" + cmr.cfr() + " or " + cmr.cf(255, 71, 71) + "any other key" + cmr.cfr() + " " + cmr.cf(235, 255, 184) + "to exit" + cmr.cfr() + ".\n");
            Console.Write("[You] < " + cmr.cf(48, 255, 231));
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            string input = consoleKeyInfo.KeyChar.ToString();
            Console.Write(cmr.cfr() + "\n");
            if (input == "1")
            {
                Console.Write(cmr.cf(150, 150, 150) + "Opening the FolderSelectingWindow\n");
                Thread t1 = new Thread(OpenFileDialog_);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
            else
            {
                Console.Write(cmr.cf(150, 150, 150) + "Closing...");
                Thread.Sleep(500);
                Environment.Exit(0);
            }
            #endregion
        }

        public static void OpenFileDialog_()
        {
            string address = @"https://raw.githubusercontent.com/CXCubeHD/CMR_Setup/master/CMR_Setup.exe";

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //MessageBox.Show("Files found: " + files.Length.ToString(), "Message");1
                    Console.Write("Path selected: " + fbd.SelectedPath + "\\CMR_Setup.exe\n" + cmr.cfr());
                    Console.Write("Do you want " + cmr.cf(235, 255, 184) + "to download " + cmr.cf(255, 184, 112) + "CMR_Setup" + cmr.cfr() + " to " + cmr.cf(135, 253, 255) + fbd.SelectedPath + "\\CMR_Setup.exe" + cmr.cfr() + " ?\n" + cmr.cfr());
                    Thread.Sleep(1000);
                    Console.Write(cmr.cf(255, 245, 56) + "Press" + cmr.cfr() + " [" + cmr.cf(255, 71, 71) + "y" + cmr.cfr() + "] " + cmr.cf(235, 255, 184) + "to download " + cmr.cf(255, 184, 112) + "CMR_Setup" + cmr.cfr() + " or " + cmr.cf(255, 71, 71) + "any other key" + cmr.cf(235, 255, 184) +" to cancel and exit\n" + cmr.cfr());
                    Console.Write("[You] < " + cmr.cf(48, 255, 231));
                    cmr.cli();
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    string input = consoleKeyInfo.KeyChar.ToString();
                    Console.Write(cmr.cfr() + "\n");

                    if (input == "y")
                    {
                        bool error = false;
                        Console.Title = @"CMRConsole - Installing the new installer";
                        Console.Write(cmr.cf(150, 150, 150) + "Installing... - Do not close the process\n");
                        try
                        {
                            WebClient wbc = new WebClient();
                            wbc.DownloadFile(address, fbd.SelectedPath + "\\CMR_Setup.exe");
                        }
                        catch (WebException we)
                        {
                            error = true;
                            Console.Title = @"CMRConsole - Error!";
                            MessageBox.Show(we.ToString());
                            Console.Write(cmr.cf(255, 0, 0) + "! There was a Error: " + cmr.cf(176, 176, 176) + we.ToString() + "\n");
                            Console.Write(cmr.cf(150, 150, 150) + "CMR_Setup was not installed.\n");
                            cmr.cli();
                            Console.Write(cmr.cf(255, 255, 255) + "Press any key to exit");
                            Console.ReadKey();
                        }
                        Thread.Sleep(500);
                        Console.Title = @"CMRConsole - Succes!";
                        Console.Write(cmr.cf(150, 150, 150) + "Succes!\n");
                        Console.Write(cmr.cf(255, 255, 255) + "Press any key to exit");
                        cmr.cli();
                        Console.ReadKey();
                        Environment.Exit(0);
                    } else
                    {
                        Console.Write(cmr.cf(150, 150, 150) + "Closing...");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
