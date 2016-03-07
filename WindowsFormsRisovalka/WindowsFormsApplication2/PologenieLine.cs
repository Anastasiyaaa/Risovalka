using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    static class PologenieLine
    {
        private static int numMin;
        private static double min;
        private static double kvX;
        private static double kvY;
        public static int OptimalPut(CFigure cFigure, Point position)
        {
            kvX = Math.Pow(cFigure.SerediniStoron[0].X - position.X, 2);
            kvY = Math.Pow(cFigure.SerediniStoron[0].Y - position.Y, 2);
            numMin = 0;
            min = kvX + kvY;
            for (int i = 1; i < 4; i++)
            {
                kvX = Math.Pow(cFigure.SerediniStoron[i].X - position.X, 2);
                kvY = Math.Pow(cFigure.SerediniStoron[i].Y - position.Y, 2);
                if (kvX + kvY < min)
                {
                    min = kvX + kvY;
                    numMin = i;
                }
            }
            return numMin;
        }
        public static void PerenosLine(CFigure cFigure)
        {
            PerenosNachalaLine(cFigure);
            PerenosKoncaLine(cFigure);
        }

        #region Перенос начала линии
        private static void PerenosNachalaLine(CFigure cFigure)
        {
            if (cFigure is Rhombus)
            {
                foreach (LineNY lineNY in CCanvas.CLineList.Where(o => o.IdFigureNachalo == cFigure.Id))
                {
                    CFigure figure = CCanvas.CFigureList.Where(o => o.Id == lineNY.IdFigureKonec).FirstOrDefault();
                    if (lineNY.SposobOtrisovki == false)
                    {
                        positionLineThreeDot(cFigure, lineNY, figure);
                    }
                    if (lineNY.SposobOtrisovki == true)
                    {
                        positionLineFourDot(cFigure, lineNY, figure);
                    }
                    if (lineNY.SposobOtrisovki == null)
                    {
                        PerenosNachalaLineNeRhombus(lineNY, cFigure);
                    }
                }
            }
            else
            {
                foreach (Line line in CCanvas.CLineList.Where(o => o.IdFigureNachalo == cFigure.Id))
                {
                   PerenosNachalaLineNeRhombus(line, cFigure);
                }
            }
        }
        private static void PerenosNachalaLineNeRhombus(Line line, CFigure cFigure)
        {
            numMin = OptimalPut(cFigure, line.PositionLineKonec);
            line.PositionLineNachalo = new Point(cFigure.SerediniStoron[numMin].X, cFigure.SerediniStoron[numMin].Y);

            CFigure figure = CCanvas.CFigureList.Where(o => o.Id == line.IdFigureKonec).FirstOrDefault();

            numMin = OptimalPut(figure, line.PositionLineNachalo);
            line.PositionLineKonec = new Point(figure.SerediniStoron[numMin].X, figure.SerediniStoron[numMin].Y);
        }
        #endregion

        private static void positionLineThreeDot(CFigure cFigure, LineNY lineNY, CFigure figure)
        {
            lineNY.PositionLineNachalo =
                            cFigure.SoedineniePoint(cFigure.SoedineniePoint("top").X <= figure.SoedineniePoint("top").X
                                ? "right"
                                : "left");
            lineNY.LineThreePoints();
        }

        public static void positionLineFourDot(CFigure cFigure, LineNY lineNY, CFigure figure)
        {
            if (cFigure.SoedineniePoint("top").X <= figure.SoedineniePoint("top").X)
            {
                lineNY.PositionLineNachalo = cFigure.SoedineniePoint("left");
                lineNY.PositionLineKonec = figure.SoedineniePoint("left");
                lineNY.LineFourPoints(Viravnivanie.MinLeft - 35);
            }
            else
            {
                lineNY.PositionLineNachalo = cFigure.SoedineniePoint("right");
                lineNY.PositionLineKonec = figure.SoedineniePoint("right");
                lineNY.LineFourPoints(Viravnivanie.MaxRight + 35);
            }
        }

        #region Перенос конца линии
        private static void PerenosKoncaLine(CFigure cFigure)
        {
            foreach (LineNY lineNY in CCanvas.CLineList.Where(o => o.IdFigureKonec == cFigure.Id && o is LineNY))
            {
                CFigure figureNachalaLine = CCanvas.CFigureList.Where(o => o.Id == lineNY.IdFigureNachalo).FirstOrDefault();

                if (lineNY.SposobOtrisovki == false)//линия из 3 точек
                {
                    lineNY.PositionLineKonec = cFigure.SoedineniePoint("top");
                    positionLineThreeDot(figureNachalaLine, lineNY,cFigure);
                }
                if (lineNY.SposobOtrisovki == true)
                {
                    positionLineFourDot(figureNachalaLine, lineNY, cFigure);
                }
                if (lineNY.SposobOtrisovki == null)
                {
                    PerenosKoncaLineNeRhombus(lineNY, cFigure);

                }
            }
            foreach (Line line in CCanvas.CLineList.Where(o => o.IdFigureKonec == cFigure.Id && o is LineNY==false))
            {
                PerenosKoncaLineNeRhombus(line, cFigure);
            }
        }
        private static void PerenosKoncaLineNeRhombus(Line line, CFigure cFigure)
        {
            numMin = OptimalPut(cFigure, line.PositionLineNachalo);
            line.PositionLineKonec = new Point(cFigure.SerediniStoron[numMin].X, cFigure.SerediniStoron[numMin].Y);

            CFigure figure = CCanvas.CFigureList.Where(o => o.Id == line.IdFigureNachalo).FirstOrDefault();

            numMin = OptimalPut(figure, line.PositionLineKonec);
            line.PositionLineNachalo = new Point(figure.SerediniStoron[numMin].X, figure.SerediniStoron[numMin].Y);
        }

        #endregion
    }
}
