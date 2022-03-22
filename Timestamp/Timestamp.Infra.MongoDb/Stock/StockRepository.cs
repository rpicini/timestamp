using MongoDB.Driver;
using System.Threading.Tasks;
using Timestamp.App.Stock.Entity;
using Timestamp.App.Stock.Interface;
using Timestamp.CrossCutting.Interface;

namespace Timestamp.Infra.MongoDb.Stock
{
    public class StockRepository : IStockRepository
    {
        private readonly IMongoCollection<Product> _stock;

        public StockRepository(IMongoDbConfig mongoDbConfig)
        {
            var client = new MongoClient(mongoDbConfig.GetConnectionBase);
            var database = client.GetDatabase("Timestamp");
            _stock = database.GetCollection<Product>("Stock");
        }

        public async Task DeleteAsync(int id) => await _stock.DeleteOneAsync(a => a.Id == id);

        public async Task<Product> GetByIdAsync(int id) => await _stock.Find(a => a.Id == id).SingleOrDefaultAsync();

        public async Task InsertAsync(Product inputArgs) => await _stock.InsertOneAsync(inputArgs);

        public async Task UpdateAsync(int primaryKey, Product inputArgs) => await _stock.ReplaceOneAsync(a => a.Id == primaryKey, inputArgs); 
    }
}
