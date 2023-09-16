﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Scheduling.Core.Common;
using Scheduling.Core.Repositories;
using Scheduling.Infrastructure.Data;

namespace Scheduling.Infrastructure.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
{
    protected readonly SchedulingContext DbContext;

    protected RepositoryBase(SchedulingContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T?> GetIdByAsync(long id)
    {
        return await DbContext.Set<T>().FindAsync(id) ?? default(T);
    }

    public async Task<T> AddAsync(T entity)
    {
        DbContext.Set<T>().Add(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();
    }
}