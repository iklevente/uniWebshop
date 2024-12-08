using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniWebShop.DataAccess.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public required string Title { get; set; }

        public string? Body { get; set; }

        [Required]
        public required int Price { get; set; }

        public string? Category { get; set; }

        //[NotMapped]
        public string[]? Tags { get; set; }
        [Required]
        public byte[]? ImageData { get; set; }

        public Product(string title, string imageData, int price, string body, string category, string[] tags)
        {
            Id = Guid.NewGuid();
            Title = title;
            Price = price;
            Body = body;
            Category = category;
            Tags = tags;
            Console.WriteLine(imageData);
            ImageData = Convert.FromBase64String(imageData);
            Console.WriteLine("-----------------");
            Console.WriteLine(ImageData);
        }
        public Product(string title, string imageData, int price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Price = price;
            Console.WriteLine(imageData);
            ImageData = Convert.FromBase64String(imageData);
            Console.WriteLine("-----------------");
            Console.WriteLine(ImageData);
        }
        /// <summary>
        /// Only for EF
        /// </summary>
        public Product() { }

        public override bool Equals(object? obj)
        {
            return obj is Product product &&
                GetHashCode() == product.GetHashCode() &&
                Id.Equals(product.Id) &&
                Title == product.Title &&
                ImageData == product.ImageData &&
                Body == product.Body &&
                Price == product.Price &&
                Category == product.Category &&
                Tags == product.Tags;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, ImageData, Body, Price, Category, Tags);
        }
    }
}