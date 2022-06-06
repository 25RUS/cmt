namespace CMT.Modem
{
    public class Network
    {
        public /*Models.SigLvlData*/ void GetRSSI(string port)
        {   
            Models.SigLvlData sigLvlData = new();

            TERMINAL terminal = new TERMINAL();
            string csq = terminal.Write(port, "AT+CSQ\r\n");
            //LayOut.Shell.Print(csq, 4);
            csq = csq.Replace("\n", "").Replace("\r","").Replace("OK", "");
            //-113 + Х * 2 sig lvl in dB
            List<string> csqL = csq.Split(" ").ToList();

            int i=0;
            while(i<csqL.Count)
            {
                if(csqL[i]=="+CSQ:")
                {
                    sigLvlData.port = port;
                    sigLvlData.rssi = float.Parse(csqL[i+1]);

                    float db = -113 + sigLvlData.rssi * 2;
                    
                    sigLvlData.port = port;
                    sigLvlData.rssi = db;
                    
                    LayOut.Shell.Print($"Signal level: {db} dB", 4);
                }

                i++;
            }
            //return sigLvlData;                  
        }

        public string GetOpSos(string port)
        {
            TERMINAL terminal = new TERMINAL();
            string opOut = string.Empty;

            try 
            {
                string opsosina = terminal.Write(port, "AT+COPS?\r\n");
                opsosina = opsosina.Replace("\n", "").Replace("\r","");
                List<string> oN = opsosina.Split(",").ToList();

                string opName = oN[2].Replace("\"", "");
                

                switch(opName)
                {
                    case "":
                    {
                        opOut = "No service";
                        break;
                    }
                    case "25099":
                    {
                        opOut = "Beeline";
                        break;
                    }
                    case "25002":
                    {
                        opOut = "MegaFon";
                        break;
                    }
                    case "25020":
                    {
                        opOut = "Tele2";
                        break;
                    }
                    case "25001":
                    {
                        opOut = "MTS";
                        break;
                    }
                    default:
                    {
                        //operatorId = ;
                        opOut = opName;
                        break;
                    }
                }
            
                
            }
            catch
            {

            }
            return opOut;
        }        
       
    }
}