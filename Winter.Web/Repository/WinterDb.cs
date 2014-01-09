using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using Winter.Web.Models;

namespace Winter.Web.Repository
{
    public class WinterDb : IdentityDbContext<ApplicationUser>, IWinterDb
    {
        public WinterDb()
            : base("DefaultConnection")
        { }

        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<StoryType> StoryTypes { get; set; }

        IQueryable<T> IWinterDb.Query<T>()
        {
            return Set<T>();
        }

        void IWinterDb.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IWinterDb.Update<T>(T entity)
        {
            Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        void IWinterDb.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void IWinterDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}