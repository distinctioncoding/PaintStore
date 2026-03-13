using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.API.DataAccess;
using PaintStore.API.Interfaces;
using PaintStore.Models;

namespace PaintStore.API.Repositories;

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
