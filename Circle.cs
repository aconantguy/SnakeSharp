using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {

    // The base circle class, used for the player character
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

    // Class for the SpeedUp powerup, adds spawned and flash bools
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

    // Class for the SpeedDown powerup, adds spawned and flash bools
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

    // Class for the KillEnemy powerup, adds spawned, flash and effect bools
    internal class KillEnemy : Circle
    {
        public bool spawned { get; set; }
        public bool flash { get; set; }
        public bool effect { get; set; }

        public KillEnemy()
        {
            x = -1;
            y = -1;
            spawned = false;
            flash = false;
            effect = false;
        }
    }

    // Class for the enemy, like a player character but with randomized speed, range and position.
    // It also has a spawn period where the player takes no damage if the enemy touches it.
    internal class Enemy : Circle
    {
        public int speed { get; set; }
        public int range { get; set; }

        public int rcounter { get; set; }
        public int scounter { get; set; }
        public Directions Direction { get; set; }
        public bool collision { get; set; }
        public System.Windows.Forms.Timer collisionTimer = new System.Windows.Forms.Timer();

        public Enemy()
        {
            x = 0;
            y = 0;
            rcounter = 0;
            scounter = 0;
            collision = false;
            collisionTimer.Dispose();
            collisionTimer = new System.Windows.Forms.Timer();
            collisionTimer.Interval = 5000;
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
