﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BlazorProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorProject.Shared.DTO
{
    public class MedicineEditDTO
    {
        public int MedicineID { get; set; }
        [Required, StringLength(50), Display(Name = "Medicine Name")]
        public string MedicineName { get; set; } = default!;
        [Required, DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Price { get; set; }
        [StringLength(150)]
        public string Picture { get; set; } = default!;
        public bool IsAvailable { get; set; }
        
    }
}
