namespace WebApplication1.data.dto.request;
using System.ComponentModel.DataAnnotations;
    

    public class CreateStockRequest
    {
        [Required(ErrorMessage = "field name cannot be null")]
       
        public string Name { get; set; }
    
        [Required(ErrorMessage = "field name cannot be null")]
        public double CurrentPrice { get; set; }
    }
    
  