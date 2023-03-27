using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;  //시리얼통신을 위해 추가해줘야 함
using System.Management;
using System.Collections;

namespace InsectAutoSystem2
{
    class Scale
    {
        private float weight = 0;
        private SerialPort serialPort = new SerialPort();
        private string serialPortName;
        private ShowMessageDelegate showMessageDelegate;

        public Scale(string strSerialPortName, ShowMessageDelegate del)
        {
            showMessageDelegate = del;
            serialPortName = strSerialPortName;
        }
        
        public void setSerialPort()
        {
/*
//장치 이름 받아오기인데 써먹을 수 있으려나....
String[] serialNames = SerialPort.GetPortNames();
ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_SerialPort");
ArrayList devDescription = new ArrayList();

// 가져온 정보중에서 Description 에 대한 정보를 가져온다. 
//Description 외에도 많은 정보들이 있기 때문에 다수의 연결된 Serial Port를 충분히 구별할수 있다. 
foreach (ManagementObject share in searcher.Get())
{
devDescription.Add(share["Description"].ToString());
}

int count = devDescription.Count;

for (int i = 0; i < count; i++)
{
Console.WriteLine(devDescription[i].ToString());

if (devDescription[i].ToString() == "CAS-SCALE")
{
serialPort.PortName = "CAS-SCALE";  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
serialPort.BaudRate = 9600;  //보레이트 변경이 필요하면 숫자 변경하기
serialPort.DataBits = 8;
serialPort.StopBits = StopBits.One;
serialPort.Parity = Parity.None;
serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); //이것이 꼭 필요하다

serialPort.Open();


}

}
*/

            serialPort.PortName = serialPortName;  // TODO: 장치이름으로 자동으로 잡히게 해야 한다.
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.Open();

            if (serialPort.IsOpen)
            {
                showMessageDelegate("저울이 연결되었습니다.\r\n");
            }
            else
            {
                showMessageDelegate("저울 연결을 실패하였습니다.\r\n");
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
        {
            string str = serialPort.ReadLine();
            str = str.Replace(" ", string.Empty);
            weight = float.Parse(str);
            //Console.WriteLine(weight);
        }

        public float getWeight()
        {
            return weight;
        }
    }
}
