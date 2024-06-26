﻿using System;
using System.Collections.Generic;

namespace ProjectK3.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public int? StatusId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? UniqueCode { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Status? Status { get; set; }
}
