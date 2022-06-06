namespace CMT.Modem
{
    public class USSD
    {
        Modem.TERMINAL terminal = new Modem.TERMINAL();
  
        public void Responce(string port, string resp)
        {
            string ussdAnswer = terminal.Write(port, $"AT+CUSD=1,\"{resp}\"");  
            //string ussdAnswer = terminal.Write(port, $"ATD{resp};"); 
            LayOut.Shell.Print(ussdAnswer, 3);
        }
    }
}