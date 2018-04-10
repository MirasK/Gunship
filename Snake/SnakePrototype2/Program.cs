using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Media;

namespace SnakePrototype2
{
    class StatusBar
    {
        public static void ShowInfo(string info)
        {
            Console.SetCursorPosition(0, 46);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < 52; ++i)
            {
                for (int j = 49; j <= 51; ++j)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, 50);
            Console.Write(info);
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

            for (int i = 0; i < 46; ++i)
            {
                for (int j = 0; j < 52; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 11);

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
    /// <summary>
    /// в классе Drawer создаем методы постановки объектов по координатам
    /// реализация сериализации и десериализации с помощью BinaryFormatter
    /// </summary>
    [Serializable]
    public class Drawer
    {
        public List<Point> body = new List<Point>();

        public ConsoleColor color;
        public char sign;

        public void Draw()
        {

            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);

                Console.Write(sign);
            }
        }

        public void Save()
        {
            Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Create, FileAccess.Write);
            //XmlSerializer xs = new XmlSerializer(t);
            //xs.Serialize(fs, this);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()
        {
            Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Open, FileAccess.Read);
            //XmlSerializer xs = new XmlSerializer(t);
            BinaryFormatter bf = new BinaryFormatter();
            if (t == typeof(Wall)) Game.wall = bf.Deserialize(fs) as Wall;
            if (t == typeof(Snake)) Game.snake = bf.Deserialize(fs) as Snake;
            if (t == typeof(Food)) Game.food = bf.Deserialize(fs) as Food;
            fs.Close();
        }

    }

    [Serializable]
    public class Food : Drawer
    {

        public Food()
        {
            sign = '■';
        }

    }

    /// <summary>
    ///класс Game отвечает за состояние игры в текущий момент
    ///метод Init  вызывается при прогрузке игры, отвечая за начально положение всех объектов
    ///используя Filestream и Streamreader считываем файл с уровнем в методе Loadlevel
    ///рандомно генерируем положение змейки, учитывая координаты еды и стен. Данный метод в последствиии вызывается в классе Program как только прогрузится новый уровень
    ///метод Save сохраняет текущее состояние игры
    ///метод Resume позволяет продолжить состояние сохраненной игры
    ///в методе Draw прописываем каждый объект и счетчик баллов
    /// </summary>
    [Serializable]
    public class Game
    {
        public static bool isActive;
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static void Init()
        {
            isActive = true;
            snake = new Snake();
            food = new Food();
            wall = new Wall();

            snake.body.Add(new Point { x = 20, y = 20 });
            food.body.Add(new Point { x = 30, y = 20 });

            food.color = ConsoleColor.Red;
            wall.color = ConsoleColor.Yellow;
            snake.color = ConsoleColor.Green;

            Console.SetWindowSize(48, 52);


        }

        public static void LoadlLevel(int level)
        {

            FileStream fs = new FileStream(string.Format(@"Levels\Level{0}.txt", level), FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int row = -1;
            int col = -1;

            while ((line = sr.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == 'I')
                    {
                        wall.body.Add(new Point { x = col, y = row });
                    }
                }
           }

            sr.Close();
            fs.Close();
            wall.Draw();
        }

        public static void RandomSnakeMaker()
        {
            Game.snake.body[0].x = new Random().Next(0, 47);
            Game.snake.body[0].y = new Random().Next(0, 47);
            for (int i = 0; i < Game.wall.body.Count; i++)
            {
                if (Game.snake.body[0].x == Game.wall.body[0].x || Game.snake.body[0].y == Game.wall.body[0].y)
                {
                    RandomSnakeMaker();

                }
                else
                {
                    continue;
                }
                if (Game.food.body[0].x == Game.snake.body[0].x || Game.food.body[0].y == Game.snake.body[0].y)
                {
                    RandomSnakeMaker();

                }
                else
                {
                    continue;
                }

            }
        }

        public static void Save()
        {
            wall.Save();
            snake.Save();
            food.Save();
        }

        public static void Resume()
        {
            wall.Resume();
            snake.Resume();
            food.Resume();
        }

        public static void Draw()
        {
            //Console.Clear();
            snake.Draw();
            food.Draw();
            Console.SetCursorPosition(3, 48);
            //Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Level: " + Program.level);
            Console.SetCursorPosition(3, 49);
            Console.WriteLine("Points: " + Game.snake.body.Count);
            Console.SetCursorPosition(3, 50);
            Console.WriteLine("Time: " + Program.minuts + " : " + Program.seconds);
        }
    }

    [Serializable]
    public class Point
    {
        public int x;
        public int y;
        public Point()
        {

        }
    }

    /// <summary>
    /// генерируем положение змейки, учитывая остальные объекты
    /// прописываем условие столкновения змейки со стеной
    /// </summary>
    [Serializable]
    public class Snake : Drawer
    {
        public int MyProperty { get; set; }

        public Snake()
        {
            sign = '■';
        }

        public void Move(int dx, int dy)
        {
            Point last = body[body.Count - 1];
            Console.SetCursorPosition(last.x, last.y);
            Console.Write(' ');

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
                
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            if (Game.snake.body[0].x == Game.food.body[0].x &&
               Game.snake.body[0].y == Game.food.body[0].y)
            {
                Game.snake.body.Add(new Point
                {
                    x = Game.food.body[0].x,
                    y = Game.food.body[0].y
                });

                Game.food.body[0].x = new Random().Next(0, 47);
                Game.food.body[0].y = new Random().Next(0, 47);

            }
            //if (Game.snake.body[0].x == 47 || Game.snake.body[0].x == 0 ||
            //   Game.snake.body[0].y == 47 || Game.snake.body[0].y == 0)
            //{
            //    Console.Clear();
            //    Console.SetCursorPosition(15, 10);
            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //    Console.WriteLine("Your snake went away, haha!");
            //    Game.isActive = false;
            //    Program.level = 1;
            //}



            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.food.body[0].x == Game.snake.body[0].x && Game.food.body[0].y == Game.snake.body[0].y)
                {
                    Console.Clear();
                    RandomMaker();
                }

            }


            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("Game over,lalka!");
                    Game.isActive = false;
                }

            }
            if (Game.snake.body.Count > 4)
            {
                //SoundPlayer sound = new SoundPlayer(@"Sound_06695.mp3");
                Program.level++;
                Console.Clear();
                Game.isActive = false;
                Console.SetCursorPosition(15, 10);
                Console.ForegroundColor = ConsoleColor.Green;
               // Console.WriteLine("Ololo!New level is waiting!");


            }

        }
        public static void RandomMaker()
        {
            Game.food.body[0].x = new Random().Next(0, 47);
            Game.food.body[0].y = new Random().Next(0, 47);

            for (int i = 0; i < Game.wall.body.Count; i++)
            {
                if (Game.food.body[0].x == Game.wall.body[0].x || Game.food.body[0].y == Game.wall.body[0].y)
                {
                    RandomMaker();

                }
                else
                {
                    continue;
                }
                if (Game.food.body[0].x == Game.snake.body[0].x || Game.food.body[0].y == Game.snake.body[0].y)
                {
                    RandomMaker();

                }
                else
                {
                    continue;
                }


            }

        }

    }

    [Serializable]
    public class Wall : Drawer
    {
        public Wall()
        {
            sign = 'I';
        }
    }

    /// <summary>
    /// в классе Program вызываем ранее описаные в Game методы Init, LoadLevel и RandomSnakeMaker
    /// первый цикл задает условие играть пока не закончатся уровни в папке с указанным путем
    /// используя цикл задаем условие активности игры, где прописываем действия при нажатии клавиш, используя ConsoleKeyInfo
    /// </summary>
    class Program
    {
        

        public static int level = 1;
        public static string dir = "Right";
        public static Thread forTimer;
        public static Thread Direction = new Thread(new ParameterizedThreadStart(move));
        //public static Timer time = new Timer(new TimerCallback(seconding), st, 0, 1000);


        public static int seconds = 0;
        public static int minuts = 0;
        /*private static int st;
        
        public static void seconding(object st)
        {
            
                seconds++;
                minuts++;
                if (seconds == 60)
                {
                    seconds = 0;
                }
                
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(3, 47);
            Console.WriteLine("Time " + minuts + " : " + seconds);
            
        }*/
        public static void timer(object obj)
        {
            while (Game.isActive)
            {
                seconds++;
                if (seconds == 60)
                {
                    minuts++;
                    seconds = 0;
                }
                Thread.Sleep(1000);
            }

        }




        static void Main(string[] args)
        {

            MainFunction();
        }




        public static void MainFunction()
        {
            //Menu menu = new Menu();
            //menu.Draw();
            Game.Init();
            Game.LoadlLevel(level);
            Game.snake.Draw();
            Direction = new Thread(new ParameterizedThreadStart(move));
            forTimer = new Thread(new ParameterizedThreadStart(timer));
            Direction.Start();
            forTimer.Start();
            while (Game.isActive)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        dir = "Up";
                        break;
                    case ConsoleKey.DownArrow:
                        dir = "Down";
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = "Left";
                        break;
                    case ConsoleKey.RightArrow:
                        dir = "Right";
                        break;
                    case ConsoleKey.Escape:
                        Game.isActive = false;
                        break;
                    case ConsoleKey.F2:
                        Game.Save();
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
            }
            Direction.Abort();
            forTimer.Abort();
            MainFunction();
        }
        public static void move(object obj) // основы движения змейки
        {
            while (Game.isActive)
            {

                switch (dir)// меняем положение 
                {
                    case "Up":
                        Game.snake.Move(0, -1);
                        break;
                    case "Down":
                        Game.snake.Move(0, 1);
                        break;
                    case "Left":
                        Game.snake.Move(-1, 0);
                        break;
                    case "Right":
                        Game.snake.Move(1, 0);
                        break;

                }

            Game.Draw();
                Thread.Sleep(100);

            }
        }

    }
}
