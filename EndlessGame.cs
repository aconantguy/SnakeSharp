using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.ServiceProcess;
using System.DirectoryServices;
using System.Drawing.Text;
using System.Resources;

namespace SnakeGame
{

    // See NormalGame for code breakdown
    // Endless mode removes the levelup system completely
    public partial class EndlessGame : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        private Enemy enemy = new Enemy();
        private SpeedUp Sup = new SpeedUp();
        private SpeedDown Sdown = new SpeedDown();
        private KillEnemy eKill = new KillEnemy();
        private GameData GameData = new GameData();

        public EndlessGame()
        {
            InitializeComponent();

            hScoreTxt.Text = GameData.Load(4).ToString();

            new Settings();
            gameTimer.Interval = 1000 / Settings.speed;
            gameTimer.Enabled = true;
            gameTimer.Start();
            Sup = new SpeedUp();
            Sdown = new SpeedDown();
            eKill = new KillEnemy();
            reset();

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

            if (eKill.effect == false) moveEnemy();

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

                if (enemy.collision == true)
                    screen.FillRectangle(Brushes.Red, new Rectangle(
                        enemy.x * Settings.width,
                        enemy.y * Settings.height,
                        Settings.width, Settings.height));

                else
                    screen.FillRectangle(Brushes.DarkRed, new Rectangle(
                        enemy.x * Settings.width,
                        enemy.y * Settings.height,
                        Settings.width, Settings.height));


                if (Sup.flash == false)
                {
                    screen.FillEllipse(Brushes.DeepPink, new Rectangle(
                    Sup.x * Settings.width,
                    Sup.y * Settings.height,
                    Settings.width, Settings.height));
                    Sup.flash = true;
                }
                else
                {
                    screen.FillEllipse(Brushes.LightPink, new Rectangle(
                    Sup.x * Settings.width,
                    Sup.y * Settings.height,
                    Settings.width, Settings.height));
                    Sup.flash = false;
                }

                if (Sdown.flash == false)
                {
                    screen.FillEllipse(Brushes.Blue, new Rectangle(
                    Sdown.x * Settings.width,
                    Sdown.y * Settings.height,
                    Settings.width, Settings.height));
                    Sdown.flash = true;
                }
                else
                {
                    screen.FillEllipse(Brushes.LightBlue, new Rectangle(
                    Sdown.x * Settings.width,
                    Sdown.y * Settings.height,
                    Settings.width, Settings.height));
                    Sdown.flash = false;
                }

                if (eKill.flash == false)
                {
                    screen.FillEllipse(Brushes.Yellow, new Rectangle(
                    eKill.x * Settings.width,
                    eKill.y * Settings.height,
                    Settings.width, Settings.height));
                    eKill.flash = true;
                }
                else
                {
                    screen.FillEllipse(Brushes.LightYellow, new Rectangle(
                    eKill.x * Settings.width,
                    eKill.y * Settings.height,
                    Settings.width, Settings.height));
                    eKill.flash = false;
                }
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
            if (eKill.effect == false) createEnemy();

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

                if (enemy.collision == true && Snake[i].x == enemy.x && Snake[i].y == enemy.y)
                {
                    die();
                }

                if (Sup.spawned == true && Snake[i].x == Sup.x && Snake[i].y == Sup.y)
                {
                    gameTimer.Interval = 500 / Settings.speed;
                    revert();
                    Canvas.BackColor = Color.LightPink;
                    Sup.x = -1 * Settings.width;
                    Sup.y = -1 * Settings.height;
                    Settings.score += Settings.points * 5;
                    ScoreNLbl.Text = Settings.score.ToString();
                }

                if (Sdown.spawned == true && Snake[i].x == Sdown.x && Snake[i].y == Sdown.y)
                {
                    gameTimer.Interval = 1500 / Settings.speed;
                    revert();
                    Canvas.BackColor = Color.LightBlue;
                    Settings.score += Settings.points * 5;
                    ScoreNLbl.Text = Settings.score.ToString();
                    Sdown.x = -1 * Settings.width;
                    Sdown.y = -1 * Settings.height;
                }

                if (eKill.spawned == true && Snake[i].x == eKill.x && Snake[i].y == eKill.y)
                {
                    revert();
                    Canvas.BackColor = Color.Yellow;
                    Settings.score += Settings.points * 5;
                    ScoreNLbl.Text = Settings.score.ToString();
                    eKill.x = -1 * Settings.width;
                    eKill.y = -1 * Settings.height;
                    enemy.x = -2 * Settings.width;
                    enemy.y = -2 * Settings.height;
                    enemy.range = 1;
                    enemy.speed = 1;
                    eKill.effect = true;
                }
            }
        }

        private void generate()
        {
            int maxX = Canvas.Size.Width / Settings.width;
            int maxY = Canvas.Size.Height / Settings.height;
            Random random = new Random();
            food = new Circle { x = random.Next(0, maxX), y = random.Next(0, maxY) };
            Random prandom = new Random();
            Random prandom2 = new Random();

            if (Sup.x > 0 && Sup.y > 0) Sup.spawned = true;
            else if (Sdown.x > 0 && Sdown.y > 0) Sdown.spawned = true;
            else if (eKill.x > 0 && eKill.y > 0) eKill.spawned = true;
            else if (Sup.spawned == false && Sdown.spawned == false && eKill.spawned == false)
            {
                switch (prandom.Next(1, 10))
                {
                    case 1:
                        Sup.x = prandom2.Next(0, maxX);
                        Sup.y = prandom2.Next(0, maxY);
                        Sup.spawned = true;
                        break;
                    case 2:
                        Sdown.x = prandom2.Next(0, maxX);
                        Sdown.y = prandom2.Next(0, maxY);
                        Sdown.spawned = true;
                        break;
                    case 3:
                        eKill.x = prandom2.Next(0, maxX);
                        eKill.y = prandom2.Next(0, maxY);
                        eKill.spawned = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void revert()
        {
            System.Windows.Forms.Timer speedTime = new System.Windows.Forms.Timer();
            speedTime.Interval = 1000 * 10;
            speedTime.Tick += (sender, e) =>
            {
                gameTimer.Interval = 1000 / Settings.speed;
                speedTime.Stop();
                speedTime.Dispose();
                Canvas.BackColor = Color.Gray;
                this.Sup.spawned = false;
                this.Sdown.spawned = false;
                this.eKill.spawned = false;
                this.eKill.effect = false;
            };
            speedTime.Start();
        }

        private void reset()
        {
            gameTimer.Interval = 1000 / Settings.speed;
            Canvas.BackColor = Color.Gray;
            this.Sup.spawned = false;
            this.Sup.x = -1 * Settings.width;
            this.Sup.y = -1 * Settings.height;

            this.Sdown.spawned = false;
            this.Sdown.x = -1 * Settings.width;
            this.Sdown.y = -1 * Settings.height;

            this.eKill.spawned = false;
            this.eKill.x = -1 * Settings.width;
            this.eKill.y = -1 * Settings.height;
            this.eKill.effect = false;
        }

        private void eat()
        {
            Circle body = new Circle() { x = Snake[Snake.Count - 1].x, y = Snake[Snake.Count - 1].y };

            Snake.Add(body);
            Settings.score += Settings.points;
            ScoreNLbl.Text = Settings.score.ToString();
            generate();
            if (eKill.effect == false) createEnemy();
        }

        private void die()
        {
            reset();
            Settings.gameOver = true;
            GameData.Save(4, Settings.score);
            hScoreTxt.Text = GameData.Load(4).ToString();

        }

        private void createEnemy()
        {
            int maxX = Canvas.Size.Width / Settings.width;
            int maxY = Canvas.Size.Height / Settings.height;
            Random random = new Random();
            enemy = new Enemy { x = random.Next(0, maxX), y = random.Next(0, maxY), speed = random.Next(0, 5), range = random.Next(0, 10) };

            // Add spawn period where the collision is disabled
            enemy.collisionTimer.Tick += (sender, e) =>
            {
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (enemy.x == Snake[i].x && enemy.y == Snake[i].y)
                    {
                        enemy.collisionTimer.Stop();
                        enemy.collisionTimer.Start();
                    }
                    else
                    {
                        enemy.collision = true;
                        enemy.collisionTimer.Stop();
                    }
                }
            };
            if (enemy.collisionTimer.Enabled == true)
            {
                enemy.collisionTimer.Stop();
            }
            enemy.collisionTimer.Start();
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

        private void LblMenu_Click(object sender, EventArgs e)
        {
            GameData.Write();
            this.Hide();
            Form menu = new Menu();
            menu.Closed += (s, args) => this.Close();
            menu.Show();
        }

        private void LblRestart_Click(object sender, EventArgs e)
        {
            reset();
            startGame();
        }
    }
}