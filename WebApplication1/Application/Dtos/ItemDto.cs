﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Domain.Entites;

namespace WebApplication1.Application.Dtos
{
    public class ItemDto:IDto 
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
       
        public string? Description { get; set; }
  
        public double Price { get; set; }
      
        public byte[] Image { get; set; }
    
        public long CategoryId { get; set; }
   
        public long CategoryName { get; set; }
    }
}
