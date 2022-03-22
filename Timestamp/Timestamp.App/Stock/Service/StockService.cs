using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timestamp.App.Stock.Entity;
using Timestamp.App.Stock.Interface;

namespace Timestamp.App.Stock.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository = null;

        public StockService(IStockRepository acessoRepository)
        {
            _stockRepository = acessoRepository;
        }

        public async Task DeleteAsync(int id)
        {
            await _stockRepository.DeleteAsync(id);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _stockRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Product inputArgs)
        {
            await _stockRepository.InsertAsync(inputArgs);
        }

        public async Task UpdateAsync(int primaryKey, Product inputArgs)
        {
            await _stockRepository.UpdateAsync(primaryKey, inputArgs);
        }
    }
}
