using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    enum CellState
    {
        empty,
        busy,
        adjacent,
        striked,
        destroyed,
        missed
    }

    enum State
    {
        construction,
        ready,
        game
    }

    delegate void DrawCells(CellState[,] map);

    delegate void Btns(List<Point> P, bool isGood, bool isBack);

    class Brain
    {
        public CellState[,] map = new CellState[10, 10];
        PlayerType playerType;
        public State state;

        public List<int> notShooted = new List<int>();

        public ShipType[] st = { ShipType.d4,
                                 ShipType.d3, ShipType.d3,
                                 ShipType.d2, ShipType.d2, ShipType.d2,
                                 ShipType.d1, ShipType.d1, ShipType.d1, ShipType.d1 };

        List<Ship> ships;
        public int alives;
        DrawCells draw;
        GameDelegate over;
        GameDelegate check;
        Btns ReDraw;
        Point direction;

        public bool isWinner;

        public int index = -1;

        public Brain(DrawCells draw, GameDelegate over, GameDelegate check, Btns Redraw, PlayerType playerType)
        {
            this.draw = draw;
            this.playerType = playerType;
            this.over = over;
            this.check = check;
            this.ReDraw = Redraw;

            state = State.construction;

            ships = new List<Ship>();
            alives = 0;
            direction = new Point(1, 0);
            isWinner = false;

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    map[i, j] = CellState.empty;
                    notShooted.Add(10 * i + j);
                }
            }

            draw.Invoke(map);
        }

        public void Enter(string msg)
        {
            string[] values = msg.Split('_');

            int i = int.Parse(values[0]);
            int j = int.Parse(values[1]);

            Point p = new Point(i, j);

            CheckShipLocation(p);
        }

        public void Leave(string msg)
        {
            string[] values = msg.Split('_');

            int i = int.Parse(values[0]);
            int j = int.Parse(values[1]);

            Point p = new Point(i, j);

            ColorBack(p);
        }

        private void CheckShipLocation(Point p)
        {
            if (index + 1 < st.Length)
            {
                Ship ship = new Ship(st[index + 1], p, direction);

                List<Point> newbody = new List<Point>();

                foreach (Point point in ship.body)
                {
                    if (point.X > -1 && point.X < 10 && point.Y > -1 && point.Y < 10)
                    {
                        newbody.Add(point);
                    }
                }

                ReDraw.Invoke(newbody, IsValidLocation(ship), false);
            }
        }

        private void ColorBack(Point p)
        {
            if (index + 1 < st.Length)
            {
                Ship ship = new Ship(st[index + 1], p, direction);

                List<Point> newbody = new List<Point>();

                foreach (Point point in ship.body)
                {
                    if (point.X > -1 && point.X < 10 && point.Y > -1 && point.Y < 10)
                    {
                        newbody.Add(point);
                    }
                }

                ReDraw.Invoke(newbody, IsValidLocation(ship), true);
            }
        }

        public void Switch(string msg)
        {
            if (direction.X == 1)
                direction = new Point(0, 1);

            else
                direction = new Point(1, 0);
        }

        public bool Play(string msg)
        {
            string[] values = msg.Split('_');

            int i = int.Parse(values[0]);
            int j = int.Parse(values[1]);

            Point p = new Point(i, j);

            bool isShooted = false;

            if (IsStriked(p))
            {
                MarkCell(p, CellState.striked);
                isShooted = true;
                CheckDestroyedShip(p);
            }
            else
            {
                MarkCell(p, CellState.missed);
            }

            draw.Invoke(map);

            if (alives == 0)
            {
                over.Invoke();
                isWinner = true;
            }

            return isShooted;
        }

        public void Process(string msg)
        {
            string[] values = msg.Split('_');

            int i = int.Parse(values[0]);
            int j = int.Parse(values[1]);

            Point p = new Point(i, j);

            PlaceShip(p);
        }

        private bool IsStriked(Point p)
        {
            bool isStriked = false;

            for (int i = 0; i < ships.Count; ++i)
            {
                if (ships[i].body.Contains(p))
                {
                    isStriked = true;
                    break;
                }
            }

            return isStriked;
        }

        private void CheckDestroyedShip(Point p)
        {
            int ind = -1;

            for (int i = 0; i < ships.Count; ++i)
            {
                if (ships[i].body.Contains(p))
                {
                    ind = i;
                    break;
                }
            }

            if (ind != -1)
            {
                bool isKilled = true;

                foreach (Point f in ships[ind].body)
                {
                    if (map[f.X, f.Y] != CellState.striked)
                    {
                        isKilled = false;
                        break;
                    }
                }

                if (isKilled)
                {
                    alives--;

                    foreach (Point f in ships[ind].body)
                    {
                        MarkCell(f, CellState.destroyed);
                    }
                    foreach (Point f in ships[ind].body)
                    {
                        CheckAdjLocation(f, CellState.destroyed, CellState.missed);
                    }
                }
            }
        }

        private void PlaceShip(Point p)
        {
            if (index + 1 < st.Length)
            {
                index++;
                alives++;

                Ship ship = new Ship(st[index], p, direction);

                if (IsValidLocation(ship))
                {
                    ships.Add(ship);
                    MarkLocation(ship, CellState.busy);
                    draw.Invoke(map);
                }

                else
                {
                    index--;
                    alives--;
                }

                if (index + 1 == st.Length)
                {
                    state = State.ready;
                    check.Invoke();

                    if (playerType == PlayerType.bot)
                        MaskCells();
                }
            }
        }

        private void CheckAdjCell(int i, int j, CellState exception, CellState cellState)
        {
            if (i < 0 || i > 9) return;
            if (j < 0 || j > 9) return;
            if (map[i, j] == exception) return;

            MarkCell(new Point(i, j), cellState);

            if (cellState == CellState.missed)
                notShooted.Remove(10 * i + j);
        }

        private void CheckAdjLocation(Point p, CellState exception, CellState cellState)
        {
            CheckAdjCell(p.X - 1, p.Y - 1, exception, cellState);
            CheckAdjCell(p.X - 1, p.Y, exception, cellState);
            CheckAdjCell(p.X - 1, p.Y + 1, exception, cellState);
            CheckAdjCell(p.X, p.Y + 1, exception, cellState);
            CheckAdjCell(p.X + 1, p.Y + 1, exception, cellState);
            CheckAdjCell(p.X + 1, p.Y, exception, cellState);
            CheckAdjCell(p.X + 1, p.Y - 1, exception, cellState);
            CheckAdjCell(p.X, p.Y - 1, exception, cellState);
        }

        private void MarkCell(Point p, CellState state) => map[p.X, p.Y] = state;

        private void MarkLocation(Ship ship, CellState state)
        {
            for (int i = 0; i < ship.body.Count; ++i)
            {
                MarkCell(ship.body[i], state);
            }

            if (state == CellState.busy)
            {
                for (int i = 0; i < ship.body.Count; ++i)
                {
                    CheckAdjLocation(ship.body[i], CellState.busy, CellState.adjacent);
                }
            }
        }

        private bool IsValidCell(Point p)
        {
            if (p.X < 0 || p.X > 9) return false;
            if (p.Y < 0 || p.Y > 9) return false;

            return map[p.X, p.Y] == CellState.empty;
        }

        private bool IsValidLocation(Ship ship)
        {
            for (int i = 0; i < ship.body.Count; ++i)
            {
                if (!IsValidCell(ship.body[i]))
                    return false;
            }

            return true;
        }

        private void MaskCells()
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    MarkCell(new Point(i, j), CellState.empty);
                }
            }

            draw.Invoke(map);
        }
    }
}