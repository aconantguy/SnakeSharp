using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.ServiceProcess;

namespace SnakeGame
{
    public partial class Form1 : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        private Enemy enemy = new Enemy();

        public Form1()
        {
            InitializeComponent();

            new Settings();

            gameTimer.Interval = 1000 / Settings.speed;
            gameTimer.Enabled = true;
            gameTimer.Start();

            startGame();
        }

        private void updateScreen(object sender, EventArgs e)
        {
            if (Settings.gameOver == true)
            {
                if (Input.KeyPress(Keys.Enter))
                {
                    startGame();
                }
            }
            else
            {
                if (Input.KeyPress(Keys.Right) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }
                move();
            }

            moveEnemy();

            Canvas.Invalidate();

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true);
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false);
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            Graphics screen = e.Graphics;
            if (Settings.gameOver == false)
            {
                Brush color;

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0) color = Brushes.Green;
                    else color = Brushes.DarkGreen;

                    screen.FillRectangle(color, new Rectangle(
                        Snake[i].x * Settings.width,
                        Snake[i].y * Settings.height,
                        Settings.width, Settings.height));
                }

                screen.FillEllipse(Brushes.White, new Rectangle(
                    food.x * Settings.width,
                    food.y * Settings.height,
                    Settings.width, Settings.height));

                screen.FillRectangle(Brushes.Red, new Rectangle(
                    enemy.x * Settings.width,
                    enemy.y * Settings.height,
                    Settings.width, Settings.height));
            }
            else
            {
                EndLbl.Text = "Game Over\nFinal Score: " + Settings.score + "\nPress Enter to Restart\n";
                EndLbl.Visible = true;
            }
        }

        private void startGame()
        {
            EndLbl.Visible = false;
            new Settings();
            Snake.Clear();
            Circle head = new Circle { x = 10, y = 5 };
            Snake.Add(head);
            createEnemy();

            ScoreNLbl.Text = Settings.score.ToString();

            generate();
        }

        private void move()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].x++;
                            break;
                        case Directions.Left:
                            Snake[i].x--;
                            break;
                        case Directions.Up:
                            Snake[i].y--;
                            break;
                        case Directions.Down:
                            Snake[i].y++;
                            break;
                    }

                    int maxX = Canvas.Size.Width / Settings.width;
                    int maxY = Canvas.Size.Height / Settings.height;

                    if (Snake[i].x < 0) Snake[i].x = maxX;
                    else if (Snake[i].y < 0) Snake[i].y = maxY;
                    else if (Snake[i].x > maxX) Snake[i].x = 0;
                    else if (Snake[i].y > maxY) Snake[i].y = 0;

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].x == Snake[j].x && Snake[i].y == Snake[j].y)
                        {
                            die();
                        }
                    }

                    if (Snake[0].x == food.x && Snake[0].y == food.y)
                    {
                        eat();
                    }
                }

                else
                {
                    Snake[i].x = Snake[i - 1].x;
                    Snake[i].y = Snake[i - 1].y;
                }

                if (Snake[i].x == enemy.x && Snake[i].y == enemy.y)
                {
                    die();
                }
            }
        }

        private void generate()
        {
            int maxX = Canvas.Size.Width / Settings.width;
            int maxY = Canvas.Size.Height / Settings.height;
            Random random = new Random();
            food = new Circle { x = random.Next(0, maxX), y = random.Next(0, maxY) };
        }

        private void eat()
        {
            Circle body = new Circle() { x = Snake[Snake.Count - 1].x, y = Snake[Snake.Count - 1].y };

            Snake.Add(body);
            Settings.score += Settings.points;
            ScoreNLbl.Text = Settings.score.ToString();
            generate();
        }

        private void die()
        {
            Settings.gameOver = true;
        }

        private void createEnemy()
        {
            int maxX = Canvas.Size.Width / Settings.width;
            int maxY = Canvas.Size.Height / Settings.height;
            Random random = new Random();
            enemy = new Enemy { x = random.Next(0, maxX), y = random.Next(0, maxY), speed = random.Next(0, 5), range = random.Next(0, 10) };
        }

        private void moveEnemy()
        {
            if (enemy.scounter == enemy.speed)
            {
                enemy.scounter = 0;
                if (enemy.rcounter == enemy.range)
                {
                    enemy.rcounter = 0;
                    switch (enemy.Direction)
                    {
                        case (Directions.Left):
                            enemy.Direction = Directions.Right;
                            break;
                        case (Directions.Right):
                            enemy.Direction = Directions.Left;
                            break;
                        case (Directions.Down):
                            enemy.Direction = Directions.Up;
                            break;
                        case (Directions.Up):
                            enemy.Direction = Directions.Down;
                            break;
                    }
                }
                enemy.rcounter++;
                switch (enemy.Direction)
                {
                    case Directions.Right:
                        enemy.x++;
                        break;
                    case Directions.Left:
                        enemy.x--;
                        break;
                    case Directions.Up:
                        enemy.y--;
                        break;
                    case Directions.Down:
                        enemy.y++;
                        break;
                }

                int maxX = Canvas.Size.Width / Settings.width;
                int maxY = Canvas.Size.Height / Settings.height;

                if (enemy.x < 0) enemy.x = maxX;
                else if (enemy.y < 0) enemy.y = maxY;
                else if (enemy.x > maxX) enemy.x = 0;
                else if (enemy.y > maxY) enemy.y = 0;
            }
            else enemy.scounter++;
        }
    }
}