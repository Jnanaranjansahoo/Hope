using Hope.Data;
using Hope.Repository.IRepository;

namespace Hope.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IPhotoRepository Photo { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Photo = new PhotoRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
