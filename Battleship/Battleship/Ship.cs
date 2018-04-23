using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    enum ShipType
    {
        d1,
        d2,
        d3,
        d4
    }

    class Ship
    {
        public List<Point> body;

        public Ship(ShipType shipType, Point p, Point dir)
        {
            body = new List<Point>();
            int a = 0;

            switch (shipType)
            {
                case ShipType.d1:
                    a = 1;
                    break;
                case ShipType.d2:
                    a = 2;
                    break;
                case ShipType.d3:
                    a = 3;
                    break;
                case ShipType.d4:
                    a = 4;
                    break;
            }

            for (int i = 0; i < a; ++i)
            {
                body.Add(new Point(p.X + i * dir.X, p.Y + i * dir.Y));
            }
        }
    }
}