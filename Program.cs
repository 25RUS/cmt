// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



CMT.SysInit.DirPrepare();

//CMT.Modem.Initialize initialize = new CMT.Modem.Initialize();
//initialize.GetModems();

//CMT.Modem.SMS  sms = new CMT.Modem.SMS();
//sms.SendPDU("залупа", "+666", "/dev/ttyUSB0");

//CMT.Modem.Network n = new();
//Console.WriteLine(n.GetOpSos("/dev/ttyUSB0"));

//CMT.Modem.Dialer dialer = new();
//dialer.DialOut("/dev/ttyUSB0", "+79940030962");

//CMT.Modem.USSD ussd = new();
//ussd.Responce("/dev/ttyUSB0", "*201#");


CMT.LayOut.Shell.Listen();
