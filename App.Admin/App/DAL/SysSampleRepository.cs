using System;
using System.Linq;
using System.Data;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class SysSampleRepository : ISysSampleRepository, IDisposable
    {
        /// <summary>
        /// 获取列表
        ///
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<SysSample>GetList(AppsDBContainer db)
        {
            IQueryable<SysSample> list = db.SysSample.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        ///
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
        public int Create(SysSample entity)
        {
            using (AppsDBContainer db = new AppsDBContainer())
            {
                db.Set<SysSample>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 删除一个实体
        ///
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">主键ID</param>
        public int Delete(string id)
        {
            using (AppsDBContainer db = new AppsDBContainer())
            {
                SysSample entity = db.SysSample.SingleOrDefault(a => a.Id == id);
                db.Set<SysSample>().Remove(entity);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 修改一个实体
        ///
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
        public int Edit(SysSample entity)
        {
            using (AppsDBContainer db = new AppsDBContainer())
            {
                db.Set<SysSample>().Attach(entity);
                db.Entry<SysSample>(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获得一个实体
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public SysSample GetById(string id)
        {
            using (AppsDBContainer db = new AppsDBContainer())
            {
                return db.SysSample.SingleOrDefault(a => a.Id == id);
            }
        }
        /// <summary>
        /// 判断一个实体是否存在
        ///
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            using (AppsDBContainer db = new AppsDBContainer())
            {
                SysSample entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
