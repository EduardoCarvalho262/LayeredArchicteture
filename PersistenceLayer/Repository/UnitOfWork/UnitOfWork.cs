using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Context;
using PersistenceLayer.Dao;

namespace PersistenceLayer.Repository.UnitOfWork;

public class UnitOfWork : IDisposable
{
    private readonly UsuarioContexto context = new UsuarioContexto(new DbContextOptions<UsuarioContexto>());
    private GenericRepository<UsuarioDao> usuarioRepository;
    private bool disposed = false;
    
    public GenericRepository<UsuarioDao> UsuarioRepository
    {
        get
        {
            if (this.usuarioRepository == null)
            {
                this.usuarioRepository = new GenericRepository<UsuarioDao>(context);
            }
            return this.usuarioRepository;
        }
    }
    public void Save()
    {
        context.SaveChanges();
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}