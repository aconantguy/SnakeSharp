namespace SnakeGame
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LbTitle = new Label();
            btnBasic = new Button();
            BtnMaster = new Button();
            BtnNormal = new Button();
            BtnExpert = new Button();
            lblHint = new Label();
            pnExpert = new Panel();
            pnMaster = new Panel();
            pnExpert.SuspendLayout();
            pnMaster.SuspendLayout();
            SuspendLayout();
            // 
            // LbTitle
            // 
            LbTitle.AutoSize = true;
            LbTitle.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            LbTitle.Location = new Point(319, 9);
            LbTitle.Name = "LbTitle";
            LbTitle.Size = new Size(254, 89);
            LbTitle.TabIndex = 0;
            LbTitle.Text = "Snake#";
            // 
            // btnBasic
            // 
            btnBasic.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnBasic.Location = new Point(319, 351);
            btnBasic.Name = "btnBasic";
            btnBasic.Size = new Size(254, 70);
            btnBasic.TabIndex = 1;
            btnBasic.Text = "Endless Mode";
            btnBasic.UseVisualStyleBackColor = true;
            btnBasic.Click += btnBasic_Click;
            btnBasic.MouseEnter += btnBasic_MouseEnter;
            btnBasic.MouseLeave += emptyHint;
            // 
            // BtnMaster
            // 
            BtnMaster.Enabled = false;
            BtnMaster.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnMaster.Location = new Point(0, 0);
            BtnMaster.Name = "BtnMaster";
            BtnMaster.Size = new Size(254, 70);
            BtnMaster.TabIndex = 2;
            BtnMaster.Text = "Master Mode";
            BtnMaster.UseVisualStyleBackColor = true;
            BtnMaster.Click += BtnMaster_Click;
            BtnMaster.MouseLeave += emptyHint;
            BtnMaster.MouseMove += BtnMaster_MouseEnter;
            // 
            // BtnNormal
            // 
            BtnNormal.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnNormal.Location = new Point(319, 125);
            BtnNormal.Name = "BtnNormal";
            BtnNormal.Size = new Size(254, 70);
            BtnNormal.TabIndex = 3;
            BtnNormal.Text = "Normal Mode";
            BtnNormal.UseVisualStyleBackColor = true;
            BtnNormal.Click += BtnNormal_Click;
            BtnNormal.MouseEnter += BtnNormal_MouseEnter;
            BtnNormal.MouseLeave += emptyHint;
            // 
            // BtnExpert
            // 
            BtnExpert.Enabled = false;
            BtnExpert.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnExpert.Location = new Point(0, 0);
            BtnExpert.Name = "BtnExpert";
            BtnExpert.Size = new Size(254, 70);
            BtnExpert.TabIndex = 4;
            BtnExpert.Text = "Expert Mode";
            BtnExpert.UseVisualStyleBackColor = true;
            BtnExpert.Click += BtnExpert_Click;
            BtnExpert.MouseLeave += emptyHint;
            BtnExpert.MouseMove += BtnExpert_MouseEnter;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblHint.Location = new Point(0, 428);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(0, 31);
            lblHint.TabIndex = 5;
            // 
            // pnExpert
            // 
            pnExpert.Controls.Add(BtnExpert);
            pnExpert.Location = new Point(319, 201);
            pnExpert.Name = "pnExpert";
            pnExpert.Size = new Size(254, 70);
            pnExpert.TabIndex = 6;
            pnExpert.MouseEnter += BtnExpert_MouseEnter;
            pnExpert.MouseLeave += emptyHint;
            // 
            // pnMaster
            // 
            pnMaster.Controls.Add(BtnMaster);
            pnMaster.Location = new Point(319, 277);
            pnMaster.Name = "pnMaster";
            pnMaster.Size = new Size(254, 72);
            pnMaster.TabIndex = 7;
            pnMaster.MouseEnter += BtnMaster_MouseEnter;
            pnMaster.MouseLeave += emptyHint;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 459);
            Controls.Add(pnMaster);
            Controls.Add(pnExpert);
            Controls.Add(lblHint);
            Controls.Add(BtnNormal);
            Controls.Add(btnBasic);
            Controls.Add(LbTitle);
            MaximizeBox = false;
            Name = "Menu";
            Text = "Menu";
            pnExpert.ResumeLayout(false);
            pnMaster.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbTitle;
        private Button btnBasic;
        private Button BtnMaster;
        private Button BtnNormal;
        private Button BtnExpert;
        private Label lblHint;
        private Panel pnExpert;
        private Panel pnMaster;
    }
}