using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FAR
{
    class Program
    {
        static void ViewFiles(int index, FileSystemInfo[] arr, int maxlen)
        {
            // dela s background-e
            // Console.BackgroundColor = ConsoleColor.DarkBlue;

            // mne drug tak skazal
            // int patth = index / 20;
            // patth = patth * 20;                
            // int maxlen = 0;

            for (int j = 0; j < arr.Length; ++j)
            {
                // Console.Write(' ');
                if (maxlen < arr[j].Name.Length) { maxlen = arr[j].Name.Length; }
                // Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            //for (int i = 0; i < arr.Length; ++i)
            //{
            //    if (i >= arr.Length){  break;}

            //    if (arr[i].GetType() == typeof(DirectoryInfo))
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;

            //    }
            //    else if (arr[i].GetType() == typeof(FileInfo))
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        // todo arr[i].
            //    }
            //    else {
            //        Console.ForegroundColor = ConsoleColor.Magenta;
            //    }

            //    if (index == i){
            //        Console.BackgroundColor = ConsoleColor.DarkYellow;

            //    } else {
            //        Console.BackgroundColor = ConsoleColor.DarkBlue;
            //    }
            //    int space_count = Math.Abs(maxlen - arr[i].Name.Length);
            //    char JokerChar = ' ';
            //    String tabs =new String(JokerChar, space_count);

            //    Console.Write(
            //        arr[i].CreationTimeUtc.ToString() + 
            //        " | " +
            //        // arr[i].Extension.ToString() + " | " +
            //        arr[i].Name.ToString() + tabs);
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.WriteLine('|');
            //}

            // dlya folders
            for (int i = 0; i < arr.Length; ++i)
            {
                if (i >= arr.Length) { break; }

                if (arr[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    if (index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    int space_count = Math.Abs(maxlen - arr[i].Name.Length);
                    char JokerChar = ' ';
                    String tabs = new String(JokerChar, space_count);

                    Console.Write(
                        arr[i].CreationTimeUtc.ToString() +
                        " | " +
                        // arr[i].Extension.ToString() + " | " +
                        arr[i].Name.ToString() + tabs);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine('|');
                }
            }
            // dlya files
            for (int i = 0; i < arr.Length; ++i)
            {
                if (i >= arr.Length) { break; }

                if (arr[i].GetType() != typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    int space_count = Math.Abs(maxlen - arr[i].Name.Length);
                    char JokerChar = ' ';
                    String tabs = new String(JokerChar, space_count);

                    Console.Write(
                        arr[i].CreationTimeUtc.ToString() +
                        " | " +
                        // arr[i].Extension.ToString() + " | " +
                        arr[i].Name.ToString() + tabs);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine('|');
                }
            }

            Console.SetCursorPosition(0, 0);

        }
        //static FileSystemInfo reSetItem() { }
        static void Main(string[] args)
        {
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;

            int Lines = 22;
            int Columns = 96;

            // Console.SetWindowSize(Columns, Lines);
            Console.WindowWidth = Columns;
            Console.WindowHeight = Lines;
            // Console.SetBufferSize(Columns, Lines);
            Console.BufferWidth = Columns;


            string Root = @"C:\";

            DirectoryInfo di = new DirectoryInfo(Root);
            FileSystemInfo[] arr = di.GetFileSystemInfos();
            Console.BufferHeight = Lines;
            int index = 0;
            bool quit = false;
            while (!quit)
            {

                int maxlen = 0;
                for (int j = 0; j < arr.Length; ++j)
                    if (maxlen < arr[j].Name.Length) { maxlen = arr[j].Name.Length; }

                ViewFiles(index, arr, maxlen);
                ConsoleKeyInfo pressedKey = Console.ReadKey();



                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0) index = arr.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % arr.Length;
                        Console.Title = arr[index].FullName.ToString();
                        break;
                    case ConsoleKey.Enter:
                        if (arr[index].GetType() == typeof(DirectoryInfo)) // eta tochna directory
                        {
                            Console.CursorVisible = false;
                            DirectoryInfo d = arr[index] as DirectoryInfo;
                            arr = d.GetFileSystemInfos();
                            Console.BufferHeight = arr.Length;
                            Console.BackgroundColor = ConsoleColor.Black;
                            index = 0;
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

