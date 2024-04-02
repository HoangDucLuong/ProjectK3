﻿namespace ProjectK3.Entities.Emails;

public class WelcomeMail
{
   public string To { get; set; }

    // Sender
    public string? From { get; set; }
    public string DisplayName { get; set; }

    // Content
    public string Subject { get; set; }
    public string? Body { get; set; }
}
