using System.IO.Ports;

namespace CMT.Modem
{
    public class TERMINAL
    {
        
        SerialPort SP = new SerialPort();

        public void ClosePort(string portName)
        {
            SP.PortName = portName;

            try
            {
                SP.Close();
            }
            catch
            {
                ;
            }
        }
        
        public string Write(string portName, string command)
        {        
            string answer = "";

            try
            {
                SP.PortName = portName;
                SP.BaudRate = 115200;
                SP.Parity = Parity.None;
                SP.StopBits = StopBits.One;
                SP.DataBits = 8;
                SP.Handshake = Handshake.RequestToSend;
                SP.DtrEnable = true;
                SP.RtsEnable = true;
                SP.Open();
                SP.Write(command);
                Thread.Sleep(500);
                answer += SP.ReadExisting().ToString();
                SP.Close();
            }
            catch(Exception e)
            {
                Log.Write($"{portName}: \n {e.ToString()}");
            }         
            
            //говнокод
            
            string [] answ = answer.Split(new char[] {'\n'});
            string outAns = "";

            for(int i=0;i<answ.Count();i++)
            {
                if(answ[i] != "")
                {
                    outAns += answ[i] += "\n";
                }
            }
                        
            return outAns;         
        } 
    }
}