using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Required]
        public string PersonelAdi { get; set; }

        [Required]
        public string PersonelSoyadi { get; set; }

        [Required]
        public string PersonelTelefonNo { get; set; }
        
        public int YoneticiID { get; set; }

        [Required]
        public int DepartmanID { get; set; }
        
        public Departman PersonelDepartman { get; set; }

         
        
    }
}