using System;
using PaintStore.Models;

namespace PaintStore.API.Interfaces;

public interface IUserService
{
    User CreateUser(User user);
}
