using MovieStore.Core.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Data.SubStructure
{
    public interface IRepository<T>
    {
        Task<T> GetByID(Guid id);
        IQueryable<T> Get();
        IQueryable<T> Query(bool isDeleted = false);
        void Add(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }

    public class Repository<T> : IRepository<T>
          where T : BaseEntity
    {
        private MovieStoreDbContext con;

        public Repository(MovieStoreDbContext context)
        {
            con = context;
        }
        public MovieStoreDbContext Context
        {
            get { return con; }
            set { con = value; }

        }
        public virtual async Task<T> GetByID(Guid id)
        {
            return await con.Set<T>().FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }
        public IQueryable<T> Get()
        {
            return con.Set<T>().AsQueryable();
        }
        public virtual void Add(T entity)
        {
            con.Set<T>().Add(entity);
        }
        public virtual void Update(T entity)
        {
            con.Entry(entity).State = EntityState.Modified;
        }
        public IQueryable<T> Query(bool isDeleted = false)
        {
            return con.Set<T>().AsNoTracking().Where(x => !x.IsDeleted || x.IsDeleted == isDeleted);
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            return await con.SaveChangesAsync();
        }
    }
}
