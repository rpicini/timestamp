using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timestamp.App.Stock.Entity;

namespace Timestamp.App.Stock.Interface
{
    public interface IStockService
    {
        Task DeleteAsync(int id);
        Task UpdateAsync(int primaryKey, Product inputArgs);
        Task<Product> GetByIdAsync(int id);
        Task InsertAsync(Product inputArgs);
    }
}
