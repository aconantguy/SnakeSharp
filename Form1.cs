namespace SnakeGame
{
    public partial class Form1 : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        public Form1()
        {
            InitializeComponent();

            new Settings();

            gameTimer.Interval = 1000 / Settings.speed;
            gameTimer.Tick += updateScreen;
            gameTimer.Start();

            startGame();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {

        }

        private void keyUp(object sender, KeyEventArgs e)
        {

        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {

        }

        private void startGame()
        {

        }

        private void move()
        {

        }

        private void generate()
        {

        }

        private void eat()
        {

        }

        private void die()
        {

        }
    }
}