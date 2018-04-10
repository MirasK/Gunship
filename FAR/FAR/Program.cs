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
        /* ================================================================== */
        // program variables
        const string  author = @"Miras Kuandyk";
        const string   email = @"mirkrokok0@gmail.com";
        const string version = "1.0.0";
        const string copyright = @"Copyright 2018 by MirCorporation";
        static char VerticalBar = '│'; // urf-8 symbol  ascii-box-code -- vertical side
        static char HorizontalBar = '─'; // ...
        private static FileSystemInfo[] PreviusArr;
        private static int ExtensionLen = 11;
        /* ================================================================== */
        // program methods
        static void Welcome()
        {
            Console.CursorVisible = false; // ey tiy kurson bolshe ne hochu videt tebya na eta terminal form
            Console.ResetColor(); // do systemnaya konfigurasya snimaetsya.

            // set default color for terminal output
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            int Lines = 24; // Console.WindowHeight;
            int Columns = 126; // Console.WindowWidth;
            // reset console window size
            Console.WindowWidth = Columns;
            Console.WindowHeight = Lines;
            // reset console buffer size
            Console.BufferWidth = Columns;
            Console.BufferHeight = Lines * 10;

            Console.Title = @"FAR manager from MirCorps.";

            // manual -- rukovodstvo polzvatelya
            

            string[] logolines = new string[70];
            logolines[0] = "0000000000    0     000000000      000       000 000000 000000000     ";
            logolines[1] = "0000000000    0     00       0     000       000   00   00       0    ";
            logolines[2] = "00           0 0    00        0    00 0     0 00   00   00        0   ";
            logolines[3] = "00           0 0    00         0   00 0     0 00   00   00         0  ";
            logolines[4] = "0000000000  0   0   00        0    00  0   0  00   00   00        0   ";
            logolines[5] = "0000000000  0   0   0000000000     00   0 0   00   00   0000000000    ";
            logolines[6] = "00         0000000  00        0    00    0    00   00   00        0   ";
            logolines[7] = "00         0     0  00         0   00         00   00   00         0  ";
            logolines[8] = "00        0       0 00          0  00         00   00   00          0 ";
            logolines[9] = "00        0       0 00           0 00         00 000000 00           0";

            // output for logo array
            int lineindex = 0;
            foreach (string line in logolines)
            {
                lineindex++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition((Columns - 65) / 2, lineindex);
                Console.WriteLine(line);
            }

            string greeting = @"Hi! All rights reserved. P. S.: don't try expose me, all the same you won't have success...:)";
            string copyright = @"Copyright 2018 by Miras Kuandyk";
            Console.ForegroundColor = ConsoleColor.Yellow;
            int posxg = (Columns - greeting.Length) / 2; // g == greeting
            int posyg = Lines / 2 - 1;
            Console.SetCursorPosition(posxg, posyg);
            Console.WriteLine(greeting);
            Console.ForegroundColor = ConsoleColor.White;
            int posxc = (Columns - copyright.Length) / 2;
            int posyc = Lines / 2;
            Console.SetCursorPosition(posxc, posyc);
            Console.WriteLine(copyright);

            string[] imagelines = new string[25];
            imagelines[0] = ".------.";
            imagelines[1] = "|  .---',--,-..--.--.";
            imagelines[2] = "|  `--,',-.  ||  .--'";
            imagelines[3] = "|   --'( '-' ||  |";
            imagelines[4] = "'--'    `--`-''--'";

            int lineindex2 = Lines / 2 + 1;
            foreach (string line in imagelines)
            {
                lineindex2++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((Columns - 20) / 2, lineindex2);
                Console.WriteLine(line);
            }
            
            //
            //
            //
            string[] man = new String[80];
            man[0] = @"── Help ────────────────────────────────────────────────";
            man[1] = @"far.exe  - Far file manager implementation.";
            man[2] = @"usage: C:/far.exe";
            man[3] = @"press any key to start work";
            man[4] = @"press 'UpArrow' or 'DownArrow' to flip through files";
            man[5] = @"press 'Enter' to open file";
            man[6] = @"press 'LeftArrow' to return to previous page";
            man[7] = @"press 'Escape' to escape from application";
            man[8] = @"";
            man[9] = @"";
            man[10] = @"";
            man[11] = @"";
            man[12] = @"";
            man[13] = @"";
            man[14] = @"";

            // output for man (manual)
            int lineid = Lines;
            foreach (string line in man)
            {
                lineid++;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, lineid);
                Console.WriteLine(line);
            }

            // last code
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
            //Console.Clear();
        } //

        static String TruncateLongString(string s, int splitLength)
        {
            /*
             * int == Integer str, string == String 
            0         1  
            01234567890123456789 
            abrakdabrabadabraka
                       |
                       TruncateLongString(@"abrakdabrabadabraka", 11);
             */
            return s.Substring(0, Math.Min(s.Length, splitLength)) + "...";
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
            int maxval = 0;
            // calculate max length for item := arr[x].Name
            for (int j = 0; j < arr.Length; ++j)
                if (maxval < arr[j].Name.Length)
                    maxval = arr[j].Name.Length;
            return maxval;
        }

        static void ViewItems(int index, FileSystemInfo[] arr, int maxlen)
        {
            Console.Clear();
            maxlen = (maxlen < 0) ? detectMaxLength(arr) : maxlen;
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i >= arr.Length)
                {
                    break;
                }
                // typeOf
                if (arr[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (arr[i].GetType() == typeof(FileInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                // indexIs
                if (index == i)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
               

                maxlen = Console.WindowWidth - 1;

                int filling_space_count = Math.Abs(maxlen - arr[i].Name.Length);
                char fillingChar = ' ';
                String filling = new String(fillingChar, filling_space_count); // заполнение
                String BlankExtension = new String(fillingChar, ExtensionLen);

                string itemName = arr[i].Name.ToString();
                string itemExtension = arr[i].Extension.Trim();

                string itemCreation = arr[i].CreationTime.ToString("yyyy-mm-dd HH:MM:ss",   CultureInfo.CreateSpecificCulture("EN-US"));
                string itemAccessed = arr[i].LastAccessTime.ToString("yyyy-mm-dd HH:MM:ss", CultureInfo.CreateSpecificCulture("RU"));
                string itemModified = arr[i].LastWriteTime.ToString("yyyy-mm-dd HH:MM:ss",  CultureInfo.CreateSpecificCulture("KK"));

                string itemNewExt = "";

                if (itemExtension.Length > 0)
                {
                    if (itemExtension.Length < Program.ExtensionLen)
                        itemNewExt = itemExtension + new String(fillingChar, ExtensionLen - itemExtension.Length);
                }
                else
                {
                    itemNewExt = BlankExtension;
                }

                // 
                Console.Write(itemCreation);
                //Console.ResetColor();
                Console.Write(Program.VerticalBar);
                Console.Write(itemAccessed);
                //Console.ResetColor();
                Console.Write(Program.VerticalBar);
                //Console.ResetColor();
                Console.Write(itemModified);
                //Console.ResetColor();
                Console.Write(Program.VerticalBar);
                //Console.ResetColor();
                Console.Write(itemNewExt);
                //Console.ResetColor();
                Console.Write(Program.VerticalBar);
                Console.Write(
                    itemName + filling
                );
                Console.Write('\r'); // \r = return eol or Console.WriteLine(Program.VerticalBar);
            }
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(Console.WindowWidth - 15, Console.WindowHeight - 1);
            Console.WriteLine("ESC for Exit.");

        }

        //static void Main(string[] args)
        //{
        //    string snachala = "Miras Kuandyk";
        //    string potom;
        //    potom = TruncateLongString(snachala, 5);
        //    Console.WriteLine("snachala.: " + snachala);
        //    Console.WriteLine("potom....: " + potom);
        //    Console.ReadKey();
        //}

        

        static void Main(string[] args)
            {
                // welcome form
                Welcome();

            // root paramater for far manager
            String Root = @"C:\";
            DirectoryInfo d = new DirectoryInfo(Root);
            FileSystemInfo[] arr = d.GetFileSystemInfos();
            PreviusArr = arr;

            // set first view
            int index = 0;
            bool quit = false;

            // and loop in view form
            while (!quit)
            {
                // clear screen
               //Console.Clear();

                ViewItems(index, arr, detectMaxLength(arr));

                ConsoleKeyInfo pressedKey = Console.ReadKey();  // from keyboard

                Console.CursorVisible = false;

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0)
                        {
                            index = arr.Length - 1;
                        }
                        Console.SetCursorPosition(0, index);
                        // selected item wrtie to title
                        try
                        {
                            Console.Title = arr[index].FullName.ToString() + " -- this attributes [ " + arr[index].Attributes + " ]";
                        }
                        catch (System.IndexOutOfRangeException e)
                        {
                            Console.Title = "?" + " -- this attributes [ " + arr[index].Attributes + " ]";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        // position for cursor
                        index = (index + 1) % arr.Length;
                        Console.SetCursorPosition(0, index);

                        // selected item wrtie to title
                        try
                        {
                            Console.Title = arr[index].FullName.ToString() + " -- this attributes [ " + arr[index].Attributes + " ]";
                        }
                        catch (System.IndexOutOfRangeException e)
                        {
                            Console.Title = "?" + " -- this attributes [ " + arr[index].Attributes + " ]";
                        }
                        break;

                    case ConsoleKey.LeftArrow: // go to back
                        Console.Clear();
                        // selected item is a directory type
                        arr = Program.PreviusArr;
                        index = 0;
                        int maxlen = detectMaxLength(arr);
                        ViewItems(index, arr, maxlen);
                        break;
                    case ConsoleKey.RightWindows: // goto previus
                        break;
                    case ConsoleKey.Enter:
                        if (arr[index].GetType() == typeof(DirectoryInfo))
                        {
                            Console.Clear();
                            // selected item is a directory type

                            d = arr[index] as DirectoryInfo;
                            index = 0;
                            try
                            {
                                arr = d.GetFileSystemInfos();
                            }
                            catch (UnauthorizedAccessException uae)
                            {
                                // pass
                                // maybe used as a competent user or administration privilegies
                            }

                            maxlen = detectMaxLength(arr); // pereravnili evo na columns
                            Console.WriteLine("count" + arr.Count());
                            try
                            {
                                if (arr.Length > Console.BufferHeight)
                                    Console.BufferHeight = arr.Length;
                            }
                            catch (System.ArgumentOutOfRangeException ore)
                            {
                                Console.BufferHeight = 1000;
                            }

                            ViewItems(index, arr, maxlen);
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