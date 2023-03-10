using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIForKeeper.Models
{
    public class Visitior
    {
        public Visitior(Visitors visitors) //можно назывть моделью, чтобы не путать
        {
            ID_Visitor = visitors.ID_Visitor;
            Firstname = visitors.Firstname;
            Surname = visitors.Surname;
            Patronymic = visitors.Patronymic;
            Telephone = visitors.Telephone;
            Email = visitors.Email;
            Birthday = visitors.Birthday;
            Seria = visitors.Seria;
            Number = visitors.Number;
        }

        public int ID_Visitor { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> Seria { get; set; }
        public Nullable<int> Number { get; set; }
    }

}