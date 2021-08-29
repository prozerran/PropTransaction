
using System;
using System.ComponentModel;

// TODO: separate into individual files

namespace PropTransaction.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Registry : Login
    {
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }

    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime Update_Time { get; set; }
    }

    public class SessionView
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string SessionId { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class Property
    {
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public string PropertyName { get; set; }
        public int Bedroom { get; set; }
        public bool IsAvaliable { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LeasePrice { get; set; }
    }
}
