using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class SalonImage
{
    public int Id { get; set; }

    public int SalonId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime UploadedAt { get; set; }

    public bool IsMainImage { get; set; }
}
