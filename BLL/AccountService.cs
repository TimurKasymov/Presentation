using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Community2._0.BLL.Abstract;
using Community2._0.Models.Entities;
using Community2._0.Models.Repository.Abstract;

namespace Community2._0.BLL
{
    public class AccountService: IService<AccountEntity>
    {
        private IDbRepository<AccountEntity> _repository;

        public AccountService(IDbRepository<AccountEntity> repository)
        {
            this._repository = repository;
        }

        public async Task Create(AccountEntity entity)
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
        public List<AccountEntity> GetAllNOTracking()
        {
            try
            {
                var accs = _repository.GetAll();
                var accList = accs.ToList();
                if (accList == null)
                    throw new Exception("Объект не найден");
                return accList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public AccountEntity Get(string email, string password, bool emailOnly=false)
        {
            try
            {
                var accounts = _repository.Get(e => e.IsActive && e.Email == email && 
                                                    e.Password == password);
                var account = accounts.ToList().FirstOrDefault();
                if (!emailOnly)
                {
                    
                    if (account == null)
                        return null;
                    return account;
                }
                else
                {
                    var accountsEmail = _repository.Get(e => e.IsActive && e.Email == email);
                    var accountEmail = accountsEmail.ToList().FirstOrDefault();
                    if (accountEmail == null)
                        return null;
                    return accountEmail;                        
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public AccountEntity Get(int id)
        {
            try
            {
                var accounts = _repository.Get(e => e.IsActive && e.Id == id);
                var account = accounts.ToList().FirstOrDefault();
                if (account == null)
                    return null;
                return account;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<AccountEntity> GetAllTracking()
        {
            try
            {
                var accounts = _repository.Get(e => e.IsActive);
                var account = accounts.ToList();
                if (account == null)
                    throw new Exception("Объект не найден");
                return account;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Update(AccountEntity entity)
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
                var accounts = _repository.Get(p => p.Id == id && p.IsActive);
                var account = accounts.ToList().FirstOrDefault();
                if (account == null)
                    throw new Exception("Объект не найден");
                _repository.Delete(account);
                await _repository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task CreateMany(List<AccountEntity> entities)
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