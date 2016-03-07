using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    internal class Circle : CFigure
    {
        public int Radius;
        private int x_center;
        private int y_center;
        private int x_delta;
        private int y_delta;

        public Circle()
        {
            Id = Guid.NewGuid();
            Position = new Point(40, 10);
            Radius = 20;
            Width = 2 * Radius;
            Height = 2 *Radius;
        }

    public override void DrFigure(Graphics g)
        {
            SerediniStoronMethPoints();

            Pen pen = new Pen(Color.Black, 2);
            g.DrawEllipse(pen, Position.X, Position.Y, Radius * 2, Radius * 2);

            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Times New Roman", 14, FontStyle.Regular);
            g.DrawString("Н", font, brush, Position.X + 10, Position.Y + 10); 
        }
        public override bool Vhod(int cursorX, int cursorY)
        {
            x_center = Position.X + Radius;
            y_center = Position.Y + Radius;

            x_delta = Math.Abs(x_center - cursorX);
            y_delta = Math.Abs(y_center - cursorY);

            if (Math.Pow(x_delta, 2) + Math.Pow(y_delta, 2) < Math.Pow(Radius, 2))
            {
                return true;
            }
            return false;
        }

    }
}
