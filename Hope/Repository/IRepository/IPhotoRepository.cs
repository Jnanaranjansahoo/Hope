using Hope.Models;

namespace Hope.Repository.IRepository
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        void Update(Photo obj);
                                                                                                                                                                                                                                                                          
    }
}
