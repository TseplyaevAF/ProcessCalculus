
namespace Звезда_Дюрера
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Draw = new System.Windows.Forms.Button();
            this.textBox_Angle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Radius = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_SetAngle = new System.Windows.Forms.Button();
            this.button_SetRadius = new System.Windows.Forms.Button();
            this.label_Angle = new System.Windows.Forms.Label();
            this.label_Radius = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(648, 435);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_Draw
            // 
            this.button_Draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Draw.Location = new System.Drawing.Point(522, 482);
            this.button_Draw.Name = "button_Draw";
            this.button_Draw.Size = new System.Drawing.Size(120, 38);
            this.button_Draw.TabIndex = 1;
            this.button_Draw.Text = "Нарисовать";
            this.button_Draw.UseVisualStyleBackColor = true;
            this.button_Draw.Click += new System.EventHandler(this.button_Draw_Click);
            // 
            // textBox1
            // 
            this.textBox_Angle.Location = new System.Drawing.Point(94, 466);
            this.textBox_Angle.Name = "textBox1";
            this.textBox_Angle.Size = new System.Drawing.Size(100, 20);
            this.textBox_Angle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Угол поворота:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Радиус:";
            // 
            // textBox_Radius
            // 
            this.textBox_Radius.Location = new System.Drawing.Point(94, 492);
            this.textBox_Radius.Name = "textBox_Radius";
            this.textBox_Radius.Size = new System.Drawing.Size(100, 20);
            this.textBox_Radius.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Параметры фрактала:";
            // 
            // button_SetAngle
            // 
            this.button_SetAngle.Location = new System.Drawing.Point(200, 464);
            this.button_SetAngle.Name = "button_SetAngle";
            this.button_SetAngle.Size = new System.Drawing.Size(75, 23);
            this.button_SetAngle.TabIndex = 11;
            this.button_SetAngle.Text = "Задать";
            this.button_SetAngle.UseVisualStyleBackColor = true;
            this.button_SetAngle.Click += new System.EventHandler(this.button_SetAngle_Click);
            // 
            // button_SetRadius
            // 
            this.button_SetRadius.Location = new System.Drawing.Point(200, 490);
            this.button_SetRadius.Name = "button_SetRadius";
            this.button_SetRadius.Size = new System.Drawing.Size(75, 23);
            this.button_SetRadius.TabIndex = 12;
            this.button_SetRadius.Text = "Задать";
            this.button_SetRadius.UseVisualStyleBackColor = true;
            this.button_SetRadius.Click += new System.EventHandler(this.button_SetRadius_Click);
            // 
            // label_Angle
            // 
            this.label_Angle.AutoSize = true;
            this.label_Angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Angle.Location = new System.Drawing.Point(519, 439);
            this.label_Angle.Name = "label_Angle";
            this.label_Angle.Size = new System.Drawing.Size(45, 16);
            this.label_Angle.TabIndex = 13;
            this.label_Angle.Text = "Угол: ";
            // 
            // label_Radius
            // 
            this.label_Radius.AutoSize = true;
            this.label_Radius.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Radius.Location = new System.Drawing.Point(519, 458);
            this.label_Radius.Name = "label_Radius";
            this.label_Radius.Size = new System.Drawing.Size(62, 16);
            this.label_Radius.TabIndex = 14;
            this.label_Radius.Text = "Радиус: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 528);
            this.Controls.Add(this.label_Radius);
            this.Controls.Add(this.label_Angle);
            this.Controls.Add(this.button_SetRadius);
            this.Controls.Add(this.button_SetAngle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Radius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Angle);
            this.Controls.Add(this.button_Draw);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Звезда Дюрера";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Draw;
        private System.Windows.Forms.TextBox textBox_Angle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Radius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_SetAngle;
        private System.Windows.Forms.Button button_SetRadius;
        private System.Windows.Forms.Label label_Angle;
        private System.Windows.Forms.Label label_Radius;
    }
}

