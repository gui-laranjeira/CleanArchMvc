using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product name", "this is a product", 3.141592m,  10, "this is a image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with negative ID")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product name", "this is a product", 3.141592m, 10, "this is a image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id must be a positive integer.");
        }

        [Fact(DisplayName = "Create Product with short name")]
        public void CreateProduct_ShortNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "this is a product", 3.141592m, 10, "this is a image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name must have 3 or more characters.");
        }

        [Fact(DisplayName = "Create Product with no name")]
        public void CreateProduct_NoNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, string.Empty, "this is a product", 3.141592m, 10, "this is a image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }


        [Fact(DisplayName = "Create Product with short description")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product name", "this", 3.141592m, 10, "this is a image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description must have 5 or more characters.");
        }

        [Fact(DisplayName = "Create Product with no description")]
        public void CreateProduct_NoDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product name", string.Empty, 3.141592m, 10, "this is a image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required.");
        }


        [Fact(DisplayName = "Create Product with negative price")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product name", "this is a product", -3.141592m, 10, "this is a image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value. Price must be a positive decimal value.");
        }

        [Fact(DisplayName = "Create Product with negative stock value")]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product name", "this is a product", 3.141592m, -10, "this is a image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value. Stock must be a positive integer value.");
        }


        [Fact(DisplayName = "Create Product with big image value")]
        public void CreateProduct_LongImageValue_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product name", "this is a product", 3.141592m, 10, "this is a imagethis is " +
                "a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is " +
                "a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is a imagethis is ");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. Image maximum length is 250 characters.");
        }

        [Fact(DisplayName = "Create Product with null image value -> No domain exception")]
        public void CreateProduct_NullImageValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product name", "this is a product", 3.141592m, 10, null);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with null image value -> No null reference exception")]
        public void CreateProduct_NullImageValue_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product name", "this is a product", 3.141592m, 10, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
