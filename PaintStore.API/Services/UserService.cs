using System;
using PaintStore.API.Interfaces;
using PaintStore.API.Repositories;
using PaintStore.Models;

namespace PaintStore.API.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public User CreateUser(User user)
    {      
        var key =  _configuration.GetSection("ApiKeys:OpenAI");

        User newUser = _userRepository.AddUserToDb(user);
        return newUser;
    }
}
