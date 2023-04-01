﻿namespace SnakeGame
{
    partial class GameScreen
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
            ScoreLbl.Location = new Point(756, 0);
            ScoreLbl.Name = "ScoreLbl";
            ScoreLbl.Size = new Size(79, 31);
            ScoreLbl.TabIndex = 1;
            ScoreLbl.Text = "Score:";
            // 
            // ScoreNLbl
            // 
            ScoreNLbl.AutoSize = true;
            ScoreNLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ScoreNLbl.Location = new Point(756, 31);
            ScoreNLbl.Name = "ScoreNLbl";
            ScoreNLbl.Size = new Size(38, 31);
            ScoreNLbl.TabIndex = 2;
            ScoreNLbl.Text = "00";
            // 
            // EndLbl
            // 
            EndLbl.AutoSize = true;
            EndLbl.BackColor = Color.Black;
            EndLbl.ForeColor = Color.Yellow;
            EndLbl.Location = new Point(342, 210);
            EndLbl.Name = "EndLbl";
            EndLbl.Size = new Size(65, 20);
            EndLbl.TabIndex = 3;
            EndLbl.Text = "End Text";
            EndLbl.Visible = false;
            // 
            // hScore
            // 
            hScore.AutoSize = true;
            hScore.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            hScore.Location = new Point(756, 76);
            hScore.Name = "hScore";
            hScore.Size = new Size(138, 31);
            hScore.TabIndex = 4;
            hScore.Text = "High Score:";
            // 
            // hScoreTxt
            // 
            hScoreTxt.AutoSize = true;
            hScoreTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            hScoreTxt.Location = new Point(756, 107);
            hScoreTxt.Name = "hScoreTxt";
            hScoreTxt.Size = new Size(38, 31);
            hScoreTxt.TabIndex = 5;
            hScoreTxt.Text = "00";
            // 
            // GameScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 459);
            Controls.Add(hScoreTxt);
            Controls.Add(hScore);
            Controls.Add(EndLbl);
            Controls.Add(ScoreNLbl);
            Controls.Add(ScoreLbl);
            Controls.Add(Canvas);
            Name = "GameScreen";
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
    }
}