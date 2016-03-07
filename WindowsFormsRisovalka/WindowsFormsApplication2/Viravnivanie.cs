using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    static class Viravnivanie
    {
        private static int minLeft;
        private static int maxRight;

        private static List<CFigure> cfigureList;
        private static List<CFigure> cnewfigureList;
        private static CFigure newCFigure;

        #region Св-ва max,min
        public static int MinLeft
        {
            get { return minLeft; }
            private set
            {
                int left = value;
                if (minLeft > left)
                    minLeft = left;
            }
        }
        public static int MaxRight
        {
            get { return maxRight; }
            private set
            {
                int right = value;
                if (maxRight < right)
                    maxRight = right;
            }
        }
        #endregion

        public static void ViravnivanieMethod()
        {
            cfigureList = new List<CFigure>();
            cnewfigureList = new List<CFigure>();
            minLeft = 658;
            maxRight = 0;

            firstFigure();
            do
            {
                foreach (CFigure cfigure in cfigureList)
                {
                    if (cfigure is Rhombus)
                    {
                        foreach (LineNY lineNY in CCanvas.CLineList.Where(o => o is LineNY && o.IdFigureNachalo == cfigure.Id))
                        {
                            figurePosleRhombus(lineNY, cfigure);
                            maxMinX();
                        }
                    }
                    else
                    {
                        Line line = CCanvas.CLineList.Where(o => o.IdFigureNachalo == cfigure.Id).FirstOrDefault();
                        if (line != null)
                        {
                            figurePosleNeRhombus(cfigure, line);
                        }
                    }
                }
                cfigureList.Clear();
                cfigureList.AddRange(cnewfigureList);
                cnewfigureList.Clear();
            } while (cfigureList.Count != 0 && cfigureList != null);

            endViravnivanie();
        }

        private static void figurePosleNeRhombus(CFigure cfigure, Line line)
        {
            newCFigure = CCanvas.CFigureList.Where(o => o.Id == line.IdFigureKonec).FirstOrDefault();
            newCFigure.Position = new Point(cfigure.SerediniStoron[2].X - newCFigure.Width / 2,
                cfigure.Position.Y + cfigure.Height + 20);
            newCFigure.Perenos = true;
            newCFigure.SerediniStoronMethPoints();

            maxMinX();

            PologenieLine.PerenosLine(newCFigure);
            cnewfigureList.Add(newCFigure);
        }
        private static void endViravnivanie()
        {
            foreach (CFigure figure in CCanvas.CFigureList)
            {
                figure.Perenos = false;
                figure.VihodLineRight = false;
                figure.VihodLineLeft = false;
            }
        }
        private static void firstFigure()
        {
            CFigure cFigure = CCanvas.CFigureList.Where(o => o is Circle).FirstOrDefault();
            if (cFigure != null)
            {
                cFigure.Position = new Point(329, 10);
                cFigure.SerediniStoronMethPoints();

                cfigureList.Add(cFigure);
                PologenieLine.PerenosLine(cFigure);
            }
        }

        private static void maxMinX()
        {
            MinLeft = newCFigure.Position.X;
            MaxRight = newCFigure.Position.X + newCFigure.Width;
        }
        private static void figurePosleRhombus(LineNY lineNY, CFigure cfigure)
        {
            newCFigure = CCanvas.CFigureList.Where(o => o.Id == lineNY.IdFigureKonec).FirstOrDefault();
            //линия из 3 точек
            if (newCFigure.Perenos == false)
            {
                figurePosleRhombusBezPerenosa(lineNY, cfigure);
                cnewfigureList.Add(newCFigure);
            }
            //линия из 4 точек
            else
            {
                PologenieLine.positionLineFourDot(cfigure, lineNY, newCFigure);
            }
        }
        private static void figurePosleRhombusBezPerenosa(LineNY lineNY, CFigure cfigure)
        {
            //329-центр по X
            if (cfigure.SoedineniePoint("top").X >= 329 && cfigure.VihodLineLeft ==false ||
                cfigure.SoedineniePoint("top").X <= 329 && cfigure.VihodLineRight == true)
            {
                newCFigure.Position = new Point(cfigure.Position.X - newCFigure.Width - 40,
                    cfigure.Position.Y + cfigure.Height + 20);
                cfigure.VihodLineLeft = true;
                lineNY.PositionLineNachalo = cfigure.SoedineniePoint("left");
            }
            else
            {
                newCFigure.Position = new Point(cfigure.Position.X + cfigure.Width + 40,
                    cfigure.Position.Y + cfigure.Height + 20);
                cfigure.VihodLineRight = true;
                lineNY.PositionLineNachalo = cfigure.SoedineniePoint("right");
            }
            lineNY.PositionLineKonec = newCFigure.SoedineniePoint("top");
            lineNY.LineThreePoints();
            lineNY.SposobOtrisovki = false;

            newCFigure.Perenos = true;
            newCFigure.SerediniStoronMethPoints();
        }
    }
}
