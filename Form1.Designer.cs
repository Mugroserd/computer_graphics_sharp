namespace Renderer
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
            this.outputBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.offsetValue = new System.Windows.Forms.TextBox();
            this.moveOut = new System.Windows.Forms.Button();
            this.moveCloser = new System.Windows.Forms.Button();
            this.moveRight = new System.Windows.Forms.Button();
            this.moveLeft = new System.Windows.Forms.Button();
            this.moveDown = new System.Windows.Forms.Button();
            this.moveUp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.angleChange = new System.Windows.Forms.TextBox();
            this.rollClockwise = new System.Windows.Forms.Button();
            this.rollUnclockwise = new System.Windows.Forms.Button();
            this.yawLeft = new System.Windows.Forms.Button();
            this.yawRight = new System.Windows.Forms.Button();
            this.pitchUp = new System.Windows.Forms.Button();
            this.pitchDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 12);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(640, 640);
            this.outputBox.TabIndex = 0;
            this.outputBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.offsetValue);
            this.panel1.Controls.Add(this.moveOut);
            this.panel1.Controls.Add(this.moveCloser);
            this.panel1.Controls.Add(this.moveRight);
            this.panel1.Controls.Add(this.moveLeft);
            this.panel1.Controls.Add(this.moveDown);
            this.panel1.Controls.Add(this.moveUp);
            this.panel1.Location = new System.Drawing.Point(659, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 222);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // offsetValue
            // 
            this.offsetValue.Location = new System.Drawing.Point(49, 60);
            this.offsetValue.Name = "offsetValue";
            this.offsetValue.Size = new System.Drawing.Size(40, 20);
            this.offsetValue.TabIndex = 6;
            this.offsetValue.Text = "0";
            this.offsetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // moveOut
            // 
            this.moveOut.Location = new System.Drawing.Point(95, 3);
            this.moveOut.Name = "moveOut";
            this.moveOut.Size = new System.Drawing.Size(40, 40);
            this.moveOut.TabIndex = 5;
            this.moveOut.Text = "от нас";
            this.moveOut.UseVisualStyleBackColor = true;
            this.moveOut.Click += new System.EventHandler(this.moveOut_Click);
            // 
            // moveCloser
            // 
            this.moveCloser.Location = new System.Drawing.Point(3, 95);
            this.moveCloser.Name = "moveCloser";
            this.moveCloser.Size = new System.Drawing.Size(40, 40);
            this.moveCloser.TabIndex = 4;
            this.moveCloser.Text = "|__";
            this.moveCloser.UseVisualStyleBackColor = true;
            this.moveCloser.Click += new System.EventHandler(this.moveCloser_Click);
            // 
            // moveRight
            // 
            this.moveRight.Location = new System.Drawing.Point(95, 49);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(40, 40);
            this.moveRight.TabIndex = 3;
            this.moveRight.Text = ">";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.Click += new System.EventHandler(this.moveRight_Click);
            // 
            // moveLeft
            // 
            this.moveLeft.Location = new System.Drawing.Point(3, 49);
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(40, 40);
            this.moveLeft.TabIndex = 2;
            this.moveLeft.Text = "<";
            this.moveLeft.UseVisualStyleBackColor = true;
            this.moveLeft.Click += new System.EventHandler(this.moveLeft_Click);
            // 
            // moveDown
            // 
            this.moveDown.Location = new System.Drawing.Point(49, 95);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(40, 40);
            this.moveDown.TabIndex = 1;
            this.moveDown.Text = "\\/";
            this.moveDown.UseVisualStyleBackColor = true;
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // moveUp
            // 
            this.moveUp.Location = new System.Drawing.Point(49, 3);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(40, 40);
            this.moveUp.TabIndex = 0;
            this.moveUp.Text = "/\\";
            this.moveUp.UseVisualStyleBackColor = true;
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.angleChange);
            this.panel2.Controls.Add(this.rollClockwise);
            this.panel2.Controls.Add(this.rollUnclockwise);
            this.panel2.Controls.Add(this.yawLeft);
            this.panel2.Controls.Add(this.yawRight);
            this.panel2.Controls.Add(this.pitchUp);
            this.panel2.Controls.Add(this.pitchDown);
            this.panel2.Location = new System.Drawing.Point(911, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 222);
            this.panel2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "label6";
            // 
            // angleChange
            // 
            this.angleChange.Location = new System.Drawing.Point(49, 60);
            this.angleChange.Name = "angleChange";
            this.angleChange.Size = new System.Drawing.Size(40, 20);
            this.angleChange.TabIndex = 6;
            this.angleChange.Text = "0";
            this.angleChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rollClockwise
            // 
            this.rollClockwise.Location = new System.Drawing.Point(95, 95);
            this.rollClockwise.Name = "rollClockwise";
            this.rollClockwise.Size = new System.Drawing.Size(40, 40);
            this.rollClockwise.TabIndex = 5;
            this.rollClockwise.Text = "roll clock";
            this.rollClockwise.UseVisualStyleBackColor = true;
            this.rollClockwise.Click += new System.EventHandler(this.rollClockwise_Click);
            // 
            // rollUnclockwise
            // 
            this.rollUnclockwise.Location = new System.Drawing.Point(3, 95);
            this.rollUnclockwise.Name = "rollUnclockwise";
            this.rollUnclockwise.Size = new System.Drawing.Size(40, 40);
            this.rollUnclockwise.TabIndex = 4;
            this.rollUnclockwise.Text = "roll unclock";
            this.rollUnclockwise.UseVisualStyleBackColor = true;
            this.rollUnclockwise.Click += new System.EventHandler(this.rollUnclockwise_Click);
            // 
            // yawLeft
            // 
            this.yawLeft.Location = new System.Drawing.Point(95, 49);
            this.yawLeft.Name = "yawLeft";
            this.yawLeft.Size = new System.Drawing.Size(40, 40);
            this.yawLeft.TabIndex = 3;
            this.yawLeft.Text = "yaw left";
            this.yawLeft.UseVisualStyleBackColor = true;
            this.yawLeft.Click += new System.EventHandler(this.yawLeft_Click);
            // 
            // yawRight
            // 
            this.yawRight.Location = new System.Drawing.Point(3, 49);
            this.yawRight.Name = "yawRight";
            this.yawRight.Size = new System.Drawing.Size(40, 40);
            this.yawRight.TabIndex = 2;
            this.yawRight.Text = "yaw right";
            this.yawRight.UseVisualStyleBackColor = true;
            this.yawRight.Click += new System.EventHandler(this.yawRight_Click);
            // 
            // pitchUp
            // 
            this.pitchUp.Location = new System.Drawing.Point(49, 95);
            this.pitchUp.Name = "pitchUp";
            this.pitchUp.Size = new System.Drawing.Size(40, 40);
            this.pitchUp.TabIndex = 1;
            this.pitchUp.Text = "pitch up";
            this.pitchUp.UseVisualStyleBackColor = true;
            this.pitchUp.Click += new System.EventHandler(this.pitchUp_Click);
            // 
            // pitchDown
            // 
            this.pitchDown.Location = new System.Drawing.Point(49, 3);
            this.pitchDown.Name = "pitchDown";
            this.pitchDown.Size = new System.Drawing.Size(40, 40);
            this.pitchDown.TabIndex = 0;
            this.pitchDown.Text = "pitch down";
            this.pitchDown.UseVisualStyleBackColor = true;
            this.pitchDown.Click += new System.EventHandler(this.pitchDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 709);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox outputBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox offsetValue;
        private System.Windows.Forms.Button moveOut;
        private System.Windows.Forms.Button moveCloser;
        private System.Windows.Forms.Button moveRight;
        private System.Windows.Forms.Button moveLeft;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.Button moveUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox angleChange;
        private System.Windows.Forms.Button rollClockwise;
        private System.Windows.Forms.Button rollUnclockwise;
        private System.Windows.Forms.Button yawLeft;
        private System.Windows.Forms.Button yawRight;
        private System.Windows.Forms.Button pitchUp;
        private System.Windows.Forms.Button pitchDown;
    }
}

