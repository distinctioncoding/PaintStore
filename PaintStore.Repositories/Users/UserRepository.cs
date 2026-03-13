using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.DataAccess;
using PaintStore.Models;
using PaintStore.Models.Interfaces.Repositories;

namespace PaintStore.Repositories.Users;

public class UserRepository:IUserRepository
{
    private PaintStoreDbContext _dbContext;

    public UserRepository(PaintStoreDbContext paintStoreDb)
    {
        _dbContext = paintStoreDb;
    }
    public User AddUserToDb(User user)
    {
        //Add only mark user to be added
        _dbContext.Users.Add(user);

        //save to db
        int changes = _dbContext.SaveChanges();
        if (changes > 0)
        {
            return user;
        }

        else
        {
            throw new DbUpdateException("Add User failed");
        }

    }
}
