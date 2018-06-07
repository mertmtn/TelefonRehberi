using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberi.Models;
using TelefonRehberi.ViewModels;

namespace TelefonRehberi.Methods
{
    public class RehberViewMethods
    {
        private GenericCrudMethod<Personel> _personel = null;
        private GenericCrudMethod<Departman> _departman = null;

        public RehberViewMethods()
        {       
            _departman = new GenericCrudMethod<Departman>();
            _personel = new GenericCrudMethod<Personel>();
        } 

        public PersonelVM personelView(int id)
        {
            var personel = _personel.SelectByID(id);

            var personelVM = new PersonelVM();

            personelVM.PersonelID = personel.PersonelID;
            personelVM.PersonelAdi = personel.PersonelAdi;
            personelVM.PersonelSoyadi = personel.PersonelSoyadi;
            personelVM.PersonelTelefon = personel.PersonelTelefonNo;
            yoneticiTamAd(id, personel, personelVM);
            personelVM.Departman = _departman.SelectByID(personel.DepartmanID).DepartmanAdi;
            return personelVM;
        }

        public Dictionary<int, string> personelTamAd()
        {
            var personelList = _personel.SelectList();
            var tamAdList = new Dictionary<int, string>();
            tamAdList.Add(0, "Yönetici Seçiniz");
            foreach (var personel in personelList)
            {
                tamAdList.Add(personel.PersonelID, (personel.PersonelAdi + " " + personel.PersonelSoyadi));
            }
            return tamAdList;
        } //Yönetici Dropdown Listesi için Dictionary döndüren metot

        public void yoneticiTamAd(int id, Personel personel, PersonelVM personelVM)
        {

            if (personel.YoneticiID != 0)
            {
                personelVM.Yonetici = _personel.SelectByID(personel.YoneticiID).PersonelAdi + " " + _personel.SelectByID(personel.YoneticiID).PersonelSoyadi;
            }
            else
            {
                personelVM.Yonetici = "Yönetici Yok";
            }
        }
    }
}