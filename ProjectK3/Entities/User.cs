using System;
using System.Collections.Generic;

namespace ProjectK3.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int? StatusId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string Role { get; set; } = null!;

    public string? Password { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Status? Status { get; set; }
}
