using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SubjectEn { get; set; }

    public string? SubjectAr { get; set; }

    public string MessageEn { get; set; } = null!;

    public string MessageAr { get; set; } = null!;

    public bool? IsReplied { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ContactReply> ContactReplies { get; set; } = new List<ContactReply>();
}
