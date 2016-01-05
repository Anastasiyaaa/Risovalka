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
            this.ch_Line = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(671, 457);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MauseDownPictureBox);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMovePicterBox);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MauseUpPictureBox);
            // 
            // btn_square
            // 
            this.btn_square.Location = new System.Drawing.Point(690, 34);
            this.btn_square.Name = "btn_square";
            this.btn_square.Size = new System.Drawing.Size(105, 23);
            this.btn_square.TabIndex = 1;
            this.btn_square.Text = "Прямоугольник";
            this.btn_square.UseVisualStyleBackColor = true;
            this.btn_square.Click += new System.EventHandler(this.btn_rectangle_Click);
            // 
            // btn_squarep
            // 
            this.btn_squarep.Location = new System.Drawing.Point(690, 63);
            this.btn_squarep.Name = "btn_squarep";
            this.btn_squarep.Size = new System.Drawing.Size(75, 23);
            this.btn_squarep.TabIndex = 2;
            this.btn_squarep.Text = "Пунктир";
            this.btn_squarep.UseVisualStyleBackColor = true;
            this.btn_squarep.Click += new System.EventHandler(this.btn_rectanglePunctir_Click);
            // 
            // ch_Line
            // 
            this.ch_Line.AutoSize = true;
            this.ch_Line.Location = new System.Drawing.Point(694, 106);
            this.ch_Line.Name = "ch_Line";
            this.ch_Line.Size = new System.Drawing.Size(58, 17);
            this.ch_Line.TabIndex = 3;
            this.ch_Line.Text = "Линия";
            this.ch_Line.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 481);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ch_Line);
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
        private System.Windows.Forms.CheckBox ch_Line;
        private System.Windows.Forms.Button button1;

    }
}

