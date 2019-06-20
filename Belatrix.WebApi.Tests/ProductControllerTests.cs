using Belatrix.WebApi.Controllers;
using Belatrix.WebApi.Repository;
using Belatrix.WebApi.Repository.Postgresql;
using Belatrix.WebApi.Tests.Builder.Data;
using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;



namespace Belatrix.WebApi.Tests
{
    public class ProductControllerTests

    {
        private readonly BelatrixDbContextBuilder _builder;

        public ProductControllerTests()
        {
            _builder = new BelatrixDbContextBuilder();
        }

        [Fact]
        public async Task ProductController_GetProducts_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddTenProducts()
                .Build();

            var repository = new Repository<Models.Product>(db);

            var controller = new ProductController(repository);

            var response = (await controller.GetProducts())
                .Result as OkObjectResult;

            var values = response.Value as List<Models.Product>;

            values.Count.Should().Be(10);
        }

        [Fact]
        public async Task ProductController_CreateProduct_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .Build();

            var repository = new Repository<Models.Product>(db);

            var controller = new ProductController(repository);

            var newProduct = A.New<Models.Product>();
            var response = (await controller.PostProduct(newProduct))
                .Result as OkObjectResult;

            var values = Convert.ToInt32(response.Value);

            values.Should().Be(newProduct.Id);            
        }

        [Fact]
        public async Task ProductController_UpdateProduct_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddTenProducts()
            .Build();

            var repository = new Repository<Models.Product>(db);

            var controller = new ProductController(repository);

            var updateProduct = db.Products.Find(1);
            updateProduct.ProductName = "123123";
             
            var response = (await controller.PutProduct(updateProduct))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

        [Fact]
        public async Task ProductController_DeleteProduct_Ok()
        {
            var db = _builder
            .ConfigureInMemory()
            .AddTenProducts()
            .Build();

            var repository = new Repository<Models.Product>(db);

            var controller = new ProductController(repository);

            var Product = db.Products.Find(1);
            var response = (await controller.DeleteProduct(Product.Id))
                .Result as OkObjectResult;

            var values = Convert.ToBoolean(response.Value);

            values.Should().Be(true);
        }

    }

}