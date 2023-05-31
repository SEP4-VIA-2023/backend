using EFCDataAccess;
using Logic.Logic;
using Logic.Security;
using Microsoft.Extensions.Configuration;
using Model;
using Moq;


[TestFixture]
public class UserLogicTests
{
    private UserLogic _userLogic;
    private Mock<IUserDao> _mockUserDao;
    private Tokens _tokens;

    [SetUp]
    public void Setup()
    {
        _mockUserDao = new Mock<IUserDao>();
        _tokens = new Tokens(Mock.Of<IConfiguration>());

        _userLogic = new UserLogic(_tokens, _mockUserDao.Object);
    }

    [Test]
    public async Task CreateUser_WithNonExistingEmail_ShouldCreateUser()
    {
        // Arrange
        var dto = new UserDTO("John Doe", "test@example.com");
        dto.Password = "password123";


        byte[] hashedPassword = new byte[] { 1, 2, 3 }; // Example hashed password
        byte[] salt = new byte[] { 4, 5, 6 }; // Example salt

        _mockUserDao.Setup(dao => dao.GetByEmail(dto.Email)).ReturnsAsync((User)null);
        _mockUserDao.Setup(dao => dao.CreateAsync(It.IsAny<User>()))
            .ReturnsAsync(new User(dto.Name, hashedPassword, salt, dto.Email));

        // Act
        var result = await _userLogic.CreateUser(dto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(dto.Name, result.Name);
        Assert.AreEqual(dto.Email, result.Email);
    }

    [Test]
    public void CreateUser_WithExistingEmail_ShouldThrowException()
    {
        // Arrange
        var dto = new UserDTO("John Doe", "test@example.com");
        dto.Password = "password123";

        var existingUser = new User(dto.Name, new byte[] { 1, 2, 3 }, new byte[] { 4, 5, 6 }, dto.Email);

        _mockUserDao.Setup(dao => dao.GetByEmail(dto.Email)).ReturnsAsync(existingUser);

        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () => await _userLogic.CreateUser(dto));
    }

    [Test]
    public async Task LoginUser_WithCorrectCredentials_ShouldReturnToken()
    {
        // Arrange
        var dto = new UserDTO("John Doe", "test@example.com");
        dto.Password = "password123";

        byte[] hashedPassword;
        byte[] salt;
        PasswordHashing.HashPassword(dto.Password!, out hashedPassword, out salt);

        var user = new User(dto.Name, hashedPassword, salt, dto.Email);

        var mockUserDao = new Mock<IUserDao>();
        mockUserDao.Setup(dao => dao.GetByEmail(dto.Email)).ReturnsAsync(user);

        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration.Setup(config => config[It.IsAny<string>()]).Returns("kf8hBP8MdnU3vZTI9dZqiehaJ2ePCybw14zPDjUi");

        var tokens = new Tokens(mockConfiguration.Object);

        var userLogic = new UserLogic(tokens, mockUserDao.Object);

        // Act
        var result = await userLogic.LoginUser(dto);

        // Assert
        Assert.IsNotNull(result);
        // Add more assertions as needed
    }


    [Test]
    public void LoginUser_WithIncorrectCredentials_ShouldThrowException()
    {
        // Arrange
        var dto = new UserDTO("Test", "test@example.com");


        byte[] hashedPassword = new byte[] { 1, 2, 3 }; // Example hashed password
        byte[] salt = new byte[] { 4, 5, 6 }; // Example salt

        var user = new User(dto.Name, hashedPassword, salt, dto.Email);

        _mockUserDao.Setup(dao => dao.GetByEmail(dto.Email)).ReturnsAsync(user);

        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () => await _userLogic.LoginUser(new UserDTO("name", "email")
        ));
    }
}