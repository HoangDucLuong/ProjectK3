﻿using System;
using System.Collections.Generic;
using ProjectK3.Entities.Accounts;

namespace ProjectK3.Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? DateAdded { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
