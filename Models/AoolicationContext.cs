using Community2._0.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Community2._0.Models
{
    public sealed class ApplicationContext : DbContext
    {
        DbSet<AccountEntity> Accounts { get; set; }
        DbSet<PostEntity> Posts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}