using System.Threading;

namespace CMT.Modem
{
    public class Dialer
    {
        TERMINAL terminal = new TERMINAL();
        public void DialOut(string port, string number/*с плюсиком +79994445566*/)
        {
            string ring = terminal.Write(port, $"ATD{number};\r\n");           
            LayOut.Shell.Print($"{ring}", 2);
            Thread.Sleep(5000);
            DropRing(port);                       
        }

        private void DropRing(string port)
        {
            string dn = terminal.Write(port, "ATH0\r\n");
            LayOut.Shell.Print($"{dn}", 1);
        }
    }
    
}