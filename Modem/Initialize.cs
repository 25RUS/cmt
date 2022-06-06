using System.IO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;


namespace CMT.Modem
{
    public class Initialize
    {
        public void GetModems()
        {
            TERMINAL terminal = new TERMINAL();
            List<string> ttys = SerialPort.GetPortNames().ToList();
            List<Models.Modems.Modem> modemList = new List<Models.Modems.Modem>();

            for(int i=0;i<ttys.Count;i++)
            {               
                string data = terminal.Write(ttys[i], "ATI\r\n");
                data = data.Replace(" ", "").Replace("\r","");

                if(data != "")
                {
                    Models.Modems.Modem modem = new Models.Modems.Modem();
                    
                    modem.Port = ttys[i];

                    List<string> lines = data.Split('\n').ToList();
                    lines.RemoveAll(str => String.IsNullOrEmpty(str));

                    for(int k=0;k<lines.Count;k++)
                    {
                        string [] kv = lines[k].Split(':');

                        switch (kv[0])
                        {
                            case "Manufacturer":
                            {
                                modem.Manufacturer += kv[1];
                                break;
                            }
                            case "Model":
                            {
                                modem.Model += kv[1];
                                break;
                            }
                            case "Revision":
                            {
                                modem.Revision += kv[1];
                                break;
                            }
                            case "IMEI":
                            {
                                modem.IMEI += kv[1];
                                break;
                            }
                        }                   
                    }
                    
                    Network n = new();
                    modem.OpSosName = n.GetOpSos(ttys[i]);
                    modemList.Add(modem); 
         
                }  
            }

            File.WriteAllText($"{SysInit.rdn}/gate_list.json", JsonConvert.SerializeObject(modemList/*root.modem*/).ToString());  

        }

        
    }
}