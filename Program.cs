using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace wit_cmd_helper
{
    internal class Program
    {
        static string path;
        static string dir;
        static string name;
        static string ext;
        static char sep = Path.DirectorySeparatorChar;
        delegate void del();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.Title = "Wit-Cmd-Helper - Main Menu";
                Console.WriteLine(@"-- Main Menu --

- For the disk image -
1. Convert      --- Convert image file formats, such as WBFS to ISO and vice versa.
2. Extract      --- Extract all files in the image file while maintaining the directory tree.
3. Create       --- Create image files such as WBFS and ISO.

- Other -
4. Change Game ID       --- Change the Game ID of the image file.
5. Change Save Data     --- Change the save data when using the image file.

0. Exit");
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.Clear();
                        Console.Write("See you!");
                        Environment.Exit(0);
                        break;
                    case "1":
                        Convert();
                        break;
                    case "2":
                        Extract();
                        break;
                    case "3":
                        Create();
                        break;
                    case "4":
                        ChangeGameID();
                        break;
                    case "5":
                        ChangeSaveData();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error: Invalid input");
                        Console.ResetColor();
                        Thread.Sleep(1600);
                        break;
                }
            }
        }

        static void Convert()
        {
            Console.Clear();
            Console.Title = "Wit-Cmd-Helper - Convert image file formats. . .";
            GetPath(false);
            Console.WriteLine("Selected image : " + name + ext);
            Check(Convert);
            if (ext == ".wbfs") cmd("copy \"" + path + "\" \"" + dir + sep + name + ".iso\"");
            else cmd("copy \"" + path + "\" \"" + dir + sep + name + ".wbfs\"");
        }

        static void Extract()
        {
            Console.Clear();
            Console.Title = "Wit-Cmd-Helper - Extract all files in the image file. . .";
            GetPath(false);
            Console.WriteLine("Do you want to set a folder name?(y/N)");
            string result = ReadLineWithCancel();
            Console.Clear();
            if (result == "y" || result == "Y")
            {
                Console.WriteLine("Set your own folder names: Yes\nPlease enter the folder name you want.");
                name = ReadLineWithCancel();
            }
            else
            {
                Console.WriteLine("Set your own folder names: No");
                name += ".tmp";
            }
            Console.Clear();
            Console.WriteLine("Selected image  : " + Path.GetFileName(path) + "\nSet folder name : " + name);
            Check(Extract);
            cmd("extract \"" + path + "\" \"" + dir + sep + name + "\"");
        }

        static void Create()
        {
            Console.Clear();
            Console.Title = "Wit-Cmd-Helper - Create image file. . .";
            GetPath(true);
            string ex = "";
            while (ex != "w" && ex != "i")
            {
                Console.WriteLine("Set the image file extension to be WBFS(w)/ISO(i)");
                ex = ReadLineWithCancel();
            }
            if (ex == "w") ex = "wbfs";
            else ex = "iso";
            Console.Clear();
            Console.WriteLine("Do you want to set a image file name?(y/N)");
            string result = ReadLineWithCancel();
            Console.Clear();
            if (result == "y" || result == "Y")
            {
                Console.WriteLine("Please enter image file name.");
                name = ReadLineWithCancel();
            }
            Console.Clear();
            Console.WriteLine("Selected folder : " + Path.GetFileName(path) + "\nSet image name  : " + name + "." + ex);
            Check(Create);
            cmd("copy \"" + path + "\" \"" + dir + sep + name + "." + ex + "\"");
        }

        static void ChangeGameID()
        {
            Console.Clear();
            Console.Title = "Wit-Cmd-Helper - Change Game ID. . .";
            GetPath(false);
            string id = "";
            while (id.Length != 6)
            {
                Console.Clear();
                Console.WriteLine("Please enter Game ID. (length: 6)\nex: RMCJ01");
                id = ReadLineWithCancel();
            }
            Console.Clear();
            Console.WriteLine("Selected image : " + name + ext + "\nSet Game ID    : " + id);
            Check(ChangeGameID);
            cmd("edit \"" + path + "\" --disc-id " + id);
        }

        static void ChangeSaveData()
        {
            Console.Clear();
            Console.Title = "Wit-Cmd-Helper - Change Save Data. . .";
            GetPath(false);
            string sd = "";
            while (sd.Length != 4)
            {
                Console.Clear();
                Console.WriteLine("Please enter Save Data ID. (length: 4)\nex: RMCJ");
                sd = ReadLineWithCancel();
            }
            Console.Clear();
            Console.WriteLine("Selected image   : " + name + ext + "\nSet Save Data ID : " + sd);
            Check(ChangeSaveData);
            cmd("edit \"" + path + "\" --ticket-id " + sd + " --tmd-id " + sd + " --tt-id " + sd);
        }

        static void Check(del func)
        {
            Console.WriteLine("\nAre you sure you're OK?(Y/n)");
            string result = ReadLineWithCancel();
            if (result == "n" || result == "N") func();
            Console.Clear();
        }

        static void GetPath(bool isFolder)
        {
            path = ""; dir = ""; name = ""; ext = "";
            while (true)
            {
                if (isFolder) Console.WriteLine("Please drag and drop the disk image folder.");
                else Console.WriteLine("Please drag and drop the disk image.");
                path = ReadLineWithCancel().Trim().Trim('"', '\'');
                dir = Path.GetDirectoryName(path);
                name = Path.GetFileNameWithoutExtension(path);
                ext = Path.GetExtension(path);
                if (isFolder && Directory.Exists(path)) break;
                else if (ext == ".wbfs" || ext == ".iso" && File.Exists(path)) break;
            }
            Console.Clear();
        }

        static string ReadLineWithCancel()
        {
            string result = null;
            StringBuilder buffer = new StringBuilder();
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
            {
                if (info.Key == ConsoleKey.Backspace)
                {
                    if (Console.CursorLeft != 0)
                    {
                        Console.CursorLeft -= 1;
                        Console.Write(" ");
                        Console.CursorLeft -= 1;
                    }
                    if (buffer.Length != 0) buffer.Remove(buffer.Length - 1, 1);
                }
                else
                {
                    buffer.Append(info.KeyChar);
                    Console.Write(info.KeyChar);
                }
                info = Console.ReadKey(true);
            }
            if (info.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                result = buffer.ToString();
            }
            if (info.Key == ConsoleKey.Escape) Main();
            return result;
        }

        static void cmd(string arguments)
        {
            int ec;
            Process p = new Process();
            p.StartInfo.FileName = "wit";
            p.StartInfo.Arguments = arguments;
            p.Start();
            p.WaitForExit();
            ec = p.ExitCode;
            p.Close();
            if (ec == 0) Console.Write("\nComplete!\n\nPress any key to continue . . .");
            else Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }
    }
}
