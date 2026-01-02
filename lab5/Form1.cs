using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        private List<Enemy> enemies = new List<Enemy>();
        private Player player;
        static int count_enemies = 25;
        protected bool game_run = true;
        DateTime launch_time = DateTime.Now;
        Random rnd;
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            player = new Player(this);
            player.EndGame += delegate () { 
                game_run = false;
                MessageBox.Show($"Вы проиграли, ваше время {Math.Round((DateTime.Now - launch_time).TotalSeconds, 2)} секунд", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            };
            for (int i = 0; i < count_enemies; i++)
            {
                enemies.Add(new Enemy(this, rnd));
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                for(int i = 0; i < count_enemies; i++)
                {
                    this.Controls.Remove(enemies[i].button);
                    enemies[i].button.Dispose();
                }
                this.Controls.Remove(player.button);
                player.button.Dispose();
                player = new Player(this);
                player.EndGame += delegate () {
                    game_run = false;
                    MessageBox.Show($"Вы проиграли, ваше время {Math.Round((DateTime.Now - launch_time).TotalSeconds, 2)} секунд", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                };
                enemies.Clear();
                for (int i = 0; i < count_enemies; i++)
                {
                    enemies.Add(new Enemy(this, rnd));
                }
                game_run=true;
                launch_time = DateTime.Now;
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) player.Dy = -player.Max_speed;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) player.Dy = player.Max_speed;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) player.Dx = -player.Max_speed;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) player.Dx = player.Max_speed;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) player.Dy = 0;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) player.Dy = 0;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) player.Dx = 0;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) player.Dx = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game_run)
            {
                foreach (Entity enemy in enemies)
                {
                    enemy.Move();
                }
                player.Move();
                player.Check(enemies);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
