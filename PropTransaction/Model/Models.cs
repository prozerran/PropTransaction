
using System;
using System.ComponentModel;

// TODO: separate into individual files

namespace PropTransaction.Models
{
    public class Registry
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }

    public class Property
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public int Bedroom { get; set; }
        public bool IsAvaliable { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LeasePrice { get; set; }
    }
}
