using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public delegate void PlayerEvent();
    internal class Player : Entity
    {
        public event PlayerEvent EndGame;
        public Player(Form1 form) : base(form)
        {
            Point center = new Point((form.ClientSize.Width - button.Width) / 2, (form.ClientSize.Height - button.Height) / 2);
            button.Location = center;
            button.Text = "Player";
        }
        public override void Move()
        {
            vector.X = dx;
            vector.Y = dy;
            Point current_button_location = button.Location;
            if (current_button_location.X <= 0)
            {
                current_button_location.X = 0;
            }
            if (current_button_location.X + button.Size.Width >= form.ClientSize.Width)
            {
                current_button_location.X = form.ClientSize.Width - button.Size.Width;
            }
            if (current_button_location.Y <= 0)
            {
                current_button_location.Y = 0;
            }
            if (current_button_location.Y + button.Size.Height >= form.ClientSize.Height)
            {
                current_button_location.Y = form.ClientSize.Height - button.Size.Height;
            }
            this.button.Location = current_button_location;
            base.Move();
        }
        public void Check(List<Enemy> entities)
        {
            foreach (Entity entity in entities)
            {
                if (this.button.Bounds.IntersectsWith(entity.button.Bounds))
                {
                    this.button.Text = "Collide";
                    EndGame();
                }
            }
        }
    }
}
