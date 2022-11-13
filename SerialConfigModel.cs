using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader
{
    public class SerialConfigModel
    {
        public SerialPort SerialPort { get; set; }
        public string PortName
        {
            get => SerialPort.PortName;
            set => SerialPort.PortName = value;
        }
        public int Baudrate { 
            get => SerialPort.BaudRate;
            set => SerialPort.BaudRate = value; 
        }
        public Parity Parity { 
            get => SerialPort.Parity; 
            set => SerialPort.Parity = value; 
        }
        public Handshake Handshake { 
            get => SerialPort.Handshake; 
            set => SerialPort.Handshake = value; 
        }
        public int DataBits { 
            get => SerialPort.DataBits; 
            set => SerialPort.DataBits = value; 
        }
        public StopBits StopBits { 
            get => SerialPort.StopBits; 
            set => SerialPort.StopBits = value; 
        }
        public bool IsOpen => SerialPort.IsOpen;

        public string FileLocation { get; set; }

    }
}
