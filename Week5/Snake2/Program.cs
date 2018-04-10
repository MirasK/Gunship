using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Snake2
{
    enum GameLevel
    {
        First,
        Second,
        Bonus
    }

    class Game
    {
        public static int speed = 500;
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
                            ConsoleColor.White, '*');
            food = new Food(new Point { X = 20, Y = 10 },
                           ConsoleColor.White, '+');
            wall = new Wall(null, ConsoleColor.White, '#');

            wall.LoadLevel(GameLevel.First);

            g_objects.Add(worm);
            g_objects.Add(food);
            g_objects.Add(wall);
        }

        public void Start()
        {
            ThreadStart ts = new ThreadStart(Draw);
            Thread t = new Thread(ts);
            t.Start();
        }

        public void Draw()
        {
            while (true)
            {
                worm.Move();

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

                Console.Clear();
                foreach (GameObject g in g_objects)
                {
                    g.Draw();
                }
                Thread.Sleep(Game.speed);
            }
        }

        public void Exit()
        {

        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.DX = 0;
                    worm.DY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.DX = 0;
                    worm.DY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.DX = -1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    worm.DX = 1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.Escape:
                    break;
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
    public class Food : GameObject
    {
        public Food(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }
    }
    class Menu
    {
        string[] items = { "New Game", "Load Game", "Save Game", "Settings", "Exit" };
        int selectedItemIndex = 0;

        void NewGame()
        {

            StatusBar.ShowInfo("New Game!");
        }

        void LoadGame()
        {
            StatusBar.ShowInfo("LoadGame!");
        }

        void SaveGame()
        {
            StatusBar.ShowInfo("SaveGame!");
        }

        void Settings()
        {
            StatusBar.ShowInfo("Settings!");
        }

        void Exit()
        {
            StatusBar.ShowInfo("Exit!");
        }

        public void Draw()
        {

            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < Game.boardH - 2; ++i)
            {
                for (int j = 0; j < Game.boardW; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, (Game.boardH - 25) / 2);

            for (int i = 0; i < items.Length; ++i)
            {
                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(String.Format("          {0}. {1}", i, items[i]));
            }
        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedItemIndex--;
                    if (selectedItemIndex < 0)
                    {
                        selectedItemIndex = items.Length - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedItemIndex++;
                    if (selectedItemIndex >= items.Length)
                    {
                        selectedItemIndex = 0;
                    }
                    break;
                case ConsoleKey.Enter:

                    switch (selectedItemIndex)
                    {
                        case 0:
                            NewGame();
                            break;
                        case 1:
                            LoadGame();
                            break;
                        case 2:
                            SaveGame();
                            break;
                        case 3:
                            Settings();
                            break;
                        case 4:
                            Exit();
                            break;
                    }

                    break;
            }

            Draw();
        }
    }
    class StatusBar
    {
        public static void ShowInfo(string info)
        {
            Console.SetCursorPosition(0, Game.boardH - 2);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < Game.boardW; ++i)
            {
                for (int j = Game.boardW - 3; j <= Game.boardW - 1; ++j)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, Game.boardH - 2);
            Console.Write(info);
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
        public int DX { get; set; }
        public int DY { get; set; }

        public Worm(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {
            DX = 0;
            DY = 1;
        }
        public void Move()
        {
            Point newHeadPos = new Point { X = body[0].X + DX, Y = body[0].Y + DY };

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0] = newHeadPos;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;


            //StatusBar.ShowInfo("test!");


            //while (true) { }

            Menu menu = new Menu();
            menu.Draw();
            Game game = new Game();
            game.SetupBoard();
            game.Start();
            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                menu.Process(pressedButton);
                //game.Process(pressedButton);
            }
            
        }
    }
}
