using System;
using PaintStore.Repositories.Users;
using PaintStore.Services;
using Xunit;
using Moq;
using PaintStore.Models.Interfaces.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace PaintStore.Tests;

public class UserServiceTests
{
    private Mock<IUserRepository> _mockUserRepository;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
    }

    //Naming pattern for test method
    //What___When___Should
    [Fact]
    public async Task CreateUserAsync_WhenUserRepositorySucceeds_ReturnNewUser()
    {
        //Arrange
        //prepare a new user mock data
        var user = new Models.User(){ Id = 1, Name = "Larry", Email = "123@gmail.com"};

        var userService = new UserService(_mockUserRepository.Object);

        _mockUserRepository.Setup(m => m.AddUserToDbAsync(user)).ReturnsAsync(user);

        //Act
        var result = await userService.CreateUserAsync(user);

        //Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.Email.Should().Be("123@gmail.com");
    }

    [Fact]
    public async Task CreateUserAsync_WhenUserRepoFailedToSave_ThrowsException()
    {
        //Arrange
        var user = new Models.User(){ Id = 1, Name = "Larry", Email = "123@gmail.com"};
        var userService = new UserService(_mockUserRepository.Object);
        _mockUserRepository.Setup(m => m.AddUserToDbAsync(user)).ThrowsAsync(new DbUpdateException("Add user failed"));
        
        //Act & Assert
        await Assert.ThrowsAsync<DbUpdateException>(() => userService.CreateUserAsync(user));

    }
}
