using MongoDB.Driver;
using $safeprojectname$.Settings;

namespace $safeprojectname$.Data.Contexts
{
    public class MongoDbContext<TEntity> where TEntity : class
    {
        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {

            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoSettings.ConnectionString));
            if (MongoSettings.IsSSL)
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase(MongoSettings.DatabaseName);

        }

        public IMongoCollection<TEntity> Collection
        {
            get
            {
                return _database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }
    }
}
