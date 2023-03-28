using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIForKeeper.Models;

namespace WebAPIForKeeper.Controllers
{
    public class StructureController : ApiController
    {
        // POST: api/Applications
        [ResponseType(typeof(Struct))]
        public IHttpActionResult PostApplications(Struct structs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Applications applications = new Applications(); //создание заявки
            applications.Start_Date = structs.Start_Date; //добавление полей заявки
            applications.End_Date = structs.End_Date;
            applications.Target = structs.Target;
            //ниже получение определенной записи таблицы по входным данным
            Employees employees = BaseConnect.baseModel.Employees.FirstOrDefault(x => structs.SurnameEmp == x.Surname && structs.FirstnameEmp == x.Firstname && structs.PatronymicEmp == x.Patronymic);
            Division division = BaseConnect.baseModel.Division.FirstOrDefault(x => x.Name_Division == structs.Name_Division);
            Visitors visitors = BaseConnect.baseModel.Visitors.FirstOrDefault(x => structs.Surname == x.Surname && structs.Firstname == x.Firstname && structs.Patronymic == x.Patronymic);
            applications.ID_Visitors = visitors.ID_Visitor;
            applications.ID_Division = division.ID_Division;
            BaseConnect.baseModel.Applications.Add(applications);
            BaseConnect.baseModel.SaveChanges();

            return CreatedAtRoute("DefaultApi", null, structs);
        }
    }
}
