using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class CCanvas
    {
        public static List<CFigure> CFigureList=new List<CFigure>();
        public static List<Line> CLineList=new List<Line>(); 
        private int numMin;

        public void Add(CFigure figure)
        {
            CFigureList.Add(figure);
        }
        public void Add(Line line)
        {
            CLineList.Add(line);
        }

        #region Перенос линии
        public void DragMoveLine(int Xl, int Yl)
        {
            Line line = CLineList.Where(o => o.Otrisovka).FirstOrDefault();
            if (line != null)
            {
                CFigure cFigure = CFigureList.Where(o => o.Id == line.IdFigureNachalo).FirstOrDefault();
                line.PositionLineKonec = new Point(Xl, Yl);
                
                numMin = PologenieLine.OptimalPut(cFigure, line.PositionLineKonec);
                line.PositionLineNachalo = new Point(cFigure.SerediniStoron[numMin].X, cFigure.SerediniStoron[numMin].Y);
            }
        }
        public void DragMouseUpLine(int Xl, int Yl)
        {
            CFigure cFigure = CFigureList.Where(o => o.Vhod(Xl, Yl)).FirstOrDefault();

            Line line = CLineList.Where(o => o.Otrisovka).FirstOrDefault();
            if (cFigure != null && line != null && line.PositionLineNachalo != line.PositionLineKonec)
            {
                numMin = PologenieLine.OptimalPut(cFigure, line.PositionLineNachalo);
                line.PositionLineKonec = new Point(cFigure.SerediniStoron[numMin].X, cFigure.SerediniStoron[numMin].Y);
                line.IdFigureKonec = cFigure.Id;

                line.Otrisovka = false;
            }
            else
            {
                CLineList.Remove(line);
            }
        }
        #endregion

        #region Перенос фигур
        public void DragStart(int X, int Y, CFigure cFigure)
        {
            cFigure.Perenos = true;
            cFigure.Delta = new Point(X - cFigure.Position.X, Y - cFigure.Position.Y);
        }
        public void DragMove(int X, int Y)
        {
            CFigure cFigure = CFigureList.Where(o => o.Perenos).FirstOrDefault();
            
            if (cFigure != null && CLineList != null)
            {
                cFigure.Position = new Point(X - cFigure.Delta.X, Y - cFigure.Delta.Y);
                PologenieLine.PerenosLine(cFigure);
            }
        }
        
        public void DragStop(int X, int Y)
        {
            foreach (CFigure cFigure in CFigureList.Where(o => o.Perenos))
            {
                cFigure.Perenos = false;
            }
        }
        #endregion
    }
}
