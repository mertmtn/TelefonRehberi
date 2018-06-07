using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TelefonRehberi.Models
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }

        [Required]
        public string DepartmanAdi { get; set; }        

        public List<Personel> PersonelList { get; set; }
    }
}