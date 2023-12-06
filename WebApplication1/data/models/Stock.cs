namespace WebApplication1.data.models;

  
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double CurrentPrice { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime LastUpdate { get; set; }
    }
