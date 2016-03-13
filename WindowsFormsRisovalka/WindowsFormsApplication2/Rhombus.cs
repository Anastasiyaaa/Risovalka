using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class Rhombus:CFigure
    {
        //public bool VihodLineTrue = false; //выходит ли из ромба линия "да"
        //public bool VihodLineFalse = false; //выходит ли из ромба линия "нет"
        public Rhombus()
        {
            Position = new Point(40, 150);
            Id = Guid.NewGuid();
            Height = 60;
            Width = 60;
            TextFigure = "";
            ColorFigure = Color.Black;
        }

        public override void DrFigure(Graphics g)
        {
            len = DrowText(g, Position.X + len.Width / 2, Position.Y + len.Height / 2);

            Width = len.Width > 30 ? 2 * len.Width : 60;
            Height = len.Height > 30 ? 2 * len.Height : 60;

            SerediniStoronMethPoints();

            Pen pen = new Pen(ColorFigure, 2);
            g.DrawPolygon(pen, SerediniStoron);
        }
        public override bool Vhod(int cursorX, int cursorY)
        {
            double chislitel11 = cursorX - SoedineniePoint("left").X;
            double znamenatel11 = SoedineniePoint("top").X - SoedineniePoint("left").X;
            double chislitel12 = cursorY - SoedineniePoint("left").Y;
            double znamenatel12 = SoedineniePoint("top").Y - SoedineniePoint("left").Y;

            double chislitel21 = cursorX - SoedineniePoint("bottom").X;
            double znamenatel21 = SoedineniePoint("right").X - SoedineniePoint("bottom").X;
            double chislitel22 = cursorY - SoedineniePoint("bottom").Y;
            double znamenatel22 = SoedineniePoint("right").Y - SoedineniePoint("bottom").Y;

            double chislitel31 = cursorX - SoedineniePoint("left").X;
            double znamenatel31 = SoedineniePoint("bottom").X - SoedineniePoint("left").X;
            double chislitel32 = cursorY - SoedineniePoint("left").Y;
            double znamenatel32 = SoedineniePoint("bottom").Y - SoedineniePoint("left").Y;

            double chislitel41 = cursorX - SoedineniePoint("top").X;
            double znamenatel41 = SoedineniePoint("right").X - SoedineniePoint("top").X;
            double chislitel42 = cursorY - SoedineniePoint("top").Y;
            double znamenatel42 = SoedineniePoint("right").Y - SoedineniePoint("top").Y;

            if (chislitel11 / znamenatel11 >= chislitel12 / znamenatel12 &&
               chislitel21 / znamenatel21 <= chislitel22 / znamenatel22 &&
               chislitel31 / znamenatel31 >= chislitel32 / znamenatel32 &&
               chislitel41 / znamenatel41 <= chislitel42 / znamenatel42)
            {
                return true;
            }
            return false;
        }
    }
}
