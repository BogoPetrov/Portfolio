using Blog_Site.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog_Site.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected BlogSiteDbContext? Context { get; set; }

        protected DbSet<T>? Items { get; set; }

        public BaseRepository()
        {
            Context = new BlogSiteDbContext();
            Items = Context.Set<T>();
        }

        public int Count(Expression<Func<T, bool>> filter = null!)
        {
            IQueryable<T> query = Items!;

            if (filter != null)
                query = query.Where(filter);

            return Items!.Count(filter!);
        }

        public List<T> GetAll(
                        Expression<Func<T, bool>> filter = null!,
                        int page = 1,
                        int itemsPerPage = 10)
        {
            IQueryable<T> query = Items!;

            if (filter != null)
                query = query.Where(filter);

            return query
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return Items!.FirstOrDefault(filter)!;
        }

        public T? GetById(int id)
        {
            return Items!.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(T item)
        {
            Items!.Remove(item);

            Context!.SaveChanges();
        }

        public void Save(T item)
        {
            if(item.Id > 0)
                Items!.Update(item);
            else
                Items!.Add(item);

            Context!.SaveChanges();
        }
    }
}
