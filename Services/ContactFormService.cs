using Crito.Contexts;
using Crito.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Crito.Services;

public class ContactFormService
{
    private readonly DataContext _dataContext = new();

    public async Task<ContactFormEntity> AddDataAsync(ContactFormEntity entity)
    {
        try
        {
            await _dataContext.Set<ContactFormEntity>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    public virtual async Task<ContactFormEntity> GetDataAsync(Expression<Func<ContactFormEntity, bool>> expression)
    {
        try
        {
            var entity = await _dataContext.Set<ContactFormEntity>().FirstOrDefaultAsync(expression);
            return entity!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

}
