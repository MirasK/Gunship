using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SnakeB
{
    
    class Program
    {
        static void Main(string[] args)
        {

            Console.WindowHeight = 39;
            Console.WindowWidth = 100;
            int screenw = Console.WindowWidth;
            int screenh = Console.WindowHeight;
            Random random = new Random();
            int score = 0;
            int gameover = 0;
            pixel body = new pixel();
            body.xpos = screenw / 2;
            body.ypos = screenh / 2;
            body.bcolor = ConsoleColor.Red;
            string movement = "RIGHT";
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = random.Next(0, screenw);
            int berryy = random.Next(0, screenh);
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            string buttonpressed = "no";
            while (true)
            {
                Console.Clear();
                if (body.xpos == screenw - 1 || body.xpos == 0 || body.ypos == screenh - 1 || body.ypos == 0)
                {
                    gameover = 1;
                }
                for (int i = 0; i < screenw; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < screenw; i++)
                {
                    Console.SetCursorPosition(i, screenh - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenh; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }
                for (int i = 0; i < screenh; i++)
                {
                    Console.SetCursorPosition(screenw - 1, i);
                    Console.Write("■");
                }
                //for (int i = 0; i < screenheight/2; i++)
                //{
                //    Console.SetCursorPosition(screenwidth - screenwidth / 2, i);
                //    Console.Write("■");
                //}
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == body.xpos && berryy == body.ypos)
                {
                    score++;
                    berryx = random.Next(1, screenw);
                    berryy = random.Next(1, screenh);
                }
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.Write("■");
                    if (xposlijf[i] == body.xpos && yposlijf[i] == body.ypos)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }   
                Console.SetCursorPosition(body.xpos, body.ypos);
                Console.ForegroundColor = body.bcolor;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                tijd = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 100) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        //Console.WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                        {
                            movement = "UP";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                        {
                            movement = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                        {
                            movement = "LEFT";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                        {
                            movement = "RIGHT";
                            buttonpressed = "yes";
                        }
                    }
                }
                xposlijf.Add(body.xpos);
                yposlijf.Add(body.ypos);
                switch (movement)
                {
                    case "UP":
                        body.ypos--;
                        break;
                    case "DOWN":
                        body.ypos++;
                        break;
                    case "LEFT":
                        body.xpos--;
                        break;
                    case "RIGHT":
                        body.xpos++;
                        break;
                }
                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            Console.Clear();
            Console.SetCursorPosition(screenw / 5, screenh / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenw / 5, screenh / 2 + 1);
        }
        class pixel
        {
            public int xpos { get; set; }
            public int ypos { get; set; }
            public ConsoleColor bcolor { get; set; }
        }
    }
}
