﻿using System;
using System.Collections.Generic;

namespace ProjectK3.Entities;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }
}
