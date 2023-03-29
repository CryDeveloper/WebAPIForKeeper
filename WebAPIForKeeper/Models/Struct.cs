using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIForKeeper.Models
{
    public class Struct
    {
        //public Struct(DateTime start_Date, DateTime? end_Date, string target, string name_Division, string surnameEmp, string firstnameEmp, string patronymicEmp, string firstname, string surname, string patronymic, string telephone, string email, string organization, string value, DateTime? birthday, int? seria, int? number)
        //{
        //    Applications applications = new Applications(); //создание заявки
        //    applications.Start_Date = start_Date; //добавление полей заявки
        //    applications.End_Date = end_Date;

        //    Name_Division = name_Division;
        //    //ниже получение определенной записи таблицы по входным данным
        //    Employees employees = BaseConnect.baseModel.Employees.FirstOrDefault(x => surnameEmp == x.Surname && firstnameEmp == x.Firstname && patronymicEmp == x.Patronymic);
        //    Division division = BaseConnect.baseModel.Division.FirstOrDefault(x => x.Name_Division == Name_Division);
        //    Visitors visitors = BaseConnect.baseModel.Visitors.FirstOrDefault(x => surname == x.Surname && firstname == x.Firstname && patronymic == x.Patronymic);
        //    Firstname = firstname;
        //    Surname = surname;
        //    Patronymic = patronymic;
        //    Telephone = telephone;
        //    Email = email;
        //    Birthday = birthday;
        //    Seria = seria;
        //    Number = number;
        //    BaseConnect.baseModel.Applications.Add(applications);
        //    BaseConnect.baseModel.SaveChanges();
        //}

        public System.DateTime Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public string Target { get; set; }
        public string Name_Division { get; set; }
        public string SurnameEmp { get; set; }
        public string FirstnameEmp { get; set; }
        public string PatronymicEmp { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Value { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> Seria { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<int> id_division { get; set; }
    }
}