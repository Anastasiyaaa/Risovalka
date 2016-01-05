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
        Rectangle rect;
        bool flag;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.AllowDrop = true;

            pCanvas = new CCanvas();
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            rect = new Rectangle();
            rect.Position =new Point(20,20);
            rect.Height = 50;
            rect.Width = 60;
            rect.OtrisovkaLine = false;

            pCanvas.Add(rect);

            ReDrow();
        }

        public void ReDrow()
        {
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            foreach (CFigure pF in pCanvas.CFigureList)
            {
                   pF.DrRectangle(g);
                
            }
            pictureBox1.Image = bmp;
        }

        private void btn_rectanglePunctir_Click(object sender, EventArgs e)
        {
            RectanglePunctir rect = new RectanglePunctir();
            rect.Position = new Point(200, 20);
            rect.Height = 50;
            rect.Width = 60;
            rect.OtrisovkaLine = false;

            pCanvas.Add(rect);

            ReDrow();
        }

        private void MauseDownPictureBox(object sender, MouseEventArgs e)
        {
            if (ch_Line.Checked)
            {
                CFigure cFigure = pCanvas.CFigureList.Where(o => o.Vhod(e.X, e.Y)).FirstOrDefault();
                if (cFigure != null)
                {
                    cFigure.OtrisovkaLine = true;

                    Line line = new Line();
                    line.Position = new Point(e.X, e.Y);
                    line.PositionLine = new Point(e.X, e.Y);
                    line.Perenos = false;
                    line.Otrisovka = true;
                    pCanvas.Add(line);    
                }
            }
            else
            {
                pCanvas.DragStart(e.X, e.Y);
            }
            flag = true;
            ReDrow();
        }

        private void MauseUpPictureBox(object sender, MouseEventArgs e)
        {
            flag = false;
            if (ch_Line.Checked)
            {
                pCanvas.DragMouseUpLine(e.X, e.Y);
                
            }
            else
            {
                pCanvas.DragStop(e.X, e.Y);    
            }
            ReDrow();    
        }

        private void MouseMovePicterBox(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                if (ch_Line.Checked)
                {
                    pCanvas.DragMoveLine(e.X, e.Y);
                    pictureBox1.Cursor = Cursors.Hand;
                }
                else
                {
                    pCanvas.DragMove(e.X, e.Y);
                    pictureBox1.Cursor = Cursors.SizeAll;
                }
                ReDrow();
            }
            else
            {
                CFigure cFigure = pCanvas.CFigureList.FirstOrDefault(o => o.Vhod(e.X, e.Y));
                if (cFigure != null)
                {
                    if (ch_Line.Checked)
                    {
                        pictureBox1.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        pictureBox1.Cursor = Cursors.SizeAll;
                    }
                }
                else
                {
                    pictureBox1.Cursor = Cursors.Arrow;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pCanvas = new CCanvas();
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
            ch_Line.Checked = false;
        }

    }
}
