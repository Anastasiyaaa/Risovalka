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
            if (Convert.ToDouble((cursorX - SerediniStoron[3].X))/(SerediniStoron[0].X - SerediniStoron[3].X) >=
                Convert.ToDouble((cursorY - SerediniStoron[3].Y))/(SerediniStoron[0].Y - SerediniStoron[3].Y) &&
                Convert.ToDouble((cursorX - SerediniStoron[2].X))/(SerediniStoron[1].X - SerediniStoron[2].X) <=
                Convert.ToDouble((cursorY - SerediniStoron[2].Y))/(SerediniStoron[1].Y - SerediniStoron[2].Y) &&
                Convert.ToDouble((cursorX - SerediniStoron[3].X))/(SerediniStoron[2].X - SerediniStoron[3].X) >=
                Convert.ToDouble((cursorY - SerediniStoron[3].Y))/(SerediniStoron[2].Y - SerediniStoron[3].Y) &&
                Convert.ToDouble((cursorX - SerediniStoron[0].X))/(SerediniStoron[1].X - SerediniStoron[0].X) <=
                Convert.ToDouble((cursorY - SerediniStoron[0].Y))/(SerediniStoron[1].Y - SerediniStoron[0].Y))
            {
                return true;
            }
            return false;
        }
    }
}
