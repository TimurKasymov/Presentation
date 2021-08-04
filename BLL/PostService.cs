using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Community2._0.Models.Entities;
using Community2._0.Models.Repository.Abstract;

namespace Community2._0.BLL.Abstract
{
    public class PostService: IService<PostEntity>
    {
        private IDbRepository<PostEntity> _repository;

        public PostService(IDbRepository<PostEntity> repository)
        {
            this._repository = repository;
        }

        public async Task Create(PostEntity entity)
        {
            try
            {
                await _repository.CreateAsync(entity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public PostEntity Get(int id)
        {
            try
            {
                var posts = _repository.Get(e => e.IsActive && e.Id == id);
                var post = posts.ToList().FirstOrDefault();
                if (post == null)
                    throw new Exception("Объект не найден");
                return post;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public PostEntity Get(string email, string password, bool emailOnly)
        {
            throw new NotImplementedException();
        }

        public PostEntity Get(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<PostEntity> GetAllTracking()
        {
            try
            {
                var posts = _repository.Get(e => e.IsActive);
                var post = posts.ToList();
                if (post == null)
                    throw new Exception("Объект не найден");
                return post;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<PostEntity> GetAllNOTracking()
        {
            try
            {
                var posts = _repository.GetAll();
                var post = posts.ToList();
                if (post == null)
                    throw new Exception("Объект не найден");
                return post;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Update(PostEntity entity)
        {
            try
            {
                _repository.Update(entity);
                await _repository.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var posts = _repository.Get(p => p.Id == id && p.IsActive);
                var post = posts.ToList().FirstOrDefault();
                if (post == null)
                    throw new Exception("Объект не найден");
                _repository.Delete(post);
                await _repository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task CreateMany(List<PostEntity> entities)
        {
            try
            {
                await _repository.CreateManyAsync(entities);
                await _repository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}