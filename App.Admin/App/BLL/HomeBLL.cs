using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.IBLL;
using App.IDAL;
using App.Models;
using Unity.Attributes;

namespace App.BLL
{
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }

        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(moduleId);
        }
    }
}