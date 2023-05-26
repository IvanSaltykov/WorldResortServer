using Entities.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class MongoDbContext<TEntity> : IDbContext<TEntity> where TEntity : BaseModel
    {
        public MongoDbContext(IMongoDatabase database, string collection)
        {
            Database = database;
            Collection = collection;
        }

        protected IMongoDatabase Database { get; }
        protected string Collection { get; }

        public Task Create(TEntity model)
        {
            model.Id = Guid.NewGuid();
            return Database.GetCollection<TEntity>(Collection).InsertOneAsync(model);
        }

        public Task Delete(TEntity model)
        {
            return Database.GetCollection<TEntity>(Collection)
            .DeleteOneAsync(item => item.Id == model.Id);
        }

        public Task Update(TEntity model)
        {
            return Database.GetCollection<TEntity>(Collection)
            .FindOneAndReplaceAsync(item => item.Id == model.Id, model);
        }
    }
}
