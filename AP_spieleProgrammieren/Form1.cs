namespace AP_spieleProgrammieren
{
    public partial class Form1 : Form
    {
        internal static Form1 f1;
        public Form1()
        {
            f1 = this;
            InitializeComponent();
        }
        internal VierGewinnt vierGewinnt;
        internal snake snake;
        private void button1_Click(object sender, EventArgs e)
        {
            vierGewinnt = new VierGewinnt();
            vierGewinnt.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            snake = new snake();
            snake.Show();
            this.Hide();         
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tetris tetris = new Tetris();
            tetris.Show();
            this.Hide();
        }
    }
}