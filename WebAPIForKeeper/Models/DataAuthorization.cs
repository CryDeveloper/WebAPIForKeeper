using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIForKeeper.Models
{
    public class DataAuthorization
    {
        
        public int ID_Auth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> ID_User { get; set; }
    }
}