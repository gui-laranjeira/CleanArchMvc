﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        #region Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

        #region Constructors
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description,price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id. Id must be a positive integer.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        #endregion


        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;    
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. Name must have 3 or more characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description. Description must have 5 or more characters.");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value. Price must be a positive decimal value.");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock value. Stock must be a positive integer value.");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name. Image maximum length is 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

    }
}
