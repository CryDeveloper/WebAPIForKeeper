using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIForKeeper.Models;

namespace WebAPIForKeeper
{
    /// <summary>
    /// Создание связи с БД
    /// </summary>
    public class BaseConnect
    {
        public static ATaran_KII_DemExEntities baseModel = new ATaran_KII_DemExEntities();
    }
}