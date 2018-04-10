using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // File system infos
using System.Globalization;
using System.Windows;


namespace far_manager_implementation
{
    class Program
    {
        // program variables
        static char VerticalBar = '│';
        private static FileSystemInfo[] PreviusArr;
        // program methods
        static void Welcome()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            // set default color for terminal output
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            int Lines = 24; // Console.WindowHeight;
            int Columns = 96; // Console.WindowWidth;
            // reset console window size
            Console.WindowWidth = Columns;
            Console.WindowHeight = Lines;
            // reset console buffer size
            Console.BufferWidth = Columns;
            Console.BufferHeight = Lines * 10;
            Console.Title = @"Far File manmager Implementation";
            string[] logolines = new string[25];
            logolines[0] = ".------.";
            logolines[1] = "|  .---',--,-..--.--.";
            logolines[2] = "|  `--,',-.  ||  .--'";
            logolines[3] = "|   --'( '-' ||  |";
            logolines[4] = "'--'    `--`-''--'";
            int lineindex = 4;
            foreach (string line in logolines)
            {
                lineindex++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition((Columns - 25) / 2, lineindex);
                Console.WriteLine(line);
            }
            string greeting = @"Hi this is far manager implementation, ...";
            string copyright = @"Copyright 2018 by Miras Outileu";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((Columns - greeting.Length) / 2, Lines / 2 - 1);
            Console.WriteLine(greeting);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Columns - copyright.Length) / 2, Lines / 2 - 0);
            Console.WriteLine(copyright);
            string[] man = new String[80];
            man[0] = @"Content";
            int lineid = Lines;
            foreach (string line in man)
            {
                lineid++;
                Console.SetCursorPosition(0, lineid);
                Console.WriteLine(line);
            }

            // last code
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
            Console.Clear();
        }
        static String TruncateLongString(String s, int splitLength)
        {
            return s.Substring(0, Math.Min(s.Length, splitLength));
        }
        static void termOutput(ConsoleColor textColor, ConsoleColor sepColor, Array collection)
        {
            foreach (var item in collection)
            {
                Console.ForegroundColor = textColor;
                Console.Write(item);
                Console.ForegroundColor = sepColor;
                Console.Write(Program.VerticalBar);
            }
        }
        /// <summary>
        /// Detect max between array string item length
        /// </summary>
        /// <param name="arr">FilesystemInfo</param>
        /// <returns>Integer</returns>
        static int detectMaxLength(FileSystemInfo[] arr)
        {
            var maxval = 0;
            // calculate(detect) max length for arr items
            for (int j = 0; j < arr.Length; ++j)
                if (maxval < arr[j].Name.Length)
                    maxval = arr[j].Name.Length;
            return maxval;
        }
        static void ViewFiles(int index, FileSystemInfo[] arr, int maxlen)
        {
            maxlen = (maxlen < 0) ? detectMaxLength(arr) : maxlen;
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i >= arr.Length) { break; }
                // typeOf
                if (arr[i].GetType() == typeof(DirectoryInfo)) { Console.ForegroundColor = ConsoleColor.White; }
                else if (arr[i].GetType() == typeof(FileInfo)) { Console.ForegroundColor = ConsoleColor.Green; }
                else { Console.ForegroundColor = ConsoleColor.Magenta; }
                // indexIs
                if (index == i) { Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black; }
                else { Console.BackgroundColor = ConsoleColor.Black; }

                maxlen = Console.WindowWidth - 1;
                int filling_space_count = Math.Abs(maxlen - arr[i].Name.Length);
                char fillingChar = ' ';
                String filling = new String(fillingChar, filling_space_count); // заполнение

                var itemName = arr[i].Name.ToString();
                var itemCreation = arr[i].CreationTime.ToString("yyyy-mm-dd HH:MM:SS", CultureInfo.CreateSpecificCulture("kk"));
                var itemAccessed = arr[i].LastAccessTime.ToString("yyyy-mm-dd HH:MM:SS", CultureInfo.CreateSpecificCulture("kk"));
                var itemModified = arr[i].LastWriteTime.ToString("yyyy-mm-dd HH:MM:SS", CultureInfo.CreateSpecificCulture("kk"));
                var itemExt = (arr[i].Extension.ToString().Length > 0) ? arr[i].Extension.ToString() : "    ";
                itemExt = (itemExt.Length < 4) ? new String(fillingChar, 4 - itemExt.Length) : itemExt;

                Console.Write(
                    itemCreation + Program.VerticalBar +
                    itemAccessed + Program.VerticalBar +
                    itemModified + Program.VerticalBar +
                    itemExt + Program.VerticalBar +
                    itemName + filling
                );
                Console.Write('\r'); // eol or Console.WriteLine(Program.VerticalBar);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth - 20, 25);
            Console.WriteLine("ESC for Quit.");

        }

        static void Main(string[] args)
        {
            Welcome();

            // root paramater for far manager
            String Root = @"C:\";

            DirectoryInfo di = new DirectoryInfo(Root);
            FileSystemInfo[] arr = di.GetFileSystemInfos();
            Program.PreviusArr = arr;
            // set first view
            int index = 0;
            bool quit = false;
            //int maxlen = Console.WindowWidth; //detectMaxLength(arr);

            // and loop in view form
            while (!quit)
            {
                // clear screen
                Console.Clear();
                ViewFiles(index, arr, 100);

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                Console.CursorVisible = false;
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0) index = arr.Length - 1;
                        Console.SetCursorPosition(0, index);
                        // selected item wrtie to title
                        try
                        {
                            Console.Title = arr[index].FullName.ToString() + "Attributes [ " + arr[index].Attributes + " ]";
                        }
                        catch (System.IndexOutOfRangeException e)
                        {
                            Console.Title = "?" + "Attributes [ " + arr[index].Attributes + " ]";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        // position for cursor
                        index = (index + 1) % arr.Length;
                        Console.SetCursorPosition(0, index);

                        // selected item wrtie to title
                        try
                        {
                            Console.Title = arr[index].FullName.ToString() + "Attributes [ " + arr[index].Attributes + " ]";
                        }
                        catch (System.IndexOutOfRangeException e)
                        {
                            Console.Title = "?" + "Attributes [ " + arr[index].Attributes + " ]";
                        }
                        break;

                    case ConsoleKey.LeftArrow: // goto back
                        Console.Clear();
                        // selected item is a directory type
                        arr = Program.PreviusArr;
                        index = 0;
                        int maxlen = detectMaxLength(arr);
                        ViewFiles(index, arr, maxlen);
                        break;
                    case ConsoleKey.RightWindows: // goto previus
                        break;
                    case ConsoleKey.Enter:
                        if (arr[index].GetType() == typeof(DirectoryInfo))
                        {
                            Console.Clear();
                            // selected item is a directory type

                            DirectoryInfo d = arr[index] as DirectoryInfo;
                            index = 0;
                            try { arr = d.GetFileSystemInfos(); }
                            catch (UnauthorizedAccessException uae)
                            {
                                // pass
                                // maybe used as a competent user or administration privilegies
                            }

                            maxlen = detectMaxLength(arr);
                            Console.WriteLine("count" + arr.Count());
                            try
                            {
                                if (arr.Length > Console.BufferHeight)
                                    // mem stack
                                    Console.BufferHeight = arr.Length;
                            }
                            catch (System.ArgumentOutOfRangeException ore)
                            {
                                // number of file in arr
                                // windowbuffer.lenght
                                // Console.BufferHeight = 1000;
                                // pass
                            }

                            ViewFiles(index, arr, maxlen);
                        }
                        break;
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}