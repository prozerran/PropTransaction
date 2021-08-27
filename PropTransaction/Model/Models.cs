
using System;

namespace PropTransaction.Models
{
    public class HomePage
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string IndexPage { get; set; }
        public string Version { get; set; }
    }

    public class ReqMessage
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class Property
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public bool IsAvaliable { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LeasePrice { get; set; }
    }
}
