using StockWise.Dto;
using StockWise.Models;
namespace StockWise.Repository;

public class SupplierRepository : ISupplierRepository
{
  protected readonly IStockWiseContext _context;

  public SupplierRepository(IStockWiseContext context)
  {
    _context = context;
  }

  public IEnumerable<Supplier> GetSuppliers()
  {
    try
    {
      return _context.Suppliers;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public Supplier AddSupplier(SupplierDtoInput supplier)
  {
    if (_context.Suppliers.Any(s => s.Name == supplier.Name))
    {
      throw new InvalidOperationException("Supplier name already exists");
    }

    try
    {
      _context.Suppliers.Add(
          new Supplier
          {
            Name = supplier.Name,
            Contact = supplier.Contact,
            Address = supplier.Address
          }
      );
      _context.SaveChanges();
      var newSupplier = _context.Suppliers.First(s => s.Name == supplier.Name);
      return newSupplier;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public Supplier UpdateSupplier(SupplierDtoInput supplier, int id)
  {
    var supplierToUpdate = _context.Suppliers.Find(id);
    if (supplierToUpdate == null)
    {
      throw new InvalidOperationException("Supplier not found");
    }

    try
    {
      supplierToUpdate.Name = supplier.Name;
      supplierToUpdate.Contact = supplier.Contact;
      supplierToUpdate.Address = supplier.Address;
      _context.SaveChanges();
      return supplierToUpdate;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public void DeleteSupplier(int id)
  {
    var supplierToDelete = _context.Suppliers.Find(id);
    if (supplierToDelete == null)
    {
      throw new InvalidOperationException("Supplier not found");
    }

    try
    {
      _context.Suppliers.Remove(supplierToDelete);
      _context.SaveChanges();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }


}