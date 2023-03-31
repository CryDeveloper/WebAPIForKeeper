using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Xml.Linq;
using WebAPIForKeeper.Models;

namespace WebAPIForKeeper.Controllers
{
    public class StructureController : Controller
    {
    
        [System.Web.Http.HttpGet]
        public ActionResult StructurePost()
        {
            ViewBag.Division = new SelectList( BaseConnect.baseModel.Division.ToList(),  "ID_Division", "Name_Division");
            return View();
        }

        [System.Web.Http.HttpGet]
        public ActionResult GetDivisionEmployeesSelect(int id)
        {
            var employees = BaseConnect.baseModel.Employees.Where(e => e.ID_Division == id);

            if (employees == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DivisionEmployeesSelectPartial", employees);
        }

        [System.Web.Http.HttpPost]
        public string StructurePostFunction(Struct structs) /*structs - данные приходящие с формочки. стоит учитывать id*/
        {
            Applications applications = new Applications(); //создание заявки
            applications.Start_Date = structs.Start_Date; //добавление полей заявки
            applications.End_Date = structs.End_Date;
            applications.Target = structs.Target;
            //ниже получение определенной записи таблицы по входным данным
            Employees employees = BaseConnect.baseModel.Employees.FirstOrDefault(x => structs.SurnameEmp == x.Surname && structs.FirstnameEmp == x.Firstname && structs.PatronymicEmp == x.Patronymic);
            Visitors visitors = BaseConnect.baseModel.Visitors.FirstOrDefault(x => structs.Surname == x.Surname && structs.Firstname == x.Firstname && structs.Patronymic == x.Patronymic);
            applications.ID_Visitors = visitors.ID_Visitor;
            applications.ID_Division = (int)structs.id_division;
            applications.ID_Employe_Division = employees.ID_Employee;
            applications.ID_Status = 1;
            BaseConnect.baseModel.Applications.Add(applications);
            BaseConnect.baseModel.SaveChanges();
            return "Данные успешно добавлены";
        }
        [System.Web.Http.HttpPost]
        public string newPost()
        {
            return "Я другой Post";
        }
    }
}
