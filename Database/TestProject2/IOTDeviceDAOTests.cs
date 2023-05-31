using EFCDataAccess;
using EFCDataAccess.DAOs;
using Microsoft.EntityFrameworkCore;
using Model;
using NUnit.Framework;



    [TestFixture]
    public class IOTDeviceDAOTests
    {
 

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateAsync_ShouldCreateIOTDevice()
        {
            // Arrange
            using (var context = new DataContext())
            {
                var iotDeviceDAO = new IOTDeviceDAO(context);
                var iotDevice = new IOTDevice(
                    token: "deviceToken123",
                    userId: 1
                );

                // Act
                var createdDevice = await iotDeviceDAO.CreateAsync(iotDevice);

                // Assert
                Assert.IsNotNull(createdDevice);
                Assert.AreEqual(iotDevice.Token, createdDevice.Token);
                Assert.AreEqual(iotDevice.UserId, createdDevice.UserId);
                // Add more assertions as needed
            }
        }

        [Test]
        public async Task GetByTokenAsync_ShouldReturnDeviceIfExists()
        {
            // Arrange
            using (var context = new DataContext())
            {
                var iotDeviceDAO = new IOTDeviceDAO(context);
                var iotDevice = new IOTDevice(
                    token: "deviceToken123",
                    userId: 1
                );
                await context.IOTDevices.AddAsync(iotDevice);
                await context.SaveChangesAsync();

                // Act
                var retrievedDevice = await iotDeviceDAO.GetByTokenAsync("deviceToken123");

                // Assert
                Assert.IsNotNull(retrievedDevice);
                Assert.AreEqual(iotDevice.Token, retrievedDevice.Token);
                Assert.AreEqual(iotDevice.UserId, retrievedDevice.UserId);
                // Add more assertions as needed
            }
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnDeviceIfExists()
        {
            // Arrange
            using (var context = new DataContext())
            {
                var iotDeviceDAO = new IOTDeviceDAO(context);
                var iotDevice = new IOTDevice(
                    token: "deviceToken123",
                    userId: 1
                );
                await context.IOTDevices.AddAsync(iotDevice);
                await context.SaveChangesAsync();

                // Act
                var retrievedDevice = await iotDeviceDAO.GetByIdAsync(iotDevice.Id);

                // Assert
                Assert.IsNotNull(retrievedDevice);
                Assert.AreEqual(iotDevice.Token, retrievedDevice.Token);
                Assert.AreEqual(iotDevice.UserId, retrievedDevice.UserId);
                // Add more assertions as needed
            }
        }
    }
