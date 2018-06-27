using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader.Class.Configuration
{
    public static class DefaultSerialPort
    {
        public static SerialPort serialPort;

        static DefaultSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM3";
        }
    }
}
