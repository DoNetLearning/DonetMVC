using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL;
using App.IBLL;
using App.Models;
using App.Models.Sys;
using App.Common;
using Unity.Attributes;

namespace App.Admin.Controllers
{
    public class SysSampleController : Controller
    {

        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

        /// <summary>
        /// GET: /SysSample/
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        public ActionResult Index(GridPager pager)
        {
            List<SysSampleModel> list = m_BLL.GetList(ref pager);
            return View(list);
        }

        /// <summary>
        /// POST: /SysSample/GetList
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(GridPager pager)
        {
            List<SysSampleModel> list = m_BLL.GetList(ref pager);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysSampleModel()
                        {

                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime,

                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
