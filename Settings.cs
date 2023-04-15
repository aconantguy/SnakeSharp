using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    // The Directions are used to translate key presses into in-game commands
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    };

    // Declares settings, then initializes them to default values
    internal class Settings
    {
        public static int width { get; set; }
        public static int height { get; set; }
        public static int speed { get; set; }
        public static int score { get; set; }
        public static int points { get; set; }
        public static bool gameOver { get; set; }
        public static int level { get; set; }
        public static int next { get; set; }
        public static int lFlash { get; set; }



        public static Directions direction { get; set; }

        public Settings()
        {
            width = 16;
            height = 16;
            speed = 10;
            score = 0;
            points = 100;
            gameOver = false;
            direction = Directions.Down;
        }

    }
}
