using System;
using PaintStore.Models;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Interfaces.Services;

namespace PaintStore.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User CreateUser(User user)
    {      
        User newUser = _userRepository.AddUserToDb(user);
        return newUser;
    }
}
