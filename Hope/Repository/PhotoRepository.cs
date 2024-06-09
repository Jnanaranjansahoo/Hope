using Hope.Data;
using Hope.Models;
using Hope.Repository.IRepository;
using System.Linq.Expressions;

namespace Hope.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        private ApplicationDbContext _db;
        public PhotoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Photo obj)
        {
            var objFromDb = _db.Photos.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
