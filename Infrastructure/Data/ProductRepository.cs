using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class ProductRepository : IProductRepository
  {
    private readonly StoreContext __context;
    public ProductRepository(StoreContext _context)
    {
      __context = _context;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
      return await  __context.ProductBrands.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      return await __context.Products
       .Include(p => p.ProductBrand)
      .Include(p => p.ProductType)
      .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
      return await __context.Products
      .Include(p => p.ProductBrand)
      .Include(p => p.ProductType)
      .ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
      return await  __context.ProductTypes.ToListAsync();
    }
  }
}