using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class RectanglePunctir:CFigure
    {
        public RectanglePunctir()
        {
            Position = new Point(120, 90);
            Id = Guid.NewGuid();
            Height = 50;
            Width = 60;
            TextFigure = "";
            ColorFigure = Color.Black;
        }
        public override void DrFigure(Graphics g)
        {
            len = DrowText(g, Position.X + 2, Position.Y + 2);

            Width = len.Width > 60 ? len.Width + 10 : 60;
            Height = len.Height > 50 ? len.Height + 10 : 50;

            SerediniStoronMethPoints();

            Pen pen = new Pen(ColorFigure,2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawRectangle(pen, Position.X, Position.Y, Width, Height);
        }
        public override bool Vhod(int cursorX, int cursorY)
        {
            if (cursorX >= Position.X && cursorX <= Position.X + Width && cursorY >= Position.Y && cursorY <= Position.Y + Height)
            {
                return true;
            }
            return false;
        }
    }
}
