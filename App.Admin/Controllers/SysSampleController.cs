using App.Common;
using App.IBLL;
using App.Models.Sys;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
        public ActionResult Index()
        {       
            return View();
        }

        /// <summary>
        /// POST: /SysSample/GetList
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
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

        #region 创建
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(SysSampleModel model)
        {
            if (m_BLL.Create(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 修改
        public ActionResult Edit(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public JsonResult Edit(SysSampleModel model)
        {
            if (m_BLL.Edit(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 详细
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }
        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(id))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
