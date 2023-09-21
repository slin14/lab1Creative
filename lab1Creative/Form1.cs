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

        // average of the Ax, Ay, Az queue
        double axAvg = 127;
        double ayAvg = 127;
        double azAvg = 127;

        // number of data points to record
        Int32 numDataPts = 2;

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

                            // update state variable
                            state_machine_control();
                            textBoxState.Text = state.ToString();

                            // update other variable according to the current state
                            state_machine_update();
                            //textBoxGesture.Text = gesture.ToString();
                    }
                }
            }
        }



        void state_machine_control()
        {
            int recordThresh = numDataPts*4; // cycles to wait when recording //4 * numDataPts
            if (state == 1)
            {
                if (count >= recordThresh)
                {
                    state = 2;
                }
            }
            else if (state == 2)
            {
                if (ball.Location.Y > 0) // lose
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
                if (axVal > accelThresh)
                {
                    state = 1;
                }
            }
        }

        void state_machine_update()
        {

            Point newLocation = new Point(Width / 2, Height / 2);
            

            if (state == 1) // record accelerometer data
            {
                count++;
            }
            else if (state == 2) // move ball
            {
                Xstep = (axVal - 127) / 127 * maxSpeed;
                Ystep = (ayVal - 127) / 127 * maxSpeed;
                Xvelocity = Convert.ToInt32(Xstep * speed);
                Yvelocity = Convert.ToInt32(Ystep * speed);
            }
            else if (state == 3)
            {
                MessageBox.Show("Yay you win!");
            }
            else if (state == 4)
            {
                MessageBox.Show("you lost!");
            }
            else // state == 0 // game start
            {
                ball.Location = newLocation;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // serialPort1.Open();

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
                button2.Text = "Connect";
            }
            else if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = nameCOMPort;
                serialPort1.Open();
                button2.Text = "Disconnect";
            }
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
    }
}
