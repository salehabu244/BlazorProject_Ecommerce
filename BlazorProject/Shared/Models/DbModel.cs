using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared.Models
{
    public enum Status { Payment_Pending = 1, Paid, Cancelled }
    public class Patient
    {
        public int PatientID { get; set; }
        [Required, StringLength(50), Display(Name = "Patient Name")]
        public string PatientName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Address { get; set; } = default!;


        [Required, StringLength(50), EmailAddress]
        public string Email { get; set; } = default!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
    public class Order
    {
        public int OrderID { get; set; }
        [Required, Column(TypeName = "date"),
        Display(Name = "Order Date"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date"),
            Display(Name = "Delivery Date"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime? DeliveryDate { get; set; }
        [Required, EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        [Required, ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; } = default!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
    public class OrderItem
    {
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; } = default!;
        public virtual Medicine Medicine { get; set; } = default!;


    }
    public class Medicine
    {
        public int MedicineID { get; set; }
        [Required, StringLength(50), Display(Name = "Medicine Name")]
        public string MedicineName { get; set; } = default!;
        [Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Price { get; set; }
        [Required, StringLength(150)]
        public string Picture { get; set; } = default!;
        public bool IsAvailable { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
    
}
