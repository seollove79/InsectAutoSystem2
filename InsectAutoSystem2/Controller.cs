using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsectAutoSystem2
{
    class Controller
    {
        SerialPort serialPort = new SerialPort();

        public Controller(string serialPortName)
        {
            serialPort.PortName = serialPortName;  // TODO: 장치이름으로 자동으로 잡히게 해야 한다.
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.Handshake = Handshake.None; // 핸드셰이크
            serialPort.Encoding = System.Text.Encoding.ASCII; // 인코딩 방식
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(serialPort.ReadLine());
        }

        public void sendCommand(String command)
        {
            if (command == "motor_run")
            {
                serialPort.Open();
                serialPort.Write("!,1,1,");
                byte[] bytes = { 0x14, 0x4C };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
                serialPort.Close();
            }

            if (command == "motor_stop")
            {
                serialPort.Open();
                serialPort.Write("!,1,0,");
                byte[] bytes = { 0x84, 0x4D };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
                serialPort.Close();
            }

            if (command == "suttle_run")
            {
                serialPort.Open();
                serialPort.Write("!,3,1,");
                byte[] bytes = { 0xAC, 0x4D };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
                serialPort.Close();
            }

            if (command == "suttle_stop")
            {
                serialPort.Open();
                serialPort.Write("!,3,0,");
                byte[] bytes = { 0x3C, 0x4C };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
                serialPort.Close();
            }
        }

        
    }
}

