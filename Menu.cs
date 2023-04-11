﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            string unlocks = "0";

            try
            {
                using (ResourceReader resx = new ResourceReader(@".\mu.res"))
                {
                    IDictionaryEnumerator d = resx.GetEnumerator();
                    while (d.MoveNext()) unlocks = d.Value.ToString();
                    resx.Close();
                }
            }
            catch { unlocks = "0"; }

            switch (Convert.ToInt16(unlocks))
            {
                case 1:
                    BtnExpert.Enabled = true;
                    BtnMaster.Text = "? ? ?";
                    break;
                case 2:
                    BtnExpert.Enabled = true;
                    BtnMaster.Enabled = true;
                    break;
                default:
                    BtnExpert.Text = "? ? ?";
                    BtnMaster.Text = "? ? ?";
                    break;
            }
        }
        private void btnBasic_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form game = new EndlessGame();
            game.Closed += (s, args) => this.Close();
            game.Show();
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form game = new NormalGame();
            game.Closed += (s, args) => this.Close();
            game.Show();
        }

        private void BtnExpert_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form game = new ExpertGame();
            game.Closed += (s, args) => this.Close();
            game.Show();
        }

        private void BtnMaster_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form game = new MasterGame();
            game.Closed += (s, args) => this.Close();
            game.Show();
        }

        private void btnBasic_MouseEnter(object sender, EventArgs e)
        {
            lblHint.Text = "Go for as high of a score as you can in this easy-going mode!";
        }

        private void emptyHint(object sender, EventArgs e)
        {
            lblHint.Text = "";
        }

        private void BtnExpert_MouseEnter(object sender, EventArgs e)
        {
            if (BtnExpert.Enabled == false) lblHint.Text = "Reach level 15 or higher in Normal Mode to unlock this difficulty!";
            else lblHint.Text = "Pretty much everything is harder. How long can you survive?";
        }

        private void BtnNormal_MouseEnter(object sender, EventArgs e)
        {
            lblHint.Text = "Eat food and level up as you try to beat the high score!";
        }

        private void BtnMaster_MouseEnter(object sender, EventArgs e)
        {
            if (BtnMaster.Enabled == true) lblHint.Text = "DANGER! This mode is for massochists only! You will receive no mercy!";
            else if (BtnExpert.Enabled == true) lblHint.Text = "Reach level 15 or higher in Expert Mode to unlock this difficulty!";
        }
    }
}
