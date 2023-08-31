using FnacDarty.JobInterview.Stock.InterfaceRepositories;
using System;

namespace FnacDarty.JobInterview.Stock
{
    public class Product : IEntity
    {
        private readonly IProductRepository _productRepo;

        public Product()
        {
            
        }

        public Product(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public Product(string productName, string description)
        {
            ProductName = productName;
            Description = description;
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }


        public string GetProductStartStringValidation(string name)
        {
            if (!name.StartsWith("EAN"))
            {
                return $"Product must start with EAN";
            }

            return name;
        }

        public string GetProductLengthValidation(string name)
        {
            if (name.Length == 8)
            {
                
            }

            return "Product should be equal to 8 characters";
        }

        //To Add new products
        public void AddNewProduct(Product entity)
        {
            //Validation to check if product name starts with EAN
            GetProductStartStringValidation(entity.ProductName);

            //Validation to check if product name's length is 8 or not
            GetProductLengthValidation(entity.ProductName);

            //Save product to database
            _productRepo.AddProductAsync(entity);
        }        
    }
}
