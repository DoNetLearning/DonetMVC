using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class HomeRepository : IHomeRepository, IDisposable
    {
        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            using (AppsDBContainer db = new AppsDBContainer())
            {
                var menus =
                (
                    from m in db.SysModule
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }

        public void Dispose()
        {
            
        }
    }
}