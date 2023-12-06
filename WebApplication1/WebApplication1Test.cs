using NUnit.Framework;
using WebApplication1.data.dto.request;
using WebApplication1.data.models;
using WebApplication1.services;
using System;
using NUnit.Core;


namespace WebApplication1
{

    //  [TestFixture]
    // public class WebApplication1Test
    // {
    //     private StockService _stockService;
    //     private StockDbContext _context;
    //
    //     [SetUp]
    //     public void SetUp()
    //     {
    //
    //         _context = new StockDbContext();
    //         _stockService = new StockService(_context);
    //     }
    //
    //     [Test]
    //     public async Task CreateStockAsync_ValidRequest_ReturnsValidResponse()
    //     {
    //         var createStockRequest = new CreateStockRequest
    //         {
    //             Name = "TestStock",
    //             CurrentPrice = 10.0
    //         };
    //
    //
    //         var createStockResponse = await _stockService.CreateStockAsync(createStockRequest);
    //
    //         
    //         Assert.IsNotNull(createStockResponse);
    //
    //         Console.WriteLine(createStockResponse.Message);
    //
    //
    //     }
    // }
}