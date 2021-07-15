using Community2._0.Models.Entities;

namespace Community2._0.Models.Repository
{
    public sealed class PostRepository : DbRepository<PostEntity>
    {
        public PostRepository(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}