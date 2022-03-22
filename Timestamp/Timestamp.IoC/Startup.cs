using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timestamp.App.Stock.Interface;
using Timestamp.App.Stock.Service;
using Timestamp.CrossCutting;
using Timestamp.CrossCutting.Interface;
using Timestamp.Infra.MongoDb.Stock;

namespace Timestamp.IoC
{
    public class Startup
    {
        public static void Builder(IServiceCollection _services, IConfiguration configuration)
        {
            _services.AddSingleton<IMongoDbConfig, MongoDbConfig>();

            //Service
            _services.AddSingleton<IStockService, StockService>();

            //Repositorio
            _services.AddSingleton<IStockRepository, StockRepository>();
            
        }
    }
}
