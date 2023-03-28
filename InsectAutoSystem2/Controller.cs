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
        private MonitorControllerDataDelegate monitorControllerDataDelegate;

        public Controller(string serialPortName, MonitorControllerDataDelegate del)
        {
            serialPort.PortName = serialPortName;  // TODO: 장치이름으로 자동으로 잡히게 해야 한다.
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.Handshake = Handshake.None; // 핸드셰이크
            serialPort.Encoding = System.Text.Encoding.ASCII; // 인코딩 방식
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            monitorControllerDataDelegate = del;
            serialPort.Open();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var readData = serialPort.ReadLine();
            monitorControllerDataDelegate(readData);
        }

        public void sendCommand(String command)
        {
            if (command == "motor_run")
            {
                serialPort.Write("!,1,1,");
                byte[] bytes = { 0x14, 0x4C };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
            }

            if (command == "motor_stop")
            {
                serialPort.Write("!,1,0,");
                byte[] bytes = { 0x84, 0x4D };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
            }

            if (command == "shuttle_run")
            {
                serialPort.Write("!,3,1,");
                byte[] bytes = { 0xAC, 0x4D };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
            }

            if (command == "shuttle_stop")
            {
                serialPort.Write("!,3,0,");
                byte[] bytes = { 0x3C, 0x4C };
                serialPort.Write(bytes, 0, 1);
                serialPort.Write(",");
                serialPort.Write(bytes, 1, 1);
                serialPort.Write("\r\n");
            }
        }

        
    }
}

