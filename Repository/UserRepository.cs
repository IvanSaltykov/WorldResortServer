using Entities;
using Entities.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : MongoDbContext<UserModel>, IUserRepository
    {
        public UserRepository(IMongoDatabase database) : base(database, "userCollection")
        {
        }

        public Task<UserModel> GetByEmailAsync(string email)
        {
            return Database.GetCollection<UserModel>(Collection)
            .Find(x => x.Email == email.ToLowerInvariant())
            .FirstOrDefaultAsync();
        }

        public async Task<UserModel> GetUserInfo(Guid userId)
        {
            return Database.GetCollection<UserModel>(Collection)
            .Find(x => x.Id == userId).FirstOrDefault();
        }
    }

    public interface IUserRepository : IDbContext<UserModel>
    {
        Task<UserModel> GetByEmailAsync(string email);
        Task<UserModel> GetUserInfo(Guid userId);
    }
}
