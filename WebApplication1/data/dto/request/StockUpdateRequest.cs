using System.ComponentModel.DataAnnotations;

namespace WebApplication1.data.dto.request;


     
    public class StockUpdateRequest
    {
        [Required(ErrorMessage = "field name cannot be null")]
        [StringLength(maximumLength: 100, ErrorMessage = "field name cannot be empty")]
        public string Name { get; set; }
    
        [Required(ErrorMessage = "field currentPrice cannot be null")]
        public double CurrentPrice { get; set; }
    }
