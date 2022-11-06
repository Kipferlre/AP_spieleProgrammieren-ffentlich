using Snake_Versuch_01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_spieleProgrammieren
{
    public partial class snake : Form
    {
        public snake()
        {
            InitializeComponent();
        }
        Rectangle[,] rectangles;
        Grid grid;
        
        Rectangle rect = new Rectangle();
        Rectangle[] Snake;
        Rectangle futter = new Rectangle();
        int XRectanglePosition;
        int YRectanglePosition;
        bool noDeathFrame = false;
        String direction = "right";
        String realDirektion = "right";
        Random random = new Random();
        Point pointA;
        Point pointB;
        Point pointC;
        Point pointD;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
            this.BackColor = Color.LightGreen;
            grid = new Grid(this, new Point(this.Width / 4, 0), new Size(this.Width / 2, this.Height), new Size(90, 90));
            //grid = new Grid(this, new Point(this.Width / 2, this.Height/4), new Size(50,50),5,4);
            rectangles = grid.getRectangleArr();
            XRectanglePosition = Convert.ToInt32(rectangles.GetLength(0) / 2);
            YRectanglePosition = Convert.ToInt32(rectangles.GetLength(1) / 2);
            pointA = rectangles[0, 0].Location;
            pointB = rectangles[rectangles.GetLength(0) - 1, 0].Location;
            pointB.X += rectangles[rectangles.GetLength(0) - 1, 0].Width;
            pointC = rectangles[0, rectangles.GetLength(1) - 1].Location;
            pointC.Y += rectangles[0, rectangles.GetLength(1) - 1].Width;
            pointD = rectangles[rectangles.GetLength(0) - 1, rectangles.GetLength(1) - 1].Location;
            pointD.Y += rectangles[rectangles.GetLength(0) - 1, rectangles.GetLength(1) - 1].Height;
            pointD.X += rectangles[rectangles.GetLength(0) - 1, rectangles.GetLength(1) - 1].Width;
            Snake = new Rectangle[1];
            Snake[0] = rect;
            SetnewLocaiton();
        }

        private void SetnewLocaiton()
        {
            List<Point> points = new List<Point>();
            bool enthaelt = false;
            for (int i = 0; i < rectangles.GetLength(0) ; i++)
            {
                for (int a = 0; a < rectangles.GetLength(1); a++)
                {
                    Point point1 = new Point(rectangles[i, a].X, rectangles[i, a].Y);
                    for (int o = 0; o < Snake.Length; o++)
                    {
                       
                        Point point2 = new Point(Snake[o].X, Snake[o].Y);
                        if (point1.Equals(point2))
                        {
                            enthaelt = true;
                        }
                        else
                        {
                            continue;
                        }
                        
                    }
                    if (!enthaelt)
                        points.Add(point1);
                }
            }
            int feld = random.Next(1,points.Count);
                futter.X = points[feld].X;
                futter.Y = points[feld].Y;
                futter.Size = rectangles[0, 0].Size;
            
            
            
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.DrawLine(Pens.Black, pointA, pointB);
            e.Graphics.DrawLine(Pens.Black, pointA, pointC);
            e.Graphics.DrawLine(Pens.Black, pointD, pointB);
            e.Graphics.DrawLine(Pens.Black, pointD, pointC);
            try
            {
                int vorherigeX = Snake[0].Location.X;
                int vorherigeY = Snake[0].Location.Y;
                Snake[0].Size = rectangles[XRectanglePosition, YRectanglePosition].Size;
                Snake[0].X = rectangles[XRectanglePosition, YRectanglePosition].X;
                Snake[0].Y = rectangles[XRectanglePosition, YRectanglePosition].Y;
                for (int i = 1; i < Snake.Length; i++)
                {
                    Point zwischenXY = Snake[i].Location;
                    Snake[i].Location = new Point(vorherigeX, vorherigeY);
                    Snake[i].Size = Snake[0].Size;
                    e.Graphics.FillRectangle(Brushes.Black, Snake[i]);
                    vorherigeX = zwischenXY.X;
                    vorherigeY = zwischenXY.Y;
                }


            }
            catch
            {
                DEATH();
            }
            try
            {
                e.Graphics.FillRectangle(Brushes.White, Snake[0]);
                e.Graphics.FillRectangle(Brushes.Red, futter);
            }
            catch
            {

            }



        }
        private void DEATH()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            MessageBox.Show("du hund bist tod!");



            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (direction)
            {
                case "right":
                    XRectanglePosition += 1;
                    realDirektion = direction;
                    break;
                case "left":
                    XRectanglePosition -= 1;
                    realDirektion = direction;
                    break;
                case "up":
                    YRectanglePosition -= 1;
                    realDirektion = direction;
                    break;
                case "down":
                    YRectanglePosition += 1;
                    realDirektion = direction;
                    break;
                default:
                    XRectanglePosition += 1;
                    realDirektion = "right";
                    break;
            }
            if (!noDeathFrame)
            {
                bool enthalten = true;
                for (int i = 1; i < Snake.Length; i++)
                {

                    if (Snake[0].Location.Equals(Snake[i].Location))
                    {
                        for (int a = 0; a < rectangles.GetLength(0); a++)
                        {
                            for (int u = 0; u < rectangles.GetLength(1); u++)
                            {
                                for (int o = 0; o < Snake.Length; o++)
                                {
                                    if (!Snake[o].Location.Equals(rectangles[a, u].Location))
                                    {
                                        enthalten = false;
                                    }
                                }
                            }

                        }
                        if (enthalten)
                        {
                            Gewinnen();
                        }
                        else
                        {
                            DEATH();
                        }

                    }
                }
            }
            noDeathFrame = false;
            Invalidate();


        }
        private void Gewinnen()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            MessageBox.Show("Du hast gewonnen");
        }
        private void makeBigger(int anzahl)
        {
            for (int a = 1; a <= anzahl; a++)
            {
                noDeathFrame = true;

                Rectangle newBody = new Rectangle();
                Rectangle[] ersatzSnake = new Rectangle[Snake.Length + 1];
                for (int i = 0; i < Snake.Length; i++)
                {
                    ersatzSnake[i] = Snake[i];
                }
                ersatzSnake[ersatzSnake.Length - 1] = newBody;
                Snake = ersatzSnake;
                Invalidate();
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (realDirektion != "right")
                if (e.KeyChar == 'a')
                    direction = "left";

            if (realDirektion != "left")
                if (e.KeyChar == 'd')
                    direction = "right";

            if (realDirektion != "down")
                if (e.KeyChar == 'w')
                    direction = "up";

            if (realDirektion != "up")
                if (e.KeyChar == 's')
                    direction = "down";
            if (e.KeyChar == 'j')
                makeBigger(10);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (Snake[0].Location.Equals(futter.Location))
            {
                makeBigger(1);
                SetnewLocaiton();



            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1.f1.Show();
            this.Close();
            
        }
    }
}
                      