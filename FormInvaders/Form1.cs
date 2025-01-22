using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyAPPSI
{
    public partial class Form1 : Form
    {
        bool goleft;
        bool goright;
        int speed = 5;
        int invaderstep = 350;
        int currentinvaderstep;
        int score = 0;
        bool isPressed;
        int totalEnemies = 12;
        int playerSpeed = 6;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goleft)
            {
                player.Left -= playerSpeed;
            }
            else if(goright)
            {
                player.Left += playerSpeed;
            }
            //enemies moving on the form
            foreach (Control x in this.Controls)
            {
                PictureBox Invader = null;
                PictureBox Bullet = null;

                if (x is PictureBox && x.Tag == "Invaders")
                {
                    Invader = x as PictureBox;

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        gameOver();
                        MessageBox.Show("Game Over.");
                    }

                    if (x.Left >= 0 & x.Left <= 800)
                        x.Left += -speed;
                    else
                        x.Left += speed;

                    currentinvaderstep -= 1;

                    if (currentinvaderstep < 1)
                    {
                        currentinvaderstep = invaderstep;
                        speed = -speed;
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;
                    }
                }

                if (x is PictureBox && x.Tag == "bullet")
                { 
                    //animate bullets
                    x.Top -= 8;

                    if (x.Top < this.Height - 490)
                    {
                        this.Controls.Remove(x);
                    }
                } //end of animating the bullets

                //control and enemy collision start
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox && control.Tag == "bullet")
                    {
                        if (x is PictureBox && x.Tag == "Invaders")
                        {
                            Bullet = control as PictureBox;

                            if (x.Bounds.IntersectsWith(Bullet.Bounds))
                            {
                                score++;
                                this.Controls.Remove(x);
                                this.Controls.Remove(Bullet);
                            }
                        }
                    }
                    else continue;
                }
            }

            // keeping and showing score
            label1.Text = "Score : " + score;

            if (score > totalEnemies - 1)
            {
                gameOver();
                MessageBox.Show("You Saved Earth");
            }
            //end of showing score
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
            
                makeBullet();
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (isPressed)
            {
                isPressed = false;
            }
        }

        private void makeBullet()
        { 
            PictureBox bullet = new PictureBox();
        
            bullet.Image = Properties.Resources.Bullet;
        
            bullet.Size = new Size(5, 20);
        
            bullet.Tag = "bullet";
        
            bullet.Left = player.Left + player.Width / 2;
        
            bullet.Top = player.Top - 20;
        
            this.Controls.Add(bullet);
        
            bullet.BringToFront();
        }

        private void gameOver()
        {
            timer1.Stop();
            label1.Text += " Game Over";            
        }
    };
}