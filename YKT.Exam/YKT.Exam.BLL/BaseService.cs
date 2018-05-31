using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKT.Exam.DAL;

namespace YKT.Exam.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public BaseService()
        {
            SetDal();

       }

        public BaseDal<T> Dal { get; set; }

        public abstract void SetDal();

        public bool Add(T t)
        {
            return Dal.AddEntity(t);
        }
        public bool Delete(T t)
        {
            return Dal.DeleteEntity(t);
        }
        public bool Update(T t)
        {
            return Dal.EditEntity(t);
        }



        //public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        //{
        //    return Dal.GetModels(whereLambda);
        //}

        //public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
        //    Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        //{
        //    return Dal.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        //}
    }
}
