using ProjectK3.Entities.Accounts;
using System;
using System.Collections.Generic;

namespace ProjectK3.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int? StatusId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? DeliveryType { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Product? Product { get; set; }

    public virtual Status? StatusNavigation { get; set; }

    public virtual User? User { get; set; }
}
