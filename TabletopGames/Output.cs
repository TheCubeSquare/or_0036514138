using System.Collections.Generic;

namespace TabletopGames
{
    public class Output
    {
        public static string Message
        {
            get { return "Message"; }
        }

        public static string ErrorOccurred
        {
            get { return "ErrorOccurred"; }
        }

        public static Dictionary<string, Dictionary<string, string>> Tables
        {
            get
            {
                return new Dictionary<string, Dictionary<string, string>>()
                {
                    { "Toni", new Dictionary<string, string>(){
                        { "Odobrenje za gašenje (STP)", "OdobrenjeZaGasenje" },
                        { "Uređaj (JTP)", "Uredaj" },
                        { "Razina stručnosti (JTP)", "RazinaStrucnosti" }
                    }
                    }
                };
            }
        }
    }
}
