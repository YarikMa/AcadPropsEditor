namespace AcadPropsEditor.Plugin.DataAccess
{
    public interface IShapeRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        TEntity[] GetEntitiesByLayerName(string layerName);
    }
}
