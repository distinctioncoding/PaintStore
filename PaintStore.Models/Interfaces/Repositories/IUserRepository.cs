using System;
using PaintStore.Models;

namespace PaintStore.Models.Interfaces.Repositories;

public interface IUserRepository
{
    User AddUserToDb(User user);
}
