using System;

namespace PaintStore.Models.DTOs;

public class OrderCreateDto
{
    public int UserId { get; set; }

    public List<int> PaintProductIds { get; set; }
}
