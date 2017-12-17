using StokTakip.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.BLL.Repositories
{
    public class RepositoryBaseMultiKey<T, ID1,ID2> where T : class
    {

        protected internal static MyContext dbContext;

        public List<T> GetAll()
        {
            dbContext = new MyContext();
            return dbContext.Set<T>().ToList();
        }
        public T GetByID(ID1 id1,ID2 id2)
        {

            dbContext = new MyContext();
            return dbContext.Set<T>().Find(id1,id2);
        }
        public virtual int Insert(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Delete(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Update()
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

