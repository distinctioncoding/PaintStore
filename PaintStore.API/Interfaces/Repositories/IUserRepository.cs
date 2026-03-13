using System;
using PaintStore.Models;

namespace PaintStore.API.Interfaces;

public interface IUserRepository
{
    User AddUserToDb(User user);
}
