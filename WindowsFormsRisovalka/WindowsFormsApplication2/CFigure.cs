using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public abstract class CFigure
    {
        public Point Position { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Point Delta { get; set; }
        public bool Perenos { get; set; }
        public bool OtrisovkaLine { get; set; }

        public Point[] Array;
        public Point[] ArrayPoints()
        {
            Array = new Point[4];
            Array[0] = new Point(Position.X + Width / 2, Position.Y);
            Array[1] = new Point(Position.X + Width, Position.Y + Height / 2);
            Array[2] = new Point(Position.X + Width / 2, Position.Y + Height);
            Array[3] = new Point(Position.X, Position.Y + Height / 2);
            return Array;
        }
        public abstract void DrRectangle(Graphics g);

        public abstract bool Vhod(int cursorX, int cursorY);
    }
}
