using Microsoft.AspNetCore.Mvc;
using WebApplication1.data.dto.request;
using WebApplication1.data.dto.response;
using WebApplication1.exceptions;
using WebApplication1.services;

namespace WebApplication1.controllers;

    [ApiController]
    [Route("api/v1/stocks")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly ILogger<StockController> _logger;

        public StockController(IStockService stockService, ILogger<StockController> logger)
        {
            _stockService = stockService ?? throw new ArgumentNullException(nameof(stockService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateStockResponse>> CreateStock([FromBody] CreateStockRequest stockRequest)
        {
            try
            {
                var stockResponse = await _stockService.CreateStockAsync(stockRequest);
                return CreatedAtAction(nameof(GetStockById), new { stockId = stockResponse.Id }, stockResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating stock");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{stockId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetStockResponse>> GetStockById(long stockId)
        {
            try
            {
                var stockResponse = await _stockService.GetStockByIdAsync(stockId);
                return Ok(stockResponse);
            }
            catch (StockNotFoundException ex)
            {
                _logger.LogError(ex, "Stock not found");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting stock by ID");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        
        [HttpPut("{stockId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UpdateStockResponse>> Update([FromRoute] long stockId, [FromBody] StockUpdateRequest stockUpdateRequest)
        {
            var updateStockResponse = await _stockService.UpdateStockAsync(stockId, stockUpdateRequest);
            return CreatedAtAction(nameof(Update), updateStockResponse);
        }
        
        [HttpDelete("{stockId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStock([FromRoute] long stockId)
        {
            await _stockService.DeleteStockAsync(stockId);
            return NoContent(); 
        }


    }

