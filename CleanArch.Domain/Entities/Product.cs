using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Product : Entity
    {
        public Product(int id, string name, string description, decimal price, int stock, string image) {

            DomainExceptionValidation.When(id < 3, "Invalid Id.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; } = string.Empty;

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.");

            DomainExceptionValidation.When(price < 0, "Invalide price");

            DomainExceptionValidation.When(stock < 0, "Invalid stock");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image.");

            Name = name;
            Description = description;
            Price = price; 
            Stock = stock;
            Image = image;
        }


    }
}