using Microsoft.EntityFrameworkCore;
using WebApplication1.data.dto.request;
using WebApplication1.data.models;
using WebApplication1.services;

namespace TestProject3;

public class WebApplicationTest
{
    
    public class WebApplication1Test
    {
        private  StockService _stockService;
        private StockDbContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StockDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            _context = new StockDbContext(options);
            _stockService = new StockService(_context);
        }

        [Test]
        public async Task CreateStockAsync_ValidRequest_ReturnsValidResponse()
        {
            var createStockRequest = new CreateStockRequest
            {
                Name = "TestStock",
                CurrentPrice = 10.0
            };


            var createStockResponse = await _stockService.CreateStockAsync(createStockRequest);

            
            Assert.IsNotNull(createStockResponse);

            Console.WriteLine(createStockResponse.Message);


        }
    }

    // [Test]
    // public async Task CreateUser_ReturnsValidResponse()
    // {
    //     var eateUserRequest = new CreateUserRequest
    //     {
    //         
    //     };
    
}