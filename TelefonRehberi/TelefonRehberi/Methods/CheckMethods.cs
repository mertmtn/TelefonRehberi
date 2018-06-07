using System.Linq;
using TelefonRehberi.CustomException;
using TelefonRehberi.Models;

namespace TelefonRehberi.Methods
{
    public class CheckMethods
    {
        private GenericCrudMethod<Departman> _departman = null;
        private GenericCrudMethod<Personel> _personel = null;

        public CheckMethods()
        {
            _departman = new GenericCrudMethod<Departman>();
            _personel = new GenericCrudMethod<Personel>();
        }

        public void checkDepartman(Departman departman)
        {

            var departmanGetir = from d in _departman.SelectList()
                                 where d.DepartmanAdi == departman.DepartmanAdi
                                 select new { d.DepartmanAdi };

            if (departmanGetir.Count() != 0)
            {
                throw new DepartmanException("Departman Sistemde Mevcut");
            }
            else
            {
                _departman.Ekle(departman);
            }

        }

        public void checkDepartman(Departman departman, int id)
        {

            var departmanGetir = from d in _departman.SelectList()
                                 where d.DepartmanAdi == departman.DepartmanAdi
                                 select d;

            var guncellencekSatir = _departman.SelectList().FirstOrDefault(x => x.DepartmanID == id);


            if (departmanGetir.Count() != 0)
            {
                throw new DepartmanException("Departman Sistemde Mevcut");
            }
            else
            {
                guncellencekSatir.DepartmanID = id;
                guncellencekSatir.DepartmanAdi = departman.DepartmanAdi;
                _departman.Guncelle(guncellencekSatir);

            }

        }



        public int checkYonetici(Personel personel)
        {
            if (personel.YoneticiID != 0)
            {
                return personel.YoneticiID;
            }
            else
            {
                return 0;
            }
        }


        public void checkPersonelYonetici(int id)
        {
            var yoneticiPersonelList = from yonetici in _personel.SelectList()
                                       where yonetici.YoneticiID == id
                                       select new
                                       {
                                           yonetici.YoneticiID
                                       };
            
            if (yoneticiPersonelList.Count() != 0)
            {
                throw new YoneticiException("Bu personel en az bir personelin yöneticisidir, silme işlemi gerçekleşmedi...");
            }
            else
            {
                _personel.Sil(id);
            }
        }

        public void checkCalısanDepartman(int id)
        {
            var departman = _personel.SelectList().Where(x => x.DepartmanID == id).ToList();
            if (departman.Count != 0)
            {
                throw new DepartmanException("Bu departmanda çalışan personel bulunmaktadır, silme işlemi gerçekleşmedi...");
            }
            else
            {
                _departman.Sil(id);
            }
        }

    }
}