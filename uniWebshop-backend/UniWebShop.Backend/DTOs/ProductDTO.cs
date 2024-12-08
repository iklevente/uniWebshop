using UniWebShop.DataAccess.Models;
using System.Diagnostics.CodeAnalysis;

namespace UniWebShop.Backend.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; init; }
        public required string Title { get; set; }
        public string? Body { get; set; }
        public required int Price { get; set; }
        public string? Category { get; set; }
        public string[] Tags { get; set; }
        public byte[]? ImageData { get; set; }

        [SetsRequiredMembers]
        public ProductDTO(Product product)
        {
            Id = product.Id;
            Title = product.Title;
            Body = product.Body;
            Price = product.Price;
            Category = product.Category;
            Tags = product.Tags;
            ImageData = product.ImageData;
        }
    }
}
