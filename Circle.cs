using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {

    internal class Circle
    {
        public int x { get; set; }
        public int y { get; set; }

        public Circle()
        {
            x = 0;
            y = 0;

        }
    }
    internal class SpeedUp : Circle
    {
        public bool spawned { get; set; }
        public bool flash { get; set; }

        public SpeedUp()
        {
            x = -1;
            y = -1;
            spawned = false;
            flash = false;
        }
    }

    internal class SpeedDown : Circle
    {
        public bool spawned { get; set; }
        public bool flash { get; set; }

        public SpeedDown()
        {
            x = -1;
            y = -1;
            spawned = false;
            flash = false;
        }
    }
    internal class Enemy : Circle
    {
        public int speed { get; set; }
        public int range { get; set; }

        public int rcounter { get; set; }
        public int scounter { get; set; }
        public Directions Direction { get; set; }

        public Enemy()
        {
            x = 0;
            y = 0;
            rcounter = 0;
            scounter = 0;
            Random random = new Random();
            switch (random.Next(1, 4))
            {
                case 1:
                    Direction = Directions.Left;
                    break;
                case 2:
                    Direction = Directions.Right;
                    break;
                case 3:
                    Direction = Directions.Up;
                    break;
                case 4:
                    Direction = Directions.Down;
                    break;
            }
        }
    }
}
