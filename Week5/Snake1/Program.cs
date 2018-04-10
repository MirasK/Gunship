using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake1
{
    enum GameLevel
    {
        First,
        Second,
        Bonus
    }

    class Game
    {
        public static int boardW = 35;
        public static int boardH = 35;

        bool[,] field = new bool[10, 10];

        Worm worm;
        Food food;
        Wall wall;
        public bool isAlive;

        GameLevel gameLevel;

        List<GameObject> g_objects = new List<GameObject>();

        public void SetupBoard()
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;
        }

        public Game()
        {
            isAlive = true;
            gameLevel = GameLevel.First;

            worm = new Worm(new Point { X = 10, Y = 10 },
                            ConsoleColor.Green, '*');
            food = new Food(new Point { X = 20, Y = 10 },
                           ConsoleColor.Red, '+');
            wall = new Wall(null, ConsoleColor.Yellow, '#');

            wall.LoadLevel(GameLevel.First);

            g_objects.Add(worm);
            g_objects.Add(food);
            g_objects.Add(wall);
        }

        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
            {
                g.Draw();
            }
        }

        public void Exit()
        {

        }

        public void Start()
        {

        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    worm.Move(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    worm.Move(1, 0);
                    break;
                case ConsoleKey.Escape:
                    break;
            }

            if (worm.body[0].Equals(food.body[0]))
            {
                worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
            }
            else
            {
                foreach (Point p in wall.body)
                {
                    if (p.Equals(worm.body[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("GAME OVER!!!");
                        isAlive = false;
                        break;
                    }
                }
            }
        }
    }

    public abstract class GameObject
    {
        public List<Point> body { get; }
        public char sign { get; }
        public ConsoleColor color { get; }

        public GameObject(Point firstPoint, ConsoleColor color, char sign)
        {
            this.body = new List<Point>();
            if (firstPoint != null)
            {
                this.body.Add(firstPoint);
            }
            this.color = color;
            this.sign = sign;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            Point b = obj as Point;
            if (b.X == this.X && b.Y == this.Y) return true;
            return false;
        }
    }

    class Wall : GameObject
    {
        public Wall(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }

        public void LoadLevel(GameLevel level)
        {
            string fname = "";

            switch (level)
            {
                case GameLevel.First:
                    fname = @"Levels\Level1.txt";
                    break;
                case GameLevel.Second:
                    break;
                case GameLevel.Bonus:
                    break;
                default:
                    break;
            }

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int y = 0;

            while ((line = sr.ReadLine()) != null)
            {
                for (int x = 0; x < line.Length; ++x)
                {
                    if (line[x] == '#')
                    {
                        this.body.Add(new Point { X = x, Y = y });
                    }
                }
                y++;
            }

            sr.Close();
            fs.Close();
        }
    }

    public class Worm : GameObject
    {
        public Worm(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }
        public void Move(int dx, int dy)
        {
            Point newHeadPos = new Point { X = body[0].X + dx, Y = body[0].Y + dy };

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0] = newHeadPos;
        }
    }

    public class Food : GameObject
    {
        public Food(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }
    }

    class Program
    {

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
            Welcome();
            Game game = new Game();
            game.SetupBoard();

            while (game.isAlive)
            {
                game.Draw();
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);
            }
        }
    }
}


