using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Line:CFigure
    {
        public Point PositionLine { get; set; }
        public bool Otrisovka { get; set; }
        public bool KvNachalo { get; set; }
        public bool KvKonec { get; set; }
        public override void DrRectangle(Graphics g)
        {
            Pen pen = new Pen(Color.Black,4);
            pen.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(pen, Position.X, Position.Y, PositionLine.X, PositionLine.Y);
        }

        public override bool Vhod(int cursorX, int cursorY)
        {
            return false;
        }
    }
}
