using Community2._0.Models.Entities;

namespace Community2._0.Models.Repository
{
    public sealed class AccountRepository : DbRepository<AccountEntity>
    {
        public AccountRepository(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}