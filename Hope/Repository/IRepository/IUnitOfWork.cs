namespace Hope.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPhotoRepository Photo { get; }
        void Save();
    }
}
