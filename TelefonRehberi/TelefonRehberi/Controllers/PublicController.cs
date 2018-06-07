using System.Web.Mvc;
using TelefonRehberi.Methods;
using TelefonRehberi.Models;

namespace TelefonRehberi.Controllers
{
    public class PublicController : Controller
    {
        private GenericCrudMethod<Departman> _departman = null;
        private GenericCrudMethod<Personel> _personel = null;
        private RehberViewMethods _rehberView = null;

        public PublicController()
        {
            _rehberView = new RehberViewMethods();
            _departman = new GenericCrudMethod<Departman>();
            _personel = new GenericCrudMethod<Personel>();
        }

        public ActionResult AnaSayfa()
        {
            return View();
        }

        public ActionResult PersonelListesi()
        {
            return View(_personel.SelectList());
        }

        public ActionResult PersonelDetay(int id)
        {
            return View(_rehberView.personelView(id));
        }
    }
}