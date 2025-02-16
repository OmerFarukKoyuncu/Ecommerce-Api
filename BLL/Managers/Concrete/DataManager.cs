using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Category;
using Bogus;
using DAL.Data;
using DAL.Entities;

namespace BLL.Managers.Concrete
{
    public class DataManager
    {
        private readonly AppDbContext _context;

        public DataManager(AppDbContext context)
        {
            _context = context;
        }
        public void GenerateCategory(int count)
        {
            var categories = new Faker<Category>("tr")
                                .RuleFor(c => c.Name, f => f.Commerce.Department()) // Geçerli bir string üret
                                .RuleFor(c => c.Description, f => f.Lorem.Sentence()) // Açıklama ekle
                                .Generate(count); // Belirtilen sayıda kategori oluştur

            _context.Categories.AddRange(categories);
            _context.SaveChanges();
        }
        public void GenerateProduct(int count)
        {
            var categoryIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; // Mevcut kategori ID'leri
            var products = new Faker<Product>("tr")
                                .RuleFor(p => p.Name, f => f.Commerce.ProductName()) // Rastgele ürün ismi
                                .RuleFor(p => p.Description, f => f.Lorem.Sentence()) // Açıklama ekle
                                .RuleFor(p => p.Price, f => f.Random.Decimal(10, 1000)) // 10 ile 1000 arasında fiyat
                                .RuleFor(p => p.Stock, f => f.Random.Int(0, 500)) // 0-500 stok miktarı
                                .RuleFor(p => p.PhotoUrl, f => f.Image.PicsumUrl()) // Rastgele resim URL'si
                                .RuleFor(p => p.SellerId, f => f.PickRandom(new[] { 3, 6, 16 })) // Sadece 3, 6 veya 16 seç
                                .RuleFor(p => p.ProductCategories, f =>
                                                                new List<ProductCategory>(
                                                                    f.PickRandom(categoryIds, f.Random.Int(1, 3)) // 1 ila 3 kategori seç
                                                                    .Select(id => new ProductCategory { CategoryId = id }).ToList()
                                                                )
                                       )
                                .Generate(count);

            _context.Products.AddRange(products); // Products tablosuna ekle
            _context.SaveChanges();
        }
    }
}
