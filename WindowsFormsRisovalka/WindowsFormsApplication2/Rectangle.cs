using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class Rectangle: CFigure
    {
        public override void DrRectangle(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
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
