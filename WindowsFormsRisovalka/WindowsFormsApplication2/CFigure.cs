using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public abstract class CFigure
    {
        public Point Position;
        public int Height;
        public int Width;
        public bool Perenos;
        public Point Delta;
        public Color ColorFigure;
        public Guid Id;
        public Point[] SerediniStoron;
        public Point SeredinaStoroni;

        public bool VihodLineRight = false;//есть ли линия
        public bool VihodLineLeft = false;

        public string TextFigure;
        protected Size len;

        #region Абстрактные методы
        public abstract void DrFigure(Graphics g);
        public abstract bool Vhod(int cursorX, int cursorY);
        #endregion

        public virtual void SerediniStoronMethPoints()
        {
            SerediniStoron = new Point[4];
            SerediniStoron[0] = new Point(Position.X + Width / 2, Position.Y);
            SerediniStoron[1] = new Point(Position.X + Width, Position.Y + Height / 2);
            SerediniStoron[2] = new Point(Position.X + Width / 2, Position.Y + Height);
            SerediniStoron[3] = new Point(Position.X, Position.Y + Height / 2);
        }
        public Point SoedineniePoint(string storona)
        {
            switch (storona)
            {
                case "top": //верх
                    SeredinaStoroni = new Point(Position.X + Width / 2, Position.Y);
                    break;
                case "right": //право
                    SeredinaStoroni= new Point(Position.X + Width, Position.Y + Height / 2);
                    break;
                case "bottom": //низ
                    SeredinaStoroni = new Point(Position.X + Width / 2, Position.Y + Height);
                    break;
                case "left": //лево
                    SeredinaStoroni = new Point(Position.X, Position.Y + Height / 2);
                    break;
            }
            return SeredinaStoroni;
        }

        public Size DrowText(Graphics g, int x, int y)
        {
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Times New Roman", 12, FontStyle.Regular);

            // Координаты размещения текста 
            g.DrawString(TextFigure, font, brush, x, y); 
            len = TextRenderer.MeasureText(TextFigure, font);
            return len;
        }
        
    }
}
