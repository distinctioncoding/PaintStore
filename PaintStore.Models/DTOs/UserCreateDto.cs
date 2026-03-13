using System;
using System.ComponentModel.DataAnnotations;

namespace PaintStore.Models.DTOs;

public class UserCreateDto
{
    public string Name { get; set; }

    public string Email { get; set; }
}
