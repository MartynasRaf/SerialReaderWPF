using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialReader
{
    public class SerialMonitor
    {
        private SerialConfigModel serialConfigModel;
        private bool _continue = false;

        public void Connect(SerialConfigModel serialConfigModel)
        {
            this.serialConfigModel = serialConfigModel;
            _continue = true;

            serialConfigModel.SerialPort.ReadTimeout = 10000;
            serialConfigModel.SerialPort.Open();

            Thread readThread = new Thread(Read) { IsBackground=true };
            readThread.Start();
        }

        private void Read()
        {
            var csv = new StringBuilder();
            while (_continue)
            {
                try
                {
                    var message = (serialConfigModel.SerialPort.ReadLine()).Split(' ');
                    
                    var newLine = string.Format("{0},{1},{2},{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message[0],message[1],message[2]);
                    csv.AppendLine(newLine);
                    File.AppendAllText(serialConfigModel.FileLocation, csv.ToString());
                }
                catch (TimeoutException) {
                }
            }
        }

        public void Disconnect ()
        {
            serialConfigModel.SerialPort.Close();
            _continue = false;
        }

    }
}
