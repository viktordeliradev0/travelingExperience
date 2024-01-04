
using Microsoft.EntityFrameworkCore;
using travelingExperience.DbConnetion;

namespace travelingExperience.Repository
{
    public class CrudRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public CrudRepository()
        {
            context = new AppDbContext();
        }
        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void Delete(int Id)
        {
            T entity = GetById(Id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }


    }
}
