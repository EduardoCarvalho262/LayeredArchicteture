using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Context;

namespace PersistenceLayer.Repository;

public class GenericRepository<TEntity> where TEntity : class
{
    private UsuarioContexto context;
    private DbSet<TEntity> dbSet;

    public GenericRepository(UsuarioContexto context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return dbSet.ToList();
    }

    public virtual TEntity GetById(object id)
    {
        return dbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
        dbSet.Add(entity);
    }

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }
}