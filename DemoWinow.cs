/*****************************************************************************/
/* Project  : AvionicsInstrumentControlDemo                                  */
/* File     : DemoWondow.cs                                                  */
/* Version  : 1                                                              */
/* Language : C#                                                             */
/* Summary  : Start window of the project, use to test the instruments       */
/* Creation : 30/06/2008                                                     */
/* Autor    : Guillaume CHOUTEAU                                             */
/* History  :                                                                */
/* Dr. Elliott Coleshill -- Added socket capabilities to remotely connect    */
/*                          with my research software and/or a FTD           */
/*****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace AvionicsInstrumentControlDemo
{
    public struct Telemetry
    {
        public float Alt;              //Altitude
        public float Pitch;            //Additude Indicator Pitch angle
        public float Bank;             //Additude Indicator Bank angle
        public float VS;               //Vertical Speed
        public float TC_Rate;          //Turn Coordinator - Rate of Turn
        public float TC_Yaw;           //Turn Coordinator - Yaw
        public float IAS;              //Indicated Airspeed
        public float Heading;          //Heading Indicator
        public int Terminate;         //Termination Flag

        public Telemetry(int vAlt)
        {
            Alt = 0;
            Pitch = 0;
            Bank = 0;
            VS = 0;
            TC_Rate = 0;
            TC_Yaw = 0;
            IAS = 0;
            Heading = 0;
            Terminate = 0;
        }
    }

    public partial class DemoWinow : Form
    {
        public static string data = null;
        public static Socket handler = null;
        System.Threading.Thread socketThread;
        bool bTerminate = false;

        public DemoWinow()
        { 
            InitializeComponent();
        }

        private void SetIAS(float value)
        {
            if (airSpeedInstrumentControl1.InvokeRequired)
                airSpeedInstrumentControl1.Invoke((MethodInvoker)delegate ()
                {
                    SetIAS(value);
                });
            else
                airSpeedInstrumentControl1.SetAirSpeedIndicatorParameters((int)value);
        }

        private void SetVS(float value)
        {
            if (verticalSpeedInstrumentControl1.InvokeRequired)
                verticalSpeedInstrumentControl1.Invoke((MethodInvoker)delegate ()
                {
                    SetVS(value);
                });
            else
                verticalSpeedInstrumentControl1.SetVerticalSpeedIndicatorParameters((int)value);
        }

        private void SetAttitude(float Pitch, float Roll)
        {
            if (horizonInstrumentControl1.InvokeRequired)
                horizonInstrumentControl1.Invoke((MethodInvoker)delegate ()
                {
                    SetAttitude(Pitch, Roll);
                });
            else
                horizonInstrumentControl1.SetAttitudeIndicatorParameters((int)Pitch*-1, (int)Roll*-1);
        }

        private void SetAlt(float value)
        {
            if (altimeterInstrumentControl1.InvokeRequired)
                altimeterInstrumentControl1.Invoke((MethodInvoker)delegate ()
                {
                    SetAlt(value);
                });
            else
                altimeterInstrumentControl1.SetAlimeterParameters((int)value);
        }

        private void SetHeading(float value)
        {
            if (headingIndicatorInstrumentControl1.InvokeRequired)
                headingIndicatorInstrumentControl1.Invoke((MethodInvoker)delegate ()
                {
                    SetHeading(value);
                });
            else
                headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters((int)value);
        }

        private void SetTC(float Rate, float Yaw)
        {
            if (turnCoordinatorInstrumentControl1.InvokeRequired)
                turnCoordinatorInstrumentControl1.Invoke((MethodInvoker)delegate ()
                {
                    SetTC(Rate, Yaw);
                });
            else
                turnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters((Rate / 10)*-1, Yaw);
        }

        private void threadLogic(AvionicsInstrumentControlDemo.DemoWinow t)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                // Program is suspended while waiting for an incoming connection.  
                handler = listener.Accept();

                // An incoming connection needs to be processed.  
                bool bRun = true;
                while ((bRun) && (!bTerminate))
                 {
                    Telemetry RxT;
                    
                    int bytesRec = handler.Receive(bytes);
                    if (bytesRec > 0)
                    {
                        GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                        RxT = (Telemetry)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Telemetry));

                        //Set all the GUI displays based on the telemetry that has been received
                        t.SetAlt(RxT.Alt);
                        t.SetAttitude(RxT.Pitch, RxT.Bank);
                        t.SetVS(RxT.VS);
                        t.SetTC(RxT.TC_Rate, RxT.TC_Yaw);
                        t.SetIAS(RxT.IAS);
                        t.SetHeading(RxT.Heading);

                        if (RxT.Terminate == 5)
                            bRun = false;
                    }
                 }
                handler.Disconnect(false);   //Disconnect the TCP/IP Interface and let the thread terminate
            }
            catch (Exception except)
            {
                Console.WriteLine(except.ToString());
            }
        }

        //This button click starts the socket communications thread for dyanmic real-time
        //control of the GUI displays
        private void button1_Click(object sender, EventArgs e)
        {
            bTerminate = false;
            socketThread = new Thread(() => threadLogic(this));
            socketThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bTerminate = true;
            Application.Exit();
        }
    }
}