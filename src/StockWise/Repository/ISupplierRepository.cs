using StockWise.Models;
using StockWise.Dto;

namespace StockWise.Repository;

public interface ISupplierRepository
{
    IEnumerable<Supplier> GetSuppliers();
    Supplier AddSupplier(SupplierDtoInput supplier);

    Supplier UpdateSupplier(SupplierDtoInput supplier, int id);

    void DeleteSupplier(int id);
}