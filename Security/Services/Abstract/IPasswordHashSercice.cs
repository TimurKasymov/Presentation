namespace Community2._0.Security.Services.Abstract
{
    public interface IPasswordHashSercice
    {
        public string HashPassword(string password);
    }
}