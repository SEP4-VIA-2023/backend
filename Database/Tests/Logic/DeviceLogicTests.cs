using EFCDataAccess;
using Logic.Interface;
using Logic.Logic;
using Model;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;



[TestFixture]
public class DeviceLogicTests
{
    private DeviceLogic _deviceLogic;
    private Mock<IIOTDeviceDAO> _mockDeviceDao;

    [SetUp]
    public void Setup()
    {
        _mockDeviceDao = new Mock<IIOTDeviceDAO>();
        _deviceLogic = new DeviceLogic(_mockDeviceDao.Object);
    }

    [Test]
    public async Task CreateDevice_WithNonExistingToken_ShouldCreateDevice()
    {
        // Arrange
        var dto = new IOTDeviceDTO("token123", 1);
            
        _mockDeviceDao.Setup(dao => dao.GetByTokenAsync(dto.Token)).ReturnsAsync((IOTDevice)null);
        _mockDeviceDao.Setup(dao => dao.CreateAsync(It.IsAny<IOTDevice>())).ReturnsAsync(new IOTDevice(dto.Token, dto.UserId));

        // Act
        var result = await _deviceLogic.CreateDevice(dto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(dto.Token, result.Token);
        Assert.AreEqual(dto.UserId, result.UserId);
    }

    [Test]
    public void CreateDevice_WithExistingToken_ShouldThrowException()
    {
        // Arrange
        var dto = new IOTDeviceDTO("token123", 1);


        var existingDevice = new IOTDevice(dto.Token, dto.UserId);

        _mockDeviceDao.Setup(dao => dao.GetByTokenAsync(dto.Token)).ReturnsAsync(existingDevice);

        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () => await _deviceLogic.CreateDevice(dto));
    }
}