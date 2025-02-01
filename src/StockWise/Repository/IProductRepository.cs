using StockWise.Models;
using StockWise.Dto;

namespace StockWise.Repository;

public interface IProductRepository
{
    IEnumerable<Product> Get();
    Product Add(InsertProductDto product);

    Product Update(InsertProductDto product, int id);

    void Delete(int id);
}