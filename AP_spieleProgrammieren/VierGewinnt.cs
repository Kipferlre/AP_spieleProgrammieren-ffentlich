using Snake_Versuch_01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_spieleProgrammieren
{
    public partial class VierGewinnt : Form
    {
        public VierGewinnt()
        {
            InitializeComponent();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Close();
        }
        Rectangle[,] grid;
        Rectangle[,] Ellipses;
        char[,] belegt;
        char amZug = 'r';
        private void VierGewinnt_Load(object sender, EventArgs e)
        {
            beginn();
        }
        private void beginn()
        {
            Grid gr = new Grid(this, new Point(this.Width / 2 - (630 / 2), 50), new Size(90, 90), 7, 6);

            grid = gr.getRectangleArr();
            Ellipses = new Rectangle[grid.GetLength(0), grid.GetLength(1)];
            belegt = new char[Ellipses.GetLength(0), Ellipses.GetLength(1)];
            for (int i = 0; i < belegt.GetLength(0); i++)
            {
                for (int a = 0; a < belegt.GetLength(1); a++)
                {
                    belegt[i, a] = '0';
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int a = 0; a < grid.GetLength(1); a++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, grid[i, a]);
                }
            }
            for (int i = 0; i < Ellipses.GetLength(0); i++)
            {
                for (int a = 0; a < Ellipses.GetLength(1); a++)
                {
                    if (belegt[i,a].Equals('r'))
                    e.Graphics.FillEllipse(Brushes.Red, Ellipses[i, a]);
                    else
                    e.Graphics.FillEllipse(Brushes.Blue, Ellipses[i, a]);
                }
            }
        }
        private void KontrollierenGewinnen()
        {
            char spielerKontrollieren = '0';
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int a = 0; a < grid.GetLength(1); a++)
                {
                    if (!belegt[i, a].Equals('0'))
                    {
                        spielerKontrollieren = belegt[i, a];
                        for (int herumi = i-1; herumi <= i+1; herumi++)
                        {
                            for (int heruma = a - 1; heruma <= a + 1; heruma++)
                            {
                                try
                                {
                                    if (belegt[herumi, heruma].Equals(spielerKontrollieren))
                                    {
                                        if (i != herumi || a != heruma)
                                        {
                                            int iDifferenz = herumi - i;
                                            int aDifferenz = heruma - a;
                                            if (belegt[herumi + iDifferenz, heruma + aDifferenz].Equals(spielerKontrollieren))
                                            {
                                                if (belegt[herumi + iDifferenz + iDifferenz, heruma + aDifferenz + aDifferenz].Equals(spielerKontrollieren))
                                                {
                                                    Gewinnen(spielerKontrollieren);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Gewinnen(char spieler)
        {
            if (spieler.Equals('r'))
                MessageBox.Show("Spieler ROT gewinnt!!!");
            else
                MessageBox.Show("Spieler BLAU gewinnt!!!");

            DialogResult d = MessageBox.Show("Nochmal?", "Ende", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d != DialogResult.Yes)
            {
                this.Close();
                Form1.f1.Show();
            }
            else
            {
                beginn();
                Invalidate();
            }
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int index = Convert.ToInt32(b.Text)-1;
            AddEllipseToRow(index);
        }
        private void AddEllipseToRow(int index)
        {
            for (int i = grid.GetLength(1)-1; i >= 0; i--)
            {
                bool enhält = false;
                Point point1 = new Point(grid[index, i].X, grid[index,i].Y);
                for (int a = 0; a < Ellipses.GetLength(1); a++)
                {
                    Point point2 = new Point(Ellipses[index, a].X, Ellipses[index, a].Y);
                    if (point2.Equals(point1))
                    {
                        enhält = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }  
                if(!enhält)
                {
                    Rectangle rect = new Rectangle();
                    rect.X = grid[index, i].X;
                    rect.Y = grid[index, i].Y;
                    rect.Size = grid[index, i].Size;
                    Ellipses[index, i] = rect;
                    belegt[index, i] = amZug;
                    Invalidate();
                    break;
                }
                else
                {
                    continue;
                }
            }
            KontrollierenGewinnen();
            if (amZug.Equals('r'))
                amZug = 'b';
            else
                amZug = 'r';
        }
    }
}
