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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ball = new System.Windows.Forms.PictureBox();
            this.target = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.target)).BeginInit();
            this.SuspendLayout();
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ball.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball.BackgroundImage")));
            this.ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ball.Location = new System.Drawing.Point(820, 310);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(120, 120);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // target
            // 
            this.target.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.target.Location = new System.Drawing.Point(401, 58);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(140, 20);
            this.target.TabIndex = 3;
            this.target.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(436, 451);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
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
            this.label9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(593, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "State";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBoxAx
            // 
            this.textBoxAx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAx.Location = new System.Drawing.Point(660, 171);
            this.textBoxAx.Name = "textBoxAx";
            this.textBoxAx.Size = new System.Drawing.Size(101, 30);
            this.textBoxAx.TabIndex = 22;
            this.textBoxAx.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(593, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Ax";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxAy
            // 
            this.textBoxAy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAy.Location = new System.Drawing.Point(660, 223);
            this.textBoxAy.Name = "textBoxAy";
            this.textBoxAy.Size = new System.Drawing.Size(101, 30);
            this.textBoxAy.TabIndex = 24;
            this.textBoxAy.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(593, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ay";
            // 
            // labelCOMPort
            // 
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelCOMPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCOMPort.Location = new System.Drawing.Point(179, 454);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(235, 25);
            this.labelCOMPort.TabIndex = 25;
            this.labelCOMPort.Text = "Accelerometer COM port:";
            // 
            // buttonConnectSerial
            // 
            this.buttonConnectSerial.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonConnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectSerial.Location = new System.Drawing.Point(174, 162);
            this.buttonConnectSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConnectSerial.Name = "buttonConnectSerial";
            this.buttonConnectSerial.Size = new System.Drawing.Size(616, 283);
            this.buttonConnectSerial.TabIndex = 28;
            this.buttonConnectSerial.Text = "Start Game";
            this.buttonConnectSerial.UseVisualStyleBackColor = false;
            this.buttonConnectSerial.Click += new System.EventHandler(this.buttonConnectSerial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::lab1Creative.Properties.Resources.gameBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(965, 497);
            this.Controls.Add(this.buttonConnectSerial);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelCOMPort);
            this.Controls.Add(this.target);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.textBoxAy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.label9);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.Button buttonConnectSerial;
    }
}

