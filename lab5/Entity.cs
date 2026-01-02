using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace lab5
{
    public abstract class Entity
    {
        protected Form1 form;
        public Button button;
        protected int min_speed = 0;
        protected int max_speed = 3;
        protected int dx = 0;
        protected int dy = 0;
        public int Max_speed
        {
            get { return max_speed; }
            set { max_speed = value; }
        }
        public int Dx
        {
            get { return dx; }
            set { dx = value; }
        }
        public int Dy
        {
            get { return dy; }
            set { dy = value; }
        }
        public Point vector;
        Size size = new Size(50, 25);
        public Entity(Form1 form)
        {
            this.form = form;
            this.button = new Button();
            this.button.Size = size;
            form.Controls.Add(this.button);
        }
        public virtual void Move()
        {
            Point current_button_location = button.Location;
            current_button_location.Offset(vector);
            button.Location = current_button_location;
        }
    }
}
