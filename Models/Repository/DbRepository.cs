﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Community2._0.Models.Entities;
using Community2._0.Models.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Community2._0.Models.Repository
{
    /// <summary>
    /// Класс, который используется для работы с БД через EF Core
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;

        public DbRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateManyAsync(List<TEntity> entity)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
        }
    }
}