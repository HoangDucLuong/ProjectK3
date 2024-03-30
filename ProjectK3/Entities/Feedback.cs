using System;
using System.Collections.Generic;

namespace ProjectK3.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public string? Comment { get; set; }

    public DateTime? FeedbackDate { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
