namespace lab1Creative
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ball = new System.Windows.Forms.PictureBox();
            this.target = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.axavgTest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.target)).BeginInit();
            this.SuspendLayout();
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ball.Location = new System.Drawing.Point(162, 242);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(120, 120);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // target
            // 
            this.target.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.target.Location = new System.Drawing.Point(153, 19);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(143, 56);
            this.target.TabIndex = 3;
            this.target.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(515, 397);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 33);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(504, 360);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "Connect Serial";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxState
            // 
            this.textBoxState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxState.Location = new System.Drawing.Point(660, 273);
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(101, 30);
            this.textBoxState.TabIndex = 20;
            this.textBoxState.TabStop = false;
            this.textBoxState.TextChanged += new System.EventHandler(this.textBoxState_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(593, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "State";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // axavgTest
            // 
            this.axavgTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.axavgTest.Location = new System.Drawing.Point(660, 165);
            this.axavgTest.Name = "axavgTest";
            this.axavgTest.Size = new System.Drawing.Size(101, 30);
            this.axavgTest.TabIndex = 21;
            this.axavgTest.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axavgTest);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.target);
            this.Controls.Add(this.ball);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.target)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox target;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox axavgTest;
    }
}

