using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YKT.Exam.DAL
{
    public class BaseDal<T> where T : class, new()
    {
        //Db.Set<T>()方法使用


        //  OAEntities Db = new OAEntities();
        public DbContext Db = DAL.DBContextFactory.CreateDbContext();   //创建线程内唯一上下文实例

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return Db.SaveChanges() > 0;

        }

        public void Update<T>(T t) where T : class, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Deleted;

            return Db.SaveChanges() > 0;   

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return Db.SaveChanges() > 0;

        }

        /// <summary>
        /// 查询过滤
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
          
            return Db.Set<T>().Where<T>(whereLambda);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)  //升序
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else  //降序
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}
