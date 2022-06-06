namespace CMT
{
    public static class SysInit
    {
        public static string rdn = "Resources";
        
        public static void DirPrepare()
        {
            if(!Directory.Exists(rdn))
            {
                Directory.CreateDirectory(rdn);
            }
        }       
    }
}