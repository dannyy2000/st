namespace WebApplication1.data.dto.request;

public class ExchangeRequestDto
{

    public class ExchangeRateRequestDto
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
    }
}

