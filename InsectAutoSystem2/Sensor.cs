using EasyModbus;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsectAutoSystem2
{
    class Sensor
    {
        private SerialPort serialPort = new SerialPort();
        private string serialPortName;
        private ShowMessageDelegate showMessageDelegate;
        private ModbusClient modbusClient;

        public Sensor(string strSerialPortName, ShowMessageDelegate del)
        {
            showMessageDelegate = del;
            serialPortName = strSerialPortName;
            setSerialPort();
        }

        private void setSerialPort()
        {
            modbusClient = new ModbusClient(serialPortName);
            modbusClient.Parity = Parity.None;
            modbusClient.Baudrate = 9600;
            modbusClient.StopBits = StopBits.One;

            if (!modbusClient.Connected)
            {
                modbusClient.Connect();
                showMessageDelegate("센서가 연결되었습니다.\r\n");
            }
            else
            {
                modbusClient.Disconnect();
                showMessageDelegate("센서 연결이 해제되었습니다.\r\n");
            }
        }

        public int[] read()
        {
            int[] values = new int[10];
            if (modbusClient.Connected)
            {
                try
                {
                    int startAddress = 0;
                    int numberOfValues = 11;
                    values = modbusClient.ReadHoldingRegisters(startAddress, numberOfValues);
                }
                catch (Exception ex)
                {
                    /*MessageBox.Show("Error reading values: " + ex.Message);*/
                }
            }
            return values;
        }

        
    }
}
