using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace lab1Creative
{
    public partial class Form1 : Form
    {
        Int32 ballMoveStep = 2;
        Int32 Xvelocity = 5;
        Int32 Yvelocity = 5;
        Int32 speed = 5;

        // store Ax, Ay, Az values in ConcurrentQueues
        ConcurrentQueue<Int32> ax = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> ay = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> az = new ConcurrentQueue<Int32>();

        int axVal = 127;
        int ayVal = 127;
        int azVal = 127;

        int axOld = 127;
        int ayOld = 127;
        int azOld = 127;

        // store the user input Ax, Ay, Az value
        double axInput = 127;
        double ayInput = 127;
        double azInput = 127;

        // number of data points to record
        Int32 numDataPts = 1;

        // to display Serial Bytes to Read
        int serialBytesToRead = 0;

        // to temporarily hold incoming serial data
        string serialDataString = "";

        // store each new data byte in a ConcurrentQueue instead of a string
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        // normalized change in position of ball
        double Xstep = 0.0;
        double Ystep = 0.0;

        int state = 0;
        int count = 0;

        // parameters of game
        int maxSpeed = 10;
        int accelThresh = 180; // Ax value when throwing action initiated


        Random randomizer = new Random();
        int ballStartY = 1;
        int randNum = 50; // store a random number between 0 and 50


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // acquire the available COM ports and deposit them in a ComboBox

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox1.Items.Count == 0)
                comboBox1.Text = "No COM ports!";
            else
                comboBox1.SelectedIndex = 0;

            timer1.Start();

            // hide target picturebox
            target.Hide();

            // uncomment for testing
            label1.Hide();
            textBoxAx.Hide();
            label2.Hide();
            textBoxAy.Hide();
            label9.Hide();
            textBoxState.Hide();

            
        }

        // DataReceived event handler for serialPort


        private void timer1_Tick(object sender, EventArgs e)
        {
            // for parsing the accelerometer data stream into Ax, Ay, Az
            bool nextIsAx = false;
            bool nextIsAy = false;
            bool nextIsAz = false;

            // Accelerometer
            // display the contents of dataQueue in textBoxSerialDataStream
            Int32 dequeuedItem = 0;

            foreach (Int32 item in dataQueue)
            {
                if (dataQueue.TryDequeue(out dequeuedItem)) // in case of collision btn threads
                {
                    // parse the accelerometer data stream into Ax, Ay, Az
                    // display in textboxes and store in respective queues
                    if (dequeuedItem == 255)
                    {
                        nextIsAx = true;
                    }
                    else if (nextIsAx)
                    {
                        axVal = dequeuedItem;
                        ax.Enqueue(dequeuedItem);
                        nextIsAy = true;
                        nextIsAx = false;
                    }
                    else if (nextIsAy)
                    {
                        ayVal = dequeuedItem;
                        ay.Enqueue(dequeuedItem);
                        nextIsAz = true;
                        nextIsAy = false;
                    }
                    else if (nextIsAz)
                    {
                        azVal = dequeuedItem;
                        az.Enqueue(dequeuedItem);
                        nextIsAz = false;

                        // generate random number between 10 and 40
                        randNum = randomizer.Next(10,41);

                        // update state variable
                        state_machine_control();
                        textBoxState.Text = state.ToString();

                        textBoxAx.Text = axInput.ToString();
                        textBoxAy.Text = ayInput.ToString();

                        // update other variable according to the current state
                        state_machine_update();
                        //textBoxGesture.Text = gesture.ToString();
                    }
                }
            }
        }



        void state_machine_control()
        {
            int recordThresh = numDataPts*4; // wait for acceleration
            if (state == 1)
            {
                if (ayInput > accelThresh)
                {
                    state = 2;
                }
            }
            else if (state == 2)
            {
                if (ball.Location.Y < 0) // lose
                {
                    state = 4;
                }
                else if (ball.Bounds.IntersectsWith(target.Bounds))
                {
                    state = 3;
                }
            }
            else if (state == 3)
            {
                state = 0;
            }
            else if (state == 4)
            {
                state = 0;
            }
            else // state == 0
            {
                state = 1;
            }
        }

        void state_machine_update()
        {

            //Point ballStartLocation = new Point(Width / 2, Height / 2);

            // random ball start location in y
            ballStartY = Width / 2;

            if (state == 1) // wait for acceleration
            {
                axInput = axVal;
                ayInput = ayVal;
            }
            else if (state == 2) // move ball
            {
                
                // negative due to sensor delay
                Xstep = (axInput - 127) / 127 * maxSpeed;

                // negative absoluate value to always move the ball up
                if ((ayInput - 127) < 0)
                {
                    Ystep = (ayInput - 127) / 127 * maxSpeed;
                }
                else
                {
                    Ystep = -1 * (ayInput - 127) / 127 * maxSpeed;
                }
                    

                Xvelocity = Convert.ToInt32(Xstep * speed);
                Yvelocity = Convert.ToInt32(Ystep * speed);

                Point ballMoveLocation = new Point(ball.Location.X + Xvelocity, ball.Location.Y + Yvelocity);
                ball.Location = ballMoveLocation;
            }
            else if (state == 3)
            {
                MessageBox.Show("Yay you win!");
                // generate random number for new ball location
                randNum = randomizer.Next(10,41);
            }
            else if (state == 4)
            {
                MessageBox.Show("you lost!");
                // generate random number for new ball location
                randNum = randomizer.Next(10,41);
            }
            else // state == 0 // game start
            {
                // set a random ball location
                ballStartY = Convert.ToInt32(1 + (Width * (randNum / 50.0)));
                
                Point ballStartLocation = new Point(ballStartY, Height / 2);
                ball.Location = ballStartLocation;
                //target.Location = targetStartLocation;
                count = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
        }

        private void textBoxState_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            // determine the number of BytesToRead in the serial buffer
            serialBytesToRead = serialPort1.BytesToRead;
            bytesToRead = serialBytesToRead;

            // read the bytes, one at a time, from the serial buffer
            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                // Convert each byte to a string and append it to the serialDataString with “,“ and “ “ characters
                serialDataString = serialDataString + newByte.ToString() + ", ";

                // Enqueue
                dataQueue.Enqueue(newByte);

                bytesToRead = serialPort1.BytesToRead;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnectSerial_Click(object sender, EventArgs e)
        {
            // hide Game start UI elements
            buttonConnectSerial.Hide();
            labelCOMPort.Hide();
            comboBox1.Hide();

            string nameCOMPort = "";
            // check if connection is satisfied
            if (comboBox1.Text != "")
                nameCOMPort = comboBox1.Text;
            else
                MessageBox.Show("No COM Port Selected", "Error");
            // open and close port
            if (serialPort1.IsOpen)
            {
                serialPort1.Dispose();
                buttonConnectSerial.Text = "Connect";
            }
            else if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = nameCOMPort;
                serialPort1.Open();
                buttonConnectSerial.Text = "Disconnect";
            }
        }
    }
}
