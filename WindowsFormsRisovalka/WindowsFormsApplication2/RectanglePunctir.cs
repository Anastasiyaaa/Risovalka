using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class RectanglePunctir:CFigure
    {
        
        public override void DrRectangle(Graphics g)
        {
            Pen pen = new Pen(Color.Black,2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawRectangle(pen, Position.X, Position.Y, Width, Height);
        }
        public override bool Vhod(int cursorX, int cursorY)
        {
            if (cursorX > Position.X && cursorX < Position.X + Width && cursorY > Position.Y && cursorY < Position.Y + Height)
            {
                return true;
            }
            return false;
        }
    }
}
