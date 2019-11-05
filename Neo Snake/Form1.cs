using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neo_Snake
{
    public partial class Form1 : Form
    {
        private bool isGameWorking;
        private bool isFirstLaunch;
        private NeoSnake neo;
        private Fruit frt;

        public Form1()
        {
            InitializeComponent();
            isGameWorking = false;
            isFirstLaunch = true;
            timer1.Enabled = true;
            pauzaToolStripMenuItem.Enabled = false;
            restartToolStripMenuItem.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isGameWorking == true)
            {   
                pole_gry.CreateGraphics().Clear(Color.Black);
                neo.move();
                neo.draw(pole_gry.CreateGraphics(), new SolidBrush(Color.Aqua));
                frt.drawFruit(pole_gry.CreateGraphics(), new SolidBrush(Color.PaleVioletRed));
                if(frt.isNewFruit(neo.getHeadX(), neo.getHeadY()) == true)
                {
                    neo.eat();
                }
                if(neo.isAlive() == false)
                {
                    isGameWorking = false;
                }

                
            }
            if (isFirstLaunch)
            {
                FontFamily fontFamily1 = new FontFamily("Arial");
                Font font1 = new Font(fontFamily1, 15);
                Color color1 = Color.Aqua;
                Brush brush1 = new SolidBrush(color1);
                pole_gry.CreateGraphics().DrawString("ROZPOCZNIJ GRE", font1, brush1, 80, 130);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isGameWorking = true;
            isFirstLaunch = false;
            pauzaToolStripMenuItem.Enabled = true;
            restartToolStripMenuItem.Enabled = true;
            neo = new NeoSnake(pole_gry.Width, pole_gry.Height);
            frt = new Fruit(neo.getSegment());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) neo.setMoveDirection("up");
            if (e.KeyCode == Keys.Down) neo.setMoveDirection("down");
            if (e.KeyCode == Keys.Left) neo.setMoveDirection("left");
            if (e.KeyCode == Keys.Right) neo.setMoveDirection("right");
        }

        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isGameWorking == true)
            {
                isGameWorking = false;
                pole_gry.CreateGraphics().Clear(Color.Black);
                pauzaToolStripMenuItem.Text = "Wznów";

                FontFamily fontFamily1 = new FontFamily("Arial");
                Font font1 = new Font(fontFamily1, 15);
                Color color1 = Color.Aqua;
                Brush brush1 = new SolidBrush(color1);
                pole_gry.CreateGraphics().DrawString("Wstrzymano", font1, brush1, 80, 130);
            }
            else
            {
                isGameWorking = true;
                pauzaToolStripMenuItem.Text = "Pauza";

            }
        }

        private void pole_gry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGameWorking)
            {
                neo = new NeoSnake(pole_gry.Width, pole_gry.Height);
                frt = new Fruit(neo.getSegment());
            }

        }

        private void wolniejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(timer1.Interval > 10)
            timer1.Interval += 10;
        }

        private void szybciejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval -= 10;
        }
    }
}
