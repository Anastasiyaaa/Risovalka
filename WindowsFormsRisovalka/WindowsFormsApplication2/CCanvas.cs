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
        public List<CFigure> CFigureList=new List<CFigure>();
        double min;
        double kvX;
        double kvY;
        int numMin;
        public void Add(CFigure figure)
        {
            CFigureList.Add(figure);
        }
        
        #region Прорисовка линии

        public int OptimalPut(CFigure cFigure, Point position)
        {
            kvX = Math.Pow(cFigure.ArrayPoints()[0].X - position.X, 2);
            kvY = Math.Pow(cFigure.ArrayPoints()[0].Y - position.Y, 2);
            numMin = 0;
            min = kvX + kvY;
            for (int i = 1; i < 4; i++)
            {
                kvX = Math.Pow(cFigure.ArrayPoints()[i].X - position.X, 2);
                kvY = Math.Pow(cFigure.ArrayPoints()[i].Y - position.Y, 2);
                if (kvX + kvY < min)
                {
                    min = kvX + kvY;
                    numMin = i;
                }
            }
            return numMin;
        }
        public void DragMoveLine(int Xl, int Yl)
        {
            Line[] arrayLines = CFigureList.Where(o => o is Line).Cast<Line>().ToArray();
            Line line = arrayLines.Where(o => o.Otrisovka).FirstOrDefault();
            if (line != null)
            {
                line.PositionLine = new Point(Xl, Yl);

                CFigure cFigure = CFigureList.Where(o => o.OtrisovkaLine).FirstOrDefault();

                numMin = OptimalPut(cFigure, line.PositionLine);
                line.Position = new Point(cFigure.ArrayPoints()[numMin].X, cFigure.ArrayPoints()[numMin].Y);
            }
        }

        public void DragMouseUpLine(int Xl, int Yl)
        {
            CFigure cFigure = CFigureList.Where(o => o.Vhod(Xl, Yl)).FirstOrDefault();
            Line[] arraLines = CFigureList.Where(o => o is Line).Cast<Line>().ToArray();
            Line line = arraLines.Where(o => o.Otrisovka).FirstOrDefault();
            if (cFigure != null && line != null)
            {
                numMin = OptimalPut(cFigure, line.Position);
                line.PositionLine = new Point(cFigure.ArrayPoints()[numMin].X, cFigure.ArrayPoints()[numMin].Y);
                line.Otrisovka = false;
            }
            else
            {
                CFigureList.Remove(line);
            }
            cFigure = CFigureList.Where(o => o.OtrisovkaLine).FirstOrDefault();
            if (cFigure != null)
            {
                cFigure.OtrisovkaLine = false;    
            }
        }

        #endregion

        #region Перенос фигур
        public void DragStart(int X, int Y)
        {
            foreach (CFigure cFigure in CFigureList.Where(o => o.Vhod(X, Y)))
            {
                cFigure.Perenos = true;
                cFigure.Delta = new Point(X - cFigure.Position.X, Y - cFigure.Position.Y);
            }
        }
        public void DragMove(int X, int Y)
        {
            CFigure cFigure = CFigureList.Where(o => o.Perenos).FirstOrDefault();
            
            Line[] lines = CFigureList.Where(o => o is Line).Cast<Line>().ToArray();
            foreach (Line line in lines)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (line.PositionLine == cFigure.ArrayPoints()[i])
                    {
                        line.KvKonec = true;
                    }
                    if (line.Position == cFigure.ArrayPoints()[i])
                    {
                        line.KvNachalo = true;
                    }
                }
            }
            cFigure.Position = new Point(X - cFigure.Delta.X, Y - cFigure.Delta.Y);
            foreach (Line line in lines.Where(o=>o.KvNachalo))
            {
                numMin = OptimalPut(cFigure, line.PositionLine);
                line.Position = new Point(cFigure.ArrayPoints()[numMin].X, cFigure.ArrayPoints()[numMin].Y);
                foreach (CFigure neLine in CFigureList.Where(o=>o is Line==false))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (neLine.ArrayPoints()[i]==line.PositionLine) 
                        {
                            numMin = OptimalPut(neLine, line.Position);
                            line.PositionLine = new Point(neLine.ArrayPoints()[numMin].X, neLine.ArrayPoints()[numMin].Y);
                            break;
                        }
                    }
                }
            }
            foreach (Line line in lines.Where(o => o.KvKonec))
            {
                numMin = OptimalPut(cFigure, line.Position);
                line.PositionLine = new Point(cFigure.ArrayPoints()[numMin].X, cFigure.ArrayPoints()[numMin].Y);
                foreach (CFigure neLine in CFigureList.Where(o => o is Line == false))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (neLine.ArrayPoints()[i] == line.Position)
                        {
                            numMin = OptimalPut(neLine, line.PositionLine);
                            line.Position = new Point(neLine.ArrayPoints()[numMin].X, neLine.ArrayPoints()[numMin].Y);
                            break;
                        }
                    }
                }
            }
        }
        
        public void DragStop(int X, int Y)
        {
            foreach (CFigure cFigure in CFigureList.Where(o => o.Perenos))
            {
                cFigure.Perenos = false;
            }
            Line[] lines = CFigureList.Where(o => o is Line).Cast<Line>().ToArray();
            foreach (Line line in lines)
            {
                line.KvKonec = false;
                line.KvNachalo = false;
            }
        }
        #endregion
    }
}
