using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefonRehberi.ViewModels
{
    public class PersonelVM
    {
        public int PersonelID { get; set; }

        public string PersonelAdi { get; set; }

        public string PersonelSoyadi { get; set; }

        public string PersonelTelefon { get; set; }

        public string Yonetici { get; set; }

        public string Departman { get; set; }
    }
}