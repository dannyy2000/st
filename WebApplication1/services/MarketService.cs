using System.Net;
using WebApplication1.data.dto.request;

namespace WebApplication1.services;

using System;
using System.Net;

using System.Text.Json;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


public class MarketService
{
    public async Task<dynamic> GetExchangeRateAsync(ExchangeRequestDto.ExchangeRateRequestDto exchangeRateRequest)
    {
        try
        {
            string apiKey = "4W4IALNN6WDJ4ZOA";
            using (HttpClient client = new HttpClient())
            {
                string QUERY_URL =
                    $"https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={exchangeRateRequest.FromCurrency}&to_currency={exchangeRateRequest.ToCurrency}&apikey={apiKey}";
                HttpResponseMessage response = await client.GetAsync(QUERY_URL);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var jsonData = await JsonSerializer.DeserializeAsync<JsonDocument>(responseStream);

                        return new
                        {
                            ExchangeRate = jsonData.RootElement.GetProperty("Realtime Currency Exchange Rate")
                                .GetProperty("5. Exchange Rate").GetString(),
                            FromCurrency = exchangeRateRequest.FromCurrency,
                            ToCurrency = exchangeRateRequest.ToCurrency
                        };
                    }
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error: {ex.Message}");
        }
    }
    
   
        public async Task<dynamic> GetTimeSeriesDataAsync(TimeSeriesRequestDto timeSeriesRequest)
        {
            try
            {
                string apiKey = "4W4IALNN6WDJ4ZOA";
                if (string.IsNullOrEmpty(timeSeriesRequest.Symbol))
                {
                    throw new ArgumentException("Symbol is required.", nameof(timeSeriesRequest.Symbol));
                }

                using (HttpClient client = new HttpClient())
                {
                    string QUERY_URL = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={timeSeriesRequest.Symbol}&apikey={apiKey}";
                    HttpResponseMessage response = await client.GetAsync(QUERY_URL);

                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            var json_data = await JsonSerializer.DeserializeAsync<JsonDocument>(responseStream);

                            return json_data.RootElement;
                        }
                    }
                    else
                    {
                        throw new Exception($"Error: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }




    

