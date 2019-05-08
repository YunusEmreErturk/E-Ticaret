using MVC_CircloidTemplate.AppClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_CircloidTemplate.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
            ViewBag.UserSelected = "selected";
        }
        // GET: User
        public ActionResult Index()
        {
            // Veritabanındaki tüm kullanıcıları çekip users isimli Collection'da toplayacak.
            MembershipUserCollection users = Membership.GetAllUsers();
            return View(users);
        }
        public ActionResult AddUser()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddUser(UserClass uc)
        {
            Membership.CreateUser(uc.UserName, uc.Password, uc.Email, uc.PasswordQuestion, uc.PasswordAnswer, true, out MembershipCreateStatus status);

            string createMessage = "";
            switch (status)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    createMessage = "Gecersiz Kullanici adi";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    createMessage = "Gecersiz Şifre";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    createMessage = "Gecersiz Gizli soru";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    createMessage = "Gecersiz gizi cevap";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    createMessage = "Gecersiz email";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    createMessage = "Kullanılmış Kullanici adi";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    createMessage = "Kullanışmış email adresi";
                    break;
                case MembershipCreateStatus.UserRejected:
                    createMessage = "Kullanılmış Engellenmiş";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    createMessage = "Geçersiz kullanıcı anahtarı";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    createMessage = "Tekrarlanmış kullanıcı anahtarı";
                    break;
                case MembershipCreateStatus.ProviderError:
                    createMessage = "Saglayici hatasi";
                    break;
                default:
                    break;       
            }
            ViewBag.createMessage = createMessage;
            if (createMessage == "")
            {
                return RedirectToAction("Index");
            
            }
            else
            {
                return View();
            }

            
        }
    }
}