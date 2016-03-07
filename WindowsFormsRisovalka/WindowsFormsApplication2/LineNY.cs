using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class LineNY:Line
    {
        public string TextLine;

        private int deltaX;
        private int deltaY;
        private Point[] linePoints;
        public bool? SposobOtrisovki; //false-линия из 3точек; true-из 4 точек; из 2 точек

        public LineNY(int x, int y, Guid idFigure):base(x,y,idFigure)
        {
        }

        public void LineTwoPoints()
        {
            linePoints = new Point[2];
            linePoints[0] = new Point(PositionLineNachalo.X, PositionLineNachalo.Y);
            linePoints[1] = new Point(PositionLineKonec.X, PositionLineKonec.Y);
            SposobOtrisovki = null;
            delta(PositionLineNachalo.X, PositionLineKonec.X);
        }
        public void LineThreePoints()
        {
            linePoints = new Point[3];
            linePoints[0] = new Point(PositionLineNachalo.X, PositionLineNachalo.Y);
            linePoints[1] = new Point(PositionLineKonec.X, PositionLineNachalo.Y);
            linePoints[2] = new Point(PositionLineKonec.X, PositionLineKonec.Y);
            SposobOtrisovki = false;
            delta(PositionLineNachalo.X, PositionLineKonec.X);
        }
        // передаем в х максимальную левую\правую координату
        public void LineFourPoints(int x)
        {
            linePoints = new Point[4];
            linePoints[0] = new Point(PositionLineNachalo.X, PositionLineNachalo.Y);
            linePoints[1] = new Point(x, PositionLineNachalo.Y);
            linePoints[2] = new Point(x, PositionLineKonec.Y);
            linePoints[3] = new Point(PositionLineKonec.X, PositionLineKonec.Y);
            SposobOtrisovki = true;
            delta(PositionLineNachalo.X, x);
        }
        private void delta(int x1, int x2)
        {
            if (x1 < x2)
            {
                deltaX = 5;
                deltaY = -20;
            }
            else
            {
                deltaX = -30;
                deltaY = -20;
            }
        }

        public override void DrLine(Graphics g)
        {
            //delta();
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Times New Roman", 12, FontStyle.Regular);

            g.DrawString(TextLine, font, brush, PositionLineNachalo.X + deltaX, PositionLineNachalo.Y + deltaY);

            if (linePoints == null || linePoints.Length == 2)
                LineTwoPoints();

            Pen pen = new Pen(Color.Black, 4);
            pen.EndCap = LineCap.ArrowAnchor;
            g.DrawLines(pen, linePoints);
        }
    }
}
