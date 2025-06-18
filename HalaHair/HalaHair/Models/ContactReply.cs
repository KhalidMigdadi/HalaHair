using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class ContactReply
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public string RepliedBy { get; set; } = null!;

    public string ReplyMessageEn { get; set; } = null!;

    public string ReplyMessageAr { get; set; } = null!;

    public DateTime? RepliedAt { get; set; }

    public virtual Contact Contact { get; set; } = null!;
}
