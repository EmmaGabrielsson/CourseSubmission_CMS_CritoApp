using Crito.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Crito.Repositories;

public abstract class Repo<Entity> where Entity : class
{
    private readonly DataContext _dataContext;
    protected Repo(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public virtual async Task<Entity> AddDataAsync(Entity entity)
    {
        try
        {
            await _dataContext.Set<Entity>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    public virtual async Task<Entity> GetDataAsync(Expression<Func<Entity, bool>> expression)
    {
        try
        {
            var entity = await _dataContext.Set<Entity>().FirstOrDefaultAsync(expression);
            return entity!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    public virtual async Task<IEnumerable<Entity>> GetAllDataAsync()
    {
        try
        {
            return await _dataContext.Set<Entity>().ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }
    public virtual async Task<IEnumerable<Entity>> GetAllDataAsync(Expression<Func<Entity, bool>> expression)
    {
        try
        {
            return await _dataContext.Set<Entity>().Where(expression).ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    public virtual async Task<Entity> UpdateDataAsync(Entity entity)
    {
        try
        {
            _dataContext.Set<Entity>().Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    public virtual async Task<bool> RemoveDataAsync(Entity entity)
    {
        try
        {
            _dataContext.Set<Entity>().Remove(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false!;
    }
}
