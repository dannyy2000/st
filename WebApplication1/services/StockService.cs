using Azure;
using WebApplication1.data.dto.request;
using WebApplication1.data.dto.response;
using WebApplication1.data.models;
using WebApplication1.exceptions;

namespace WebApplication1.services;


public class StockService : IStockService
{
    private readonly StockDbContext _context;

    public StockService(StockDbContext context)
    {
        _context = context;
    }

    public async Task<CreateStockResponse> CreateStockAsync(CreateStockRequest stockRequest)
    {
        Console.WriteLine($"Request to create a stock with payload={stockRequest}");
    
        var stock = new Stock
        {
            Name = stockRequest.Name,
            CurrentPrice = stockRequest.CurrentPrice,
            CreationDate = DateTime.Now,
            LastUpdate = DateTime.Now
        };
    
        _context.Stocks.Add(stock); 
        var savedStock = await _context.SaveChangesAsync();
        var stockResponse = GetStockResponse(stock);
        return stockResponse;

    }

    public async Task<GetStockResponse> GetStockByIdAsync(long stockId)
    {
        var stock = await _context.FindAsync<Stock>(stockId) ?? throw new StockNotFoundException($"Stock not found with ID: {stockId}");
        return MapToGetStockResponse(stock);
    }

    // public async Task<Page<GetStockResponse>> GetAllStocksAsync(int pageNumber)
    // {
    //     pageNumber = pageNumber < 1 ? 0 : pageNumber - 1;
    //
    //     var stocks = await _context.Stocks.(pageNumber, AppUtilities.NUMBER_OF_ITEMS_PER_PAGE);
    //     return stocks.Select(ConvertToDTO).ToList();
    // }

    public async Task<UpdateStockResponse> UpdateStockAsync(long stockId, StockUpdateRequest stockUpdateRequest)
    {
        try
        {
            var stock = await _context.FindAsync<Stock>(stockId) ??
                        throw new StockNotFoundException($"Stock not found with ID: {stockId}");

            stock.Name = stockUpdateRequest.Name;
            stock.CurrentPrice = stockUpdateRequest.CurrentPrice;

            _context.Stocks.Add(stock);
            var savedStock = await _context.SaveChangesAsync();

            var updatedStockResponse = GetUpdatedStockResponse(stock);
            return updatedStockResponse;
        }
        catch (StockNotFoundException exception)
        {
            Console.WriteLine($"Stocks update failed {exception.Message}");
            
            throw;
        }
    }

    public async Task DeleteStockAsync(long stockId)
    
    {
        var stock = await _context.FindAsync<Stock>(stockId) ??
                    throw new StockNotFoundException($"Stock not found with ID: {stockId}");
        _context.Remove(stock);
        var savedStock = await _context.SaveChangesAsync();
        
    }
    
 
    
    private CreateStockResponse GetStockResponse(Stock stock)
    {
        CreateStockResponse stockResponse = new CreateStockResponse
        {
            Id = stock.Id,
              IsSuccessful = true,
            Message = "Stocks Created Successfully"
        };
        return stockResponse;
    }
    
    private GetStockResponse MapToGetStockResponse(Stock stock)
    {
        var getStockResponse = new GetStockResponse
        {
            Id = stock.Id,
            Name = stock.Name,
            CurrentPrice = stock.CurrentPrice,
            CreationDate = stock.CreationDate,
            LastUpdate = stock.LastUpdate
        };
        return getStockResponse;
    }
    
    private UpdateStockResponse GetUpdatedStockResponse(Stock stock)
    {
        var updateStockResponse = new UpdateStockResponse
        {
            Id = stock.Id,
            IsSuccessful = true,
            Message = "Update success"
        };
        return updateStockResponse;
    }


}
