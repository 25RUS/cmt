namespace CMT.Models
{
    public class Modems
    {
        public class Modem
        {
            //public int Id {get; set;}
            public string Manufacturer {get; set;}
            public string Model {get; set;}
            public string Revision {get; set;}
            public string IMEI {get; set;}
            public string Port {get; set;}
            //public string OpSosCode {get; set;}
            public string OpSosName {get; set;}            
        }
        
        /*
        public class Root
        {
            public List<Modem> modem {get; set;}
        }
        */

    }
}