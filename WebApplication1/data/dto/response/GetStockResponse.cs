namespace WebApplication1.data.dto.response;


    public class GetStockResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
