namespace CMT.LayOut
{
    public static class Shell
    {
        public static void Listen()
        {
            Console.WriteLine("cmt > ");
            Input(Console.ReadLine());
        }

        private static void Input(string cmd)
        {
            Modem.Initialize init = new Modem.Initialize();
            Modem.SMS sms = new();

            List<string> cmdList = new (cmd.Split(" ")); 

            if(cmdList.Count>1)
            {
                switch(cmdList[0])
                {
                    case "sms":  //sms +79990006655 /dev/ttyUSB0 казёл ебучий
                    {
                        string msg = string.Empty;

                        for(int i=3; i<cmdList.Count;i++)
                        {
                            msg += cmdList[i] += " ";
                        }

                        sms.SendPDU(msg, cmdList[1], cmdList[2]);
                        break;
                    }
                    case "flash":  //sms +79990006655 /dev/ttyUSB0 казёл ебучий
                    {
                        string msg = string.Empty;

                        for(int i=3; i<cmdList.Count;i++)
                        {
                            msg += cmdList[i] += " ";
                        }

                        sms.SendPDU(msg, cmdList[1], cmdList[2], 1);
                        break;
                    }
                    case "rssi": //rssi /dev/ttyUSB
                    {
                        Modem.Network n = new();
                        n.GetRSSI(cmdList[1]);
                        break;
                    }
                    case "ussd": //ussd /dev/ttyUSB *105#
                    {
                        Modem.USSD ussd = new();
                        ussd.Responce(cmdList[1], cmdList[2]);
                        break;
                    }
                    case "dial":
                    {
                        Modem.Dialer dialer = new();
                        dialer.DialOut(cmdList[1], cmdList[2]);
                        break;
                    }
                    case "op":
                    {
                        Modem.Network n = new();
                        LayOut.Shell.Print(n.GetOpSos(cmdList[1]), 3);
                        break;
                    }
                }
            }
            else
            {
                switch(cmd)
                {
                    case "r":
                    {
                        init.GetModems();
                        break;
                    }
                    case "q":
                    {
                        Environment.Exit(0);
                        break;
                    }
                    case "sg":
                    {
                        JShow jShow = new();
                        jShow.DisplayModems();
                        break;
                    }
                    
                }
            }
            Listen();
        }




        //display text information with styles
        public static void Print(string text, int colour)//(List<Models.PlainText.TextBlock> plainText)
        {           
            switch(colour)
            {
                case 0:
                {

                    break;
                }
                case 1:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
                case 2:
                {                        
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                }
                case 3:
                {                        
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                }
                case 4:
                {                        
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                }
            }
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
                
            //Listen();
        }
    }
    
}