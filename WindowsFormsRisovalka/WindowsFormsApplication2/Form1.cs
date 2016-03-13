using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        CCanvas pCanvas;
        Graphics g;
        bool flag;

        public Form1()
        {
            InitializeComponent();
            ochistka();
        }

        //Скрыть элементы для ввода текста
        private void skritT()
        {
            textBox1.Visible = false;
            label1.Visible = false;
            button2.Visible = false;
        }
        //Показать элементы для ввода текста
        private void pokazatT()
        {
            textBox1.Visible = true;
            label1.Visible = true;
            button2.Visible = true;
        }
        private void ochistka()
        {
            pCanvas = new CCanvas();
            CCanvas.CFigureList.Clear();
            CCanvas.CLineList.Clear();
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
            rad_Figure.Checked = true;

            skritT();
        }

        public void ReDrow()
        {
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            pereborFigureRedrow();
            pereborLineRedrow();

            pictureBox1.Image = bmp;
        }

        private void pereborFigureRedrow()
        {
            foreach (CFigure pF in CCanvas.CFigureList)
            {
                pF.DrFigure(g);
            } 
        }
        private void pereborLineRedrow()
        {
            foreach (Line pL in CCanvas.CLineList)
            {
                pL.DrLine(g);
            }
        }
        
        private void MouseDownPictureBox(object sender, MouseEventArgs e)
        {
            CFigure cFigure = CCanvas.CFigureList.Where(o => o.Vhod(e.X, e.Y)).FirstOrDefault();
            if (cFigure != null)
            {
                ifRadLineChecked(cFigure, e);
                ifRadLineNoChecked(cFigure, e);
                ifRadLineYesChecked(cFigure, e);
                ifRadFigureChecked(cFigure, e);

                ReDrow();
            }
        }

        #region для MouseDownPictureBox
        private void ifRadLineChecked(CFigure cFigure, MouseEventArgs e)
        {
            if (rad_Line.Checked && cFigure is Rhombus == false)
            {
                Line line = new Line(e.X, e.Y, cFigure.Id);
                pCanvas.Add(line);

                flag = true;
            }
        }
        private void ifRadLineNoChecked(CFigure cFigure, MouseEventArgs e)
        {
            if (rad_LineNo.Checked && cFigure is Rhombus)
            {
                LineNY lineny = new LineNY(e.X, e.Y, cFigure.Id);
                lineny.TextLine = "нет";
                pCanvas.Add(lineny);

                flag = true;
            }
        }
        private void ifRadLineYesChecked(CFigure cFigure, MouseEventArgs e)
        {
            if (rad_LineYes.Checked && cFigure is Rhombus)
            {
                LineNY lineny = new LineNY(e.X, e.Y, cFigure.Id);
                lineny.TextLine = "да";
                pCanvas.Add(lineny);

                flag = true;
            }
        }
        private void ifRadFigureChecked(CFigure cFigure, MouseEventArgs e)
        {
            if (rad_Figure.Checked)
            {
                pCanvas.DragStart(e.X, e.Y, cFigure);
                flag = true;
            }
        }
        #endregion

        private void MouseMovePicterBox(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                perenosFigureOrLine(e);
            }
            else
            {
                naveliNaFigureOrNet(e);
            }
        }

        private void perenosFigureOrLine(MouseEventArgs e)
        {
            if (!rad_Figure.Checked)
            {// рисование линии
                pCanvas.DragMoveLine(e.X, e.Y);
                pictureBox1.Cursor = Cursors.Hand;
            }
            else
            {//перенос фигуры
                pCanvas.DragMove(e.X, e.Y);
                pictureBox1.Cursor = Cursors.SizeAll;
            }
            ReDrow();
        }

        private void naveliNaFigureOrNet(MouseEventArgs e)
        {
            CFigure cFigure = CCanvas.CFigureList.FirstOrDefault(o => o.Vhod(e.X, e.Y));
            if (cFigure != null)
            {
                vidCursoraPriNavedenii(cFigure);
            }
            else
            {
                pictureBox1.Cursor = Cursors.Arrow;
            }
        }

        private void vidCursoraPriNavedenii(CFigure cFigure)
        {
            if (rad_Line.Checked && cFigure is Rhombus == false ||
                    (rad_LineNo.Checked || rad_LineYes.Checked) && cFigure is Rhombus)
            {
                pictureBox1.Cursor = Cursors.Hand;
            }
            if (rad_Figure.Checked)
            {
                pictureBox1.Cursor = Cursors.SizeAll;
            }
        }
 
        private void MouseUpPictureBox(object sender, MouseEventArgs e)
        {
            flag = false;
            if (!rad_Figure.Checked)
            {
                pCanvas.DragMouseUpLine(e.X, e.Y);
            }
            else
            {
                pCanvas.DragStop(e.X, e.Y);    
            }
            ReDrow();    
        }

        
       
        private void btnClear_Click(object sender, EventArgs e)
        {
            ochistka();
        }

        private void MouseButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CFigure cFigure = CCanvas.CFigureList.Where(o => o.Vhod(e.X, e.Y)).FirstOrDefault();
                if (cFigure != null)
                {
                    pokazatT();
                    textBox1.Text = cFigure.TextFigure;
                    cFigure.ColorFigure = Color.Blue;
                    ReDrow();
                }
            }
        }

        private void btnClick_AddText(object sender, EventArgs e)
        {
            CFigure cFigure = CCanvas.CFigureList.Where(o => o.ColorFigure==Color.Blue).FirstOrDefault();
            if (cFigure != null)
            {
                cFigure.ColorFigure = Color.Black;
                cFigure.TextFigure = textBox1.Text;
                textBox1.Text = "";
                ReDrow();

                PologenieLine.PerenosLine(cFigure);
                ReDrow();

                skritT();
            }
        }

        private void btn_nachalo_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle();
            pCanvas.Add(circle); 

            ReDrow();
        }
        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle();
            pCanvas.Add(rect);

            ReDrow();
        }
        private void btn_rectanglePunctir_Click(object sender, EventArgs e)
        {
            RectanglePunctir rect = new RectanglePunctir();
            pCanvas.Add(rect);

            ReDrow();
        }

        private void btn_romb_Click(object sender, EventArgs e)
        {
            Rhombus rhombus = new Rhombus();
            pCanvas.Add(rhombus);

            ReDrow();
        }

        private void btn_parallelogramm_Click(object sender, EventArgs e)
        {
            Parallelogramm parallelogramm = new Parallelogramm();
            pCanvas.Add(parallelogramm);

            ReDrow();
        }

        private void viravnivanie_Click(object sender, EventArgs e)
        {
            Viravnivanie.ViravnivanieMethod();
            ReDrow();
        }

    }
}
