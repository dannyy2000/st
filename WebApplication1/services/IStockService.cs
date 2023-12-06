using Azure;
using WebApplication1.data.dto.request;
using WebApplication1.data.dto.response;

namespace WebApplication1.services;

public interface IStockService
{
    
     
    Task<CreateStockResponse> CreateStockAsync(CreateStockRequest stockRequest);
    Task<GetStockResponse> GetStockByIdAsync(long stockId);
    // Task<Page<GetStockResponse>> GetAllStocksAsync(int pageNumber);
    Task<UpdateStockResponse> UpdateStockAsync(long stockId, StockUpdateRequest stockUpdateRequest);
    Task DeleteStockAsync(long stockId);
    }
