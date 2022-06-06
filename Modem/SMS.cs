namespace CMT.Modem
{
    public class SMS
    {
        TERMINAL terminal = new TERMINAL();

        public void SendPDU(string textMsg, string targetPhone, string gate, int flash=0)
        {
            targetPhone = targetPhone.Replace("+", ""); //'откидывает + заменой на ""
            
            if(targetPhone.Length % 2 !=0)
            {
                targetPhone += "F";
            }

            //'намешиваем символы в номере  
            string tPhoneMixed = string.Empty;

            for(int i=0;i<targetPhone.Length;i=i+2)
            {
                tPhoneMixed += targetPhone[i+1];
                tPhoneMixed += targetPhone[i];
            }
        
            //'######################преобразование текста в UCS-2######################
            byte [] bMsg = System.Text.Encoding.BigEndianUnicode.GetBytes(textMsg);
            string bMsgStr = BitConverter.ToString(bMsg).Replace("-", "");
            int bMLenghtDec = bMsgStr.Length;
            string bmsgstrHexL = bMLenghtDec.ToString("X2"); // Hex(bMLenghtDec.ToString());
            int l = 26 + bMLenghtDec;
            int l1 = l / 2;
            string MSG = $"0001000B91{tPhoneMixed}00{flash}8{bmsgstrHexL}{bMsgStr}";

            List<string> tmp = new List<string>();
            tmp.Add(terminal.Write(gate, "AT\r\n"));
            tmp.Add(terminal.Write(gate, "AT+CMGF=0\r\n"));
            tmp.Add(terminal.Write(gate, $"AT+CMGS={l1}\r\n"));
            tmp.Add(terminal.Write(gate, $"{MSG}{(char)26}\r\n"));

            //абасраца и убица
            for(int m=0;m<tmp.Count;m++)
            {
                string t = tmp[m].Replace(" ", "").Replace("\r","");
                if(t!=string.Empty)
                    LayOut.Shell.Print(t, 2);
            }                
        }

        public void ReadPDU(string port)
        {
            string msg = terminal.Write(port, $"AT+CMGL=\"ALL\"\r\n");
            string tmp = terminal.Write(port, $"AT+CMGDA=\"DEL ALL\"\r\n");
        }


    }
}