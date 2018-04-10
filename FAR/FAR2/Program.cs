using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR2
{
    class Layer
    {
        public DirectoryInfo dirInfo;
        public string path;
        public int index;
        public List<FileSystemInfo> items;

        public Layer(string path, int index)
        {
            this.path = path;
            this.index = index;
            this.dirInfo = new DirectoryInfo(path);

            items = new List<FileSystemInfo>();
            items.AddRange(dirInfo.GetDirectories());
            items.AddRange(dirInfo.GetFiles());

        }

        public void Process(int v)
        {
            this.index += v;
            if (this.index < 0)
            {
                this.index = items.Count - 1;
            }
            if (this.index >= items.Count)
            {
                this.index = 0;
            }
        }

        public string GetSelectedItemInfo()
        {
            return this.items[index].FullName;
        }
    }
    enum FarMode
    {
        Explorer,
        FileReader
    }

    class FAR
    {
        Stack<Layer> layerHistory = new Stack<Layer>();
        Layer activeLayer;
        FarMode mode = FarMode.Explorer;

        public FAR(string path)
        {
            this.activeLayer = new Layer(path, 0);
        }

        public void Draw()
        {
            switch (mode)
            {
                case FarMode.Explorer:

                    DrawExplorer();

                    break;
                case FarMode.FileReader:

                    DrawFileReader();

                    break;
                default:
                    break;
            }

            DrawStatusBar();
        }

        private void DrawStatusBar()
        {
            Console.SetCursorPosition(4, 38);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(mode);
        }

        private void DrawFileReader()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(activeLayer.GetSelectedItemInfo(), FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                Console.WriteLine(sr.ReadToEnd());

            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open file!");

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void DrawExplorer()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            for (int i = 0; i < activeLayer.items.Count; ++i)
            {
                if (i == activeLayer.index)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (activeLayer.items[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(activeLayer.items[i].Name);
            }
        }

        public void Process(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    activeLayer.Process(-1);
                    break;
                case ConsoleKey.DownArrow:
                    activeLayer.Process(1);
                    break;
                case ConsoleKey.Enter:
                    try
                    {
                        if (activeLayer.items[activeLayer.index].GetType() == typeof(DirectoryInfo))
                        {
                            mode = FarMode.Explorer;
                            layerHistory.Push(activeLayer);
                            activeLayer = new Layer(activeLayer.GetSelectedItemInfo(), 0);
                        }
                        else if (activeLayer.items[activeLayer.index].GetType() == typeof(FileInfo))
                        {
                            mode = FarMode.FileReader;


                        }
                    }
                    catch (Exception e)
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (mode == FarMode.Explorer)
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    else if (mode == FarMode.FileReader)
                    {
                        mode = FarMode.Explorer;
                    }

                    break;
                default:
                    break;
            }

        }
    }
    class Program
    {
        static void Welcome()
        {
            Console.CursorVisible = false; 
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = @"FAR manager from MirCorps.";

            string[] logolines = new string[29];
            logolines[0] = "           00000000        ";
            logolines[1] = "        000        000     ";
            logolines[2] = "     00000000000000000000  ";
            logolines[3] = "    0                    0 ";
            logolines[4] = "   0   00000      00000   0";
            logolines[5] = "   0   000          000   0";
            logolines[6] = "   0         00000        0";
            logolines[7] = "   0    00000     00000   0";
            logolines[8] = "    0 00     000000   00 0 ";
            logolines[9] = "     0      0      0     0 ";
            logolines[10] = "    0     0        0    0 ";
            logolines[11] = "    000000          00000";

            int lineindex = 10;
            foreach (string line in logolines)
            {
                lineindex++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(5, lineindex);
                Console.WriteLine(line);
            }

            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Welcome();
            //Environment.GetLogicalDrives();
            Console.SetWindowSize(40, 40);
            FAR far = new FAR(@"C:\");

            bool quit = false;

            while (!quit)
            {
                far.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Enter:
                        far.Process(pressedKey);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
