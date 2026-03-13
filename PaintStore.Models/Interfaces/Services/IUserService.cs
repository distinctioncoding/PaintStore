using System;
using PaintStore.Models;

namespace PaintStore.Models.Interfaces.Services;

public interface IUserService
{
    User CreateUser(User user);
}
