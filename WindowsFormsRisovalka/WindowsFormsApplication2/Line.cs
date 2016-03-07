using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Line
    {
        public Point PositionLineNachalo;
        public bool Perenos;
        
        public Point PositionLineKonec;
        public bool Otrisovka;
        public Guid IdFigureNachalo;
        public Guid IdFigureKonec;

        
        public Line(int x, int y, Guid idFigure)
        {
            IdFigureNachalo = idFigure;
            PositionLineNachalo = new Point(x, y);
            PositionLineKonec = new Point(x, y);
            Perenos = false;
            Otrisovka = true;
        }
        public virtual void DrLine(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 4);
            pen.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(pen, PositionLineNachalo.X, PositionLineNachalo.Y, PositionLineKonec.X, PositionLineKonec.Y);
        }
    }
}
