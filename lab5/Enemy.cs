using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    internal class Enemy : Entity
    {
        
        
        private Random rnd;
        
        public Enemy(Form1 form, Random rnd) : base(form)
        {
            this.rnd = rnd;
            int x;
            int y = rnd.Next(form.ClientSize.Height - this.button.Size.Height);
            int safeZoneStart = form.ClientSize.Width / 2 - 50;
            int safeZoneEnd = form.ClientSize.Width / 2 + 50;

            do
            {
                x = rnd.Next(form.ClientSize.Width - this.button.Size.Width);
            } while (x >= safeZoneStart && x <= safeZoneEnd);
            this.button.Location = new Point(x, y);
            this.button.Text = "Enemy";
            max_speed = 2;
            dx = rnd.Next(min_speed, max_speed + 1);
            dy = rnd.Next(min_speed, max_speed + 1);
            vector = new Point(dx, dy);
        }
        public override void Move()
        {
            base.Move();
            Point current_button_location = button.Location;
            if (current_button_location.X <= 0 )
            {
                current_button_location.X = 0;
                vector.X = dx;
            }
            if (current_button_location.X + button.Size.Width >= form.ClientSize.Width)
            {
                current_button_location.X = form.ClientSize.Width - button.Size.Width;
                vector.X = -dx;
            }
            if (current_button_location.Y <= 0 )
            {
                current_button_location.Y = 0;
                vector.Y = dy;
            }
            if(current_button_location.Y + button.Size.Height >= form.ClientSize.Height)
            {
                current_button_location.Y = form.ClientSize.Height - button.Size.Height;
                vector.Y = -dy;
            }
        }
    }
}
