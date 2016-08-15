namespace AcadPropsEditor.Plugin.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity[] GetAll();
        void Update(TEntity entity);
    }
}
