using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIForKeeper.Models;

namespace WebAPIForKeeper.Controllers
{
    public class AuthController : Controller
    {
        /// <summary>
        /// Объект для хранения данных авторизованного пользователя
        /// </summary>
        public static Visitors AuthUser;
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Получение данных для авторизации введенных пользователем
        /// </summary>
        /// <param name="dataAuthorization">Данные, введенные пользователем</param>
        /// <returns>При вверных данных осуществляет авторизацию, иначе - ошибка</returns>
        [System.Web.Http.HttpPost]
        public ActionResult Authorization(DataAuthorization dataAuthorization)
        {
            try
            {
                Data_Authorization datAuth = BaseConnect.baseModel.Data_Authorization.FirstOrDefault(x => x.Login == dataAuthorization.Login && x.Password == dataAuthorization.Password);

                if (datAuth == null)
                {
                    return HttpNotFound();
                }
                AuthUser = BaseConnect.baseModel.Visitors.FirstOrDefault(x => x.ID_Visitor == datAuth.ID_User);
                ChoiceTypeVisitController a = new ChoiceTypeVisitController();
                return Redirect("~/ChoiceTypeVisit/TypeVisit");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
            
            
        }

        //public ActionResult LogIn()
    }
}