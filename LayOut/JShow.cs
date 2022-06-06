using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace CMT.LayOut
{
    public class JShow
    {
        public void DisplayModems()
        {
            List<Models.Modems.Modem> modem = new();
            string json = File.ReadAllText($"{SysInit.rdn}/gate_list.json");
            modem = JsonConvert.DeserializeObject<List<Models.Modems.Modem>>(json);

            for(int i=0;i<modem.Count;i++)
            {   
                Shell.Print($"Gate: {i}", 1);
                Shell.Print($"Manufacturer: {modem[i].Manufacturer}", 3);
                Shell.Print($"Model: {modem[i].Model}", 3);
                Shell.Print($"Revision: {modem[i].Revision}", 3);
                Shell.Print($"Port: {modem[i].Port}", 3);
                Shell.Print($"IMEI: {modem[i].IMEI}", 3);
                Shell.Print($"Operator: {modem[i].OpSosName}", 3);                
            }
        }
    }
}