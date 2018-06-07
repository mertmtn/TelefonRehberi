using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using TelefonRehberi.CustomException;
using TelefonRehberi.Methods;
using TelefonRehberi.Models;
using TelefonRehberi.ViewModels;

namespace TelefonRehberi.Controllers
{
    public class AdminController : Controller
    {

        private GenericCrudMethod<Departman> _departman = null;
        private GenericCrudMethod<Personel> _personel = null;
        private GenericCrudMethod<Login> _adminLogin = null;
        private RehberViewMethods _rehberView = null;
        private CheckMethods _check = null;
        private LoginController _login = null;

        public AdminController()
        {
            _rehberView = new RehberViewMethods();
            _departman = new GenericCrudMethod<Departman>();
            _personel = new GenericCrudMethod<Personel>();
            _check = new CheckMethods();
            _login = new LoginController();
            _adminLogin = new GenericCrudMethod<Login>();

        }

        public ActionResult AnaSayfa()
        {
            return View();
        }



        #region Departman
        public ActionResult DepartmanListesi()
        {
            return View(_departman.SelectList());
        }

        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _check.checkDepartman(departman);
                    return RedirectToAction("DepartmanListesi");
                }
                return View();
            }
            catch (DepartmanException e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        public ActionResult DepartmanGuncelle(int id)
        {
            return View(_departman.SelectByID(id));
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman departman, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _check.checkDepartman(departman, id);
                    return RedirectToAction("DepartmanListesi");
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }

        }


        public ActionResult DepartmanSil(int id)
        {
            return View(_departman.SelectByID(id));
        }

        [HttpPost]
        public ActionResult DepartmanSil(Departman departman, int id)
        {
            try
            {
                _check.checkCalısanDepartman(id);
                return RedirectToAction("DepartmanListesi");
            }
            catch (DepartmanException e)
            {
                ViewBag.Message = e.Message;
                return View();
            }


        }

        public ActionResult DepartmanDetay(int id)
        {
            return View(_departman.SelectByID(id));
        }

        #endregion

        #region Personel

        public ActionResult PersonelEkle()
        {
            ViewBag.Departmanlar = _departman.SelectList();
            ViewBag.Personeller = _rehberView.personelTamAd();
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personel.Ekle(personel);
                    return RedirectToAction("PersonelListele");
                }
                ViewBag.Departmanlar = _departman.SelectList();
                ViewBag.Personeller = _rehberView.personelTamAd();
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        public ActionResult PersonelListele()
        {
            return View(_personel.SelectList());
        }

        public ActionResult PersonelDetay(int id)
        {
            return View(_rehberView.personelView(id));
        }

        public ActionResult PersonelGuncelle(int id)
        {
            ViewBag.Departmanlar = _departman.SelectList();
            ViewBag.Personeller = _rehberView.personelTamAd();
            return View(_personel.SelectByID(id));
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    personel.PersonelID = id;
                    _personel.Guncelle(personel);
                    return RedirectToAction("PersonelDetay", new RouteValueDictionary(new { controller = "Admin", action = "PersonelDetay", Id = id }));
                }
                ViewBag.Departmanlar = _departman.SelectList();
                ViewBag.Personeller = _rehberView.personelTamAd();
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }

        }

        public ActionResult PersonelSil(int id)
        {
            return View(_rehberView.personelView(id));
        }

        [HttpPost]
        public ActionResult PersonelSil(PersonelVM personel, int id)
        {
            try
            {
                _check.checkPersonelYonetici(id);
                return RedirectToAction("PersonelListele");
            }
            catch (YoneticiException e)
            {
                ViewBag.Message = e.Message;
                return View();
            }

        }

        #endregion

        public ActionResult SifreDegistir()
        {
            return View();

        }
        [HttpPost]
        public ActionResult SifreDegistir(LoginVM newLogin)
        {
            try
            {
                var guncellenecekLogin = _adminLogin.SelectByID(1); 

                if (ModelState.IsValid)
                {
                    if (newLogin.Password == newLogin.ConfirmPassword)
                    {
                        guncellenecekLogin.Password = LoginController.MD5Sifrele(newLogin.Password);
                        _adminLogin.Guncelle(guncellenecekLogin);
                        Session.Abandon();
                        return RedirectToAction("Giris", "Login");
                    }
                    else
                    {
                        throw new LoginException("Şifreler Eşleşmiyor...");
                    }                    
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }



        public JsonResult getPersonelList()
        {
            var personelList = from p in _personel.SelectList()
                               join d in _departman.SelectList()
                               on p.DepartmanID equals d.DepartmanID
                               select new
                               {
                                   p.PersonelAdi,
                                   p.PersonelSoyadi,
                                   p.PersonelTelefonNo,
                                   p.PersonelID,
                                   d.DepartmanAdi
                               };
            return Json(personelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDepartmanList()
        {
            return Json(_departman.SelectList(), JsonRequestBehavior.AllowGet);
        }

    }
}