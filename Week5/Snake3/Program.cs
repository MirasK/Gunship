using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake3
{
    

    class Program
    {
        static void Menu()
        {
            string[] items = { "New game", "Load game", "Save game", "Copyrights", "Exit" };
            int lineid = 15;
            int index = 1;
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



                for (int i = 0; i < items.Length; i++)
                {
                    if (index == i)
                    {
                        lineid++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(42, lineid);
                        Console.WriteLine(items[i]);

                    }
                    else
                    {
                        lineid++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(42, lineid);
                        Console.WriteLine(items[i]);
                    }
                }

            }
        }

        static void Welcome()
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Title = @"Snake game";

            string[] logolines = new string[85];
            logolines[0] = "@@@@@@@@@@@@@   @@@           @@             @@@             @@      @@ @@@@@@@@@@@@@";
            logolines[1] = "@@@@@     @@@@  @@ @          @@            @@ @@            @@     @@  @@@@@@@@@@@@@";
            logolines[2] = "   @@@@         @@  @         @@           @@   @@           @@    @@   @@           ";
            logolines[3] = "    @@@@        @@   @        @@          @@     @@          @@   @@    @@           ";
            logolines[4] = "     @@@@       @@    @       @@         @@       @@         @@  @@     @@           ";
            logolines[5] = "      @@@@      @@     @      @@        @@         @@        @@ @@      @@@@@@@@@@@@@";
            logolines[6] = "       @@@@     @@      @     @@       @@           @@       @@@@       @@@@@@@@@@@@@";
            logolines[7] = "        @@@     @@       @    @@      @@             @@      @@@@       @@           ";
            logolines[8] = "      @@@@      @@        @   @@     @@@@@@@@@@@@@@@@@@@     @@ @@      @@           ";
            logolines[9] = "    @@@         @@         @  @@    @@                 @@    @@  @@     @@           ";
            logolines[10] = "  @@@           @@          @ @@   @@                   @@   @@   @@    @@           ";
            logolines[11] = "@@@     @@@@@@  @@           @@@  @@                     @@  @@    @@   @@@@@@@@@@@@@";
            logolines[12] = "@@@@@@@@@@@@@   @@            @@ @@                       @@ @@     @@  @@@@@@@@@@@@@";

            int logoindex = 10;
            foreach (string logo in logolines)
            {
                logoindex++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(10, logoindex);
                Console.WriteLine(logo);
            }

            string[] imagelines = new string[35];
            imagelines[0] = "\\$$$$$$\\            __________   ";
            imagelines[1] = " \\$$$$$$\\__________/          \\  ";
            imagelines[2] = "  \\$$$$$$$$$$$$$$$/   @@   @@  \\   ";
            imagelines[3] = "   \\$$$$$$$$$$$$$$\\             \\    ";
            imagelines[4] = "    \\$$$$$$$$$$$$$$\\  _ _ _ _        ";
            imagelines[5] = "                     \\_!_!_!_!_        ";

            int imindex = 0;
            foreach (string im in imagelines)
            {
                imindex++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, imindex);
                Console.WriteLine(im);
            }

            string[] imagelines2 = new string[16];
            imagelines2[0] = "           ++++";
            imagelines2[1] = "         +++ ++ ";
            imagelines2[2] = "       +++    +";
            imagelines2[3] = "   ++++++++++  ";
            imagelines2[4] = "  ++++++++++++";
            imagelines2[5] = " ++++++++++++++ ";
            imagelines2[6] = "++++++++++++++++";
            imagelines2[7] = " ++++++++++++++ ";
            imagelines2[8] = "  ++++++++++++  ";
            imagelines2[9] = "    ++++++++    ";

            int im2index = 0;
            foreach (string im2 in imagelines2)
            {
                im2index++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(50, im2index);
                Console.WriteLine(im2);
            }

            string[] imagelines3 = new string[25];
            imagelines3[0] = "           ##     ##  ";
            imagelines3[1] = "#########################";
            imagelines3[2] = "#########################";
            imagelines3[3] = "          ##     ##     ";
            imagelines3[4] = "         ##     ##    ";
            imagelines3[5] = "#########################";
            imagelines3[6] = "#########################";
            imagelines3[7] = "        ##     ##       ";
            imagelines3[8] = "       ##     ##         ";

            int im3index = 25;
            foreach (string im3 in imagelines3)
            {
                im3index++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(30, im3index);
                Console.WriteLine(im3);
            }

            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
            Console.Clear();

        }

        static void Main(string[] args)
        {

        }
    }
}

