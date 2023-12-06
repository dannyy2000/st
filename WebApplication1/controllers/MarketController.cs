using WebApplication1.data.dto.request;
using WebApplication1.services;

namespace WebApplication1.controllers;


using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



    [ApiController]
    [Route("api/market")]
    public class MarketController : ControllerBase
    {
        private readonly MarketService marketService;

        public MarketController(MarketService marketService)
        {
            this.marketService = marketService;
        }

        [HttpGet]
        [Route("exchange-rate")]
        public async Task<IActionResult> GetExchangeRate([FromBody] ExchangeRequestDto.ExchangeRateRequestDto exchangeRateRequest)
        {
            try
            {
               

                dynamic result = await marketService.GetExchangeRateAsync(exchangeRateRequest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("time-series")]
        public async Task<ActionResult> GetTimeSeries([FromBody] TimeSeriesRequestDto timeSeriesRequestDto)
        {
            try
            {
                dynamic result = await marketService.GetTimeSeriesDataAsync(timeSeriesRequestDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }
    }
    