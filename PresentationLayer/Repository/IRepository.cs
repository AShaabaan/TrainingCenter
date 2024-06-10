namespace PresentationLayer.Repository
{
    public interface IRepository <T> 
    {
        Task <List<T> >GetAll();
        Task <T> GetByID (int id);
        Task<T> Update (int id ,T entity);
        void Delete (int id);
    }
}
