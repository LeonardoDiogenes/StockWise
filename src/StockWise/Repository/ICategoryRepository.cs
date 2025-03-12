using StockWise.Models;
using StockWise.Dto;

namespace StockWise.Repository;

public interface ICategoryRepository
{
    IEnumerable<Category> Get();
    Category Add(InsertCategoryDto category);

    Category Update(InsertCategoryDto category, int id);

    void Delete(int id);
}