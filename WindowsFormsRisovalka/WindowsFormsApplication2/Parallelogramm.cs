using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class Parallelogramm:CFigure
    {
        public Point[] UgliParallelogrammaPoints;

        public Parallelogramm()
        {
            Position = new Point(40, 220);
            Id = Guid.NewGuid();
            Height = 60;
            Width = 40;
            TextFigure = "";
            ColorFigure = Color.Black;
        }
        public override void SerediniStoronMethPoints()
        {
            SerediniStoron = new Point[4];
            SerediniStoron[0] = new Point(Position.X + Width / 2, Position.Y);
            SerediniStoron[1] = new Point(Position.X + Width - 5, Position.Y + Height/2);
            SerediniStoron[2] = new Point(Position.X + Width / 2, Position.Y + Height);
            SerediniStoron[3] = new Point(Position.X + 5, Position.Y + Height/2);
        }

        private void UgliParallelogramma()
        {
            UgliParallelogrammaPoints = new Point[4];
            UgliParallelogrammaPoints[0] = new Point(Position.X + 10, Position.Y);
            UgliParallelogrammaPoints[1] = new Point(Position.X + Width, Position.Y);
            UgliParallelogrammaPoints[2] = new Point(Position.X + Width - 10, Position.Y + Height);
            UgliParallelogrammaPoints[3] = new Point(Position.X, Position.Y + Height);
        }

        public override void DrFigure(Graphics g)
        {
            len = DrowText(g, Position.X + 10, Position.Y);
            Width = len.Width > 40 ? len.Width + 20 : 60;
            Height = len.Height > 40 ? len.Height : 40;

            SerediniStoronMethPoints();
            UgliParallelogramma();

            Pen pen = new Pen(ColorFigure, 2);
            g.DrawPolygon(pen, UgliParallelogrammaPoints);
        }
        public override bool Vhod(int cursorX, int cursorY)
        {
            double znachenie1 = Convert.ToDouble(cursorX - Position.X) / 10;
            double znachenie2 = Convert.ToDouble(cursorY - (Position.Y + Height))/-Height;
            double znachenie3 = Convert.ToDouble(cursorX - (Position.X + Width - 10))/10;
            double znachenie4 = Convert.ToDouble(cursorY - (Position.Y + Height))/
                                (Position.Y - (Position.Y + Height));
            
            if (znachenie1 >= znachenie2 && 
                znachenie3 <= znachenie4 &&
                cursorY >= Position.Y &&
                cursorY <= Position.Y + Height)
            {
                return true;
            }
            return false;
        }
    }
}
