namespace SnakeGame
{
    partial class ExpertGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTimer = new System.Windows.Forms.Timer(components);
            Canvas = new PictureBox();
            ScoreLbl = new Label();
            ScoreNLbl = new Label();
            EndLbl = new Label();
            hScore = new Label();
            hScoreTxt = new Label();
            LblMenu = new Label();
            LblRestart = new Label();
            LevelLbl = new Label();
            LevelNLbl = new Label();
            NextLbl = new Label();
            NextNLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Tick += updateScreen;
            // 
            // Canvas
            // 
            Canvas.BackColor = Color.Gray;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(750, 460);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.Paint += updateGraphics;
            // 
            // ScoreLbl
            // 
            ScoreLbl.AutoSize = true;
            ScoreLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            ScoreLbl.Location = new Point(756, 147);
            ScoreLbl.Name = "ScoreLbl";
            ScoreLbl.Size = new Size(79, 31);
            ScoreLbl.TabIndex = 1;
            ScoreLbl.Text = "Score:";
            // 
            // ScoreNLbl
            // 
            ScoreNLbl.AutoSize = true;
            ScoreNLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ScoreNLbl.Location = new Point(756, 178);
            ScoreNLbl.Name = "ScoreNLbl";
            ScoreNLbl.Size = new Size(38, 31);
            ScoreNLbl.TabIndex = 2;
            ScoreNLbl.Text = "00";
            // 
            // EndLbl
            // 
            EndLbl.AutoSize = true;
            EndLbl.BackColor = Color.Black;
            EndLbl.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            EndLbl.ForeColor = Color.White;
            EndLbl.Location = new Point(298, 178);
            EndLbl.Name = "EndLbl";
            EndLbl.Size = new Size(120, 38);
            EndLbl.TabIndex = 3;
            EndLbl.Text = "End Text";
            EndLbl.TextAlign = ContentAlignment.MiddleCenter;
            EndLbl.Visible = false;
            // 
            // hScore
            // 
            hScore.AutoSize = true;
            hScore.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            hScore.Location = new Point(756, 223);
            hScore.Name = "hScore";
            hScore.Size = new Size(138, 31);
            hScore.TabIndex = 4;
            hScore.Text = "High Score:";
            // 
            // hScoreTxt
            // 
            hScoreTxt.AutoSize = true;
            hScoreTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            hScoreTxt.Location = new Point(756, 254);
            hScoreTxt.Name = "hScoreTxt";
            hScoreTxt.Size = new Size(38, 31);
            hScoreTxt.TabIndex = 5;
            hScoreTxt.Text = "00";
            // 
            // LblMenu
            // 
            LblMenu.BackColor = Color.FromArgb(255, 128, 128);
            LblMenu.BorderStyle = BorderStyle.FixedSingle;
            LblMenu.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            LblMenu.Location = new Point(756, 401);
            LblMenu.Name = "LblMenu";
            LblMenu.Size = new Size(138, 47);
            LblMenu.TabIndex = 6;
            LblMenu.Text = "Menu";
            LblMenu.TextAlign = ContentAlignment.MiddleCenter;
            LblMenu.Click += LblMenu_Click;
            // 
            // LblRestart
            // 
            LblRestart.BackColor = Color.FromArgb(128, 255, 128);
            LblRestart.BorderStyle = BorderStyle.FixedSingle;
            LblRestart.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            LblRestart.Location = new Point(756, 342);
            LblRestart.Name = "LblRestart";
            LblRestart.Size = new Size(138, 47);
            LblRestart.TabIndex = 7;
            LblRestart.Text = "Restart";
            LblRestart.TextAlign = ContentAlignment.MiddleCenter;
            LblRestart.Click += LblRestart_Click;
            // 
            // LevelLbl
            // 
            LevelLbl.AutoSize = true;
            LevelLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            LevelLbl.Location = new Point(756, 9);
            LevelLbl.Name = "LevelLbl";
            LevelLbl.Size = new Size(75, 31);
            LevelLbl.TabIndex = 8;
            LevelLbl.Text = "Level:";
            // 
            // LevelNLbl
            // 
            LevelNLbl.AutoSize = true;
            LevelNLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            LevelNLbl.Location = new Point(756, 40);
            LevelNLbl.Name = "LevelNLbl";
            LevelNLbl.Size = new Size(26, 31);
            LevelNLbl.TabIndex = 9;
            LevelNLbl.Text = "1";
            // 
            // NextLbl
            // 
            NextLbl.AutoSize = true;
            NextLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            NextLbl.Location = new Point(756, 77);
            NextLbl.Name = "NextLbl";
            NextLbl.Size = new Size(133, 31);
            NextLbl.TabIndex = 10;
            NextLbl.Text = "Next Level:";
            // 
            // NextNLbl
            // 
            NextNLbl.AutoSize = true;
            NextNLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            NextNLbl.Location = new Point(756, 108);
            NextNLbl.Name = "NextNLbl";
            NextNLbl.Size = new Size(38, 31);
            NextNLbl.TabIndex = 11;
            NextNLbl.Text = "00";
            // 
            // NormalGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 459);
            ControlBox = false;
            Controls.Add(NextNLbl);
            Controls.Add(NextLbl);
            Controls.Add(LevelNLbl);
            Controls.Add(LevelLbl);
            Controls.Add(LblRestart);
            Controls.Add(LblMenu);
            Controls.Add(hScoreTxt);
            Controls.Add(hScore);
            Controls.Add(EndLbl);
            Controls.Add(ScoreNLbl);
            Controls.Add(ScoreLbl);
            Controls.Add(Canvas);
            Name = "NormalGame";
            Text = "Snake";
            KeyDown += keyDown;
            KeyUp += keyUp;
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Canvas;
        private Label ScoreLbl;
        private Label ScoreNLbl;
        private Label EndLbl;
        internal System.Windows.Forms.Timer gameTimer;
        private Label hScore;
        private Label hScoreTxt;
        private Label LblMenu;
        private Label LblRestart;
        private Label LevelLbl;
        private Label LevelNLbl;
        private Label NextLbl;
        private Label NextNLbl;
    }
}