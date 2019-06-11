using System;

namespace ASPNETCoreWebApiAzurePRONuncia.Models {
    public class Jugador {
        public string email { get; set; }
        public string username { get; set; } 
        public string name { get; set; }
        public string lastname { get; set; }
        public string country { get; set; }
        public int level { get; set; }
        public int nopoints { get; set; }
        public int elo { get; set; }
    }
}