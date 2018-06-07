using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using TelefonRehberi.Models;
using TelefonRehberi.Methods;
using TelefonRehberi.CustomException;

namespace TelefonRehberi.Controllers
{
    public class LoginController : Controller
    {
        private GenericCrudMethod<Login> _adminLogin = null;

        public LoginController()
        {
            _adminLogin = new GenericCrudMethod<Login>();
        }
      
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(Login login)
        {
            try
            {
                var admin = _adminLogin.SelectByID(1);
                if (ModelState.IsValid)
                {
                    if (!(login.Username == admin.Username && MD5Sifrele(login.Password) == admin.Password))
                        throw new LoginException("Bilgilerinizden en az birini hatalı girdiniz...");
                    else
                        Session["AdminOturumu"] = admin;
                        return RedirectToAction("PersonelListele", "Admin");                    
                }
                return View();
            }
            catch (LoginException loginException)
            {
                ViewBag.Message = loginException.Message;
                return View();
            }
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return RedirectToAction("Giris", "Login");
        }


        public static string MD5Sifrele(string sifre)
        {
            // MD5CryptoServiceProvider sınıfına ait bir nesne oluşturduk.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //Parametre olarak gelen veriyi byte dizisine dönüştürdük.
            byte[] dizi = Encoding.UTF8.GetBytes(sifre);
            //dizinin hash'ini hesaplattık.
            dizi = md5.ComputeHash(dizi);
            //Hashlenmiş verileri depolamak için StringBuilder nesnesi oluşturduk.
            StringBuilder sb = new StringBuilder();
            //Her byte'i dizi içerisinden alarak string türüne dönüştürdük.

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürdük.
            return sb.ToString();
        }

    }


}
