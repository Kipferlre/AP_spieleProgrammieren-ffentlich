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
    public partial class Tetris : Form
    {
        public Tetris()
        {
            InitializeComponent();
        }
        Rectangle[,] grid;
        Rectangle[,] bloecke;
        Rectangle[,] gesetzteBloecke;
        private void Tetris_Load(object sender, EventArgs e)
        {
            Grid gridRaw = new Grid(this, new Point(0, 0), new Size(50, 50), 10, 16);
            grid = gridRaw.getRectangleArr();
            bloecke = new Rectangle[grid.GetLength(0), grid.GetLength(1)];
            gesetzteBloecke = new Rectangle[4,4];
            createRectangle();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen penBalck = new Pen(Color.Black);
            Pen penPurple = new Pen(Color.Purple);
            penBalck.Width =5;
            penPurple.Width = 5;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int a = 3; a < grid.GetLength(1); a++)
                {
                    if(i%2==0)
                    e.Graphics.DrawRectangle(penBalck,grid[i,a]);
                    else
                    e.Graphics.DrawRectangle(penPurple, grid[i,a]);

                }
            }
            for (int i = 0; i < bloecke.GetLength(0); i++)
            {
                for (int a = 0; a < bloecke.GetLength(1); a++)
                {
                    e.Graphics.FillRectangle(Brushes.Orange, bloecke[i, a]);
                }
            }
        }
        #region createForm
        void createRectangle()
        {
            gesetzteBloecke[1, 1] = new Rectangle(grid[4, 0].Location, grid[4,0].Size);
            gesetzteBloecke[1, 2] = new Rectangle(grid[4, 1].Location, grid[4, 1].Size);
            gesetzteBloecke[2, 1] = new Rectangle(grid[5, 0].Location, grid[5, 0].Size);
            gesetzteBloecke[2, 2] = new Rectangle(grid[5, 1].Location, grid[5, 1].Size);

            bloecke[4, 0] = gesetzteBloecke[1, 1];
            bloecke[4, 1] = gesetzteBloecke[1, 2];
            bloecke[5, 0] = gesetzteBloecke[2, 1];
            bloecke[5, 1] = gesetzteBloecke[2, 2];

            Invalidate();
        }
        void createLine()
        {

        }
        void createL()
        {

        }
        void createReverseL()
        {

        }
        void createT()
        {

        }
        void createQuigly()
        {

        }
        void createReverseQuigly()
        {

        }
        #endregion
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Close();
        }
    }
}
