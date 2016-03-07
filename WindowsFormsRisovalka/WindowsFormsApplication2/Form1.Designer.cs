using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_square = new System.Windows.Forms.Button();
            this.btn_squarep = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_nachalo = new System.Windows.Forms.Button();
            this.btn_parallelogramm = new System.Windows.Forms.Button();
            this.btn_romb = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rad_LineYes = new System.Windows.Forms.RadioButton();
            this.rad_LineNo = new System.Windows.Forms.RadioButton();
            this.rad_Line = new System.Windows.Forms.RadioButton();
            this.rad_Figure = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(658, 616);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseButton_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownPictureBox);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMovePicterBox);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpPictureBox);
            // 
            // btn_square
            // 
            this.btn_square.Location = new System.Drawing.Point(675, 148);
            this.btn_square.Name = "btn_square";
            this.btn_square.Size = new System.Drawing.Size(104, 23);
            this.btn_square.TabIndex = 1;
            this.btn_square.Text = "Прямоугольник";
            this.btn_square.UseVisualStyleBackColor = true;
            this.btn_square.Click += new System.EventHandler(this.btn_rectangle_Click);
            // 
            // btn_squarep
            // 
            this.btn_squarep.Location = new System.Drawing.Point(675, 177);
            this.btn_squarep.Name = "btn_squarep";
            this.btn_squarep.Size = new System.Drawing.Size(104, 23);
            this.btn_squarep.TabIndex = 2;
            this.btn_squarep.Text = "Пунктир";
            this.btn_squarep.UseVisualStyleBackColor = true;
            this.btn_squarep.Click += new System.EventHandler(this.btn_rectanglePunctir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(675, 379);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(121, 74);
            this.textBox1.TabIndex = 5;
            this.textBox1.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Текст";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(675, 459);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Добавить текст";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnClick_AddText);
            // 
            // btn_nachalo
            // 
            this.btn_nachalo.Location = new System.Drawing.Point(675, 61);
            this.btn_nachalo.Name = "btn_nachalo";
            this.btn_nachalo.Size = new System.Drawing.Size(104, 23);
            this.btn_nachalo.TabIndex = 8;
            this.btn_nachalo.Text = "Начало";
            this.btn_nachalo.UseVisualStyleBackColor = true;
            this.btn_nachalo.Click += new System.EventHandler(this.btn_nachalo_Click);
            // 
            // btn_parallelogramm
            // 
            this.btn_parallelogramm.Location = new System.Drawing.Point(675, 90);
            this.btn_parallelogramm.Name = "btn_parallelogramm";
            this.btn_parallelogramm.Size = new System.Drawing.Size(104, 23);
            this.btn_parallelogramm.TabIndex = 9;
            this.btn_parallelogramm.Text = "Параллелограмм";
            this.btn_parallelogramm.UseVisualStyleBackColor = true;
            this.btn_parallelogramm.Click += new System.EventHandler(this.btn_parallelogramm_Click);
            // 
            // btn_romb
            // 
            this.btn_romb.Location = new System.Drawing.Point(675, 119);
            this.btn_romb.Name = "btn_romb";
            this.btn_romb.Size = new System.Drawing.Size(104, 23);
            this.btn_romb.TabIndex = 10;
            this.btn_romb.Text = "Ромб";
            this.btn_romb.UseVisualStyleBackColor = true;
            this.btn_romb.Click += new System.EventHandler(this.btn_romb_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(675, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Выравнивание";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.viravnivanie_Click);
            // 
            // rad_LineYes
            // 
            this.rad_LineYes.AutoSize = true;
            this.rad_LineYes.Location = new System.Drawing.Point(694, 252);
            this.rad_LineYes.Name = "rad_LineYes";
            this.rad_LineYes.Size = new System.Drawing.Size(85, 17);
            this.rad_LineYes.TabIndex = 12;
            this.rad_LineYes.TabStop = true;
            this.rad_LineYes.Text = "Линия \"Да\"";
            this.rad_LineYes.UseVisualStyleBackColor = true;
            // 
            // rad_LineNo
            // 
            this.rad_LineNo.AutoSize = true;
            this.rad_LineNo.Location = new System.Drawing.Point(694, 275);
            this.rad_LineNo.Name = "rad_LineNo";
            this.rad_LineNo.Size = new System.Drawing.Size(89, 17);
            this.rad_LineNo.TabIndex = 13;
            this.rad_LineNo.TabStop = true;
            this.rad_LineNo.Text = "Линия \"Нет\"";
            this.rad_LineNo.UseVisualStyleBackColor = true;
            // 
            // rad_Line
            // 
            this.rad_Line.AutoSize = true;
            this.rad_Line.Location = new System.Drawing.Point(694, 229);
            this.rad_Line.Name = "rad_Line";
            this.rad_Line.Size = new System.Drawing.Size(57, 17);
            this.rad_Line.TabIndex = 14;
            this.rad_Line.TabStop = true;
            this.rad_Line.Text = "Линия";
            this.rad_Line.UseVisualStyleBackColor = true;
            // 
            // rad_Figure
            // 
            this.rad_Figure.AutoSize = true;
            this.rad_Figure.Location = new System.Drawing.Point(694, 206);
            this.rad_Figure.Name = "rad_Figure";
            this.rad_Figure.Size = new System.Drawing.Size(64, 17);
            this.rad_Figure.TabIndex = 15;
            this.rad_Figure.TabStop = true;
            this.rad_Figure.Text = "Фигура";
            this.rad_Figure.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 640);
            this.Controls.Add(this.rad_Figure);
            this.Controls.Add(this.rad_Line);
            this.Controls.Add(this.rad_LineNo);
            this.Controls.Add(this.rad_LineYes);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_romb);
            this.Controls.Add(this.btn_parallelogramm);
            this.Controls.Add(this.btn_nachalo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_squarep);
            this.Controls.Add(this.btn_square);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Рисовалка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_square;
        private System.Windows.Forms.Button btn_squarep;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_nachalo;
        private System.Windows.Forms.Button btn_parallelogramm;
        private System.Windows.Forms.Button btn_romb;
        private Button button3;
        private RadioButton rad_LineYes;
        private RadioButton rad_LineNo;
        private RadioButton rad_Line;
        private RadioButton rad_Figure;

    }
}

