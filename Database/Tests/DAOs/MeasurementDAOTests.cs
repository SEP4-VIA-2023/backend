using EFCDataAccess.DAOs;
using Microsoft.EntityFrameworkCore;
using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCDataAccess;

[TestFixture]
public class MeasurementDAOTests
{
    private DataContext _dataContext;
    private MeasurementDAO _measurementDAO;

    [SetUp]
    public void Setup()
    {
        // Create a new DataContext with InMemoryDatabase
        _dataContext = new DataContext();
        _measurementDAO = new MeasurementDAO(_dataContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dataContext.Measurements.RemoveRange(_dataContext.Measurements);
        _dataContext.SaveChanges();
        
    }

    private async Task SeedData(List<Measurement> measurements)
    {
        _dataContext.Measurements.AddRange(measurements);
        await _dataContext.SaveChangesAsync();
    }

    [Test]
    public async Task CreateAsync_GivenValidMeasurement_ReturnsCreatedMeasurement()
    {
        // Arrange
        var measurement = new Measurement
        {
            Id = 0,
            Time = DateTime.UtcNow,
            Humidity = 1,
            Co2 = 1,
            Temperature = 1,
            ServoStatus = 1,
            DeviceId = 1,
        };

        // Act
        var result = await _measurementDAO.CreateAsync(measurement);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(measurement.Id, result.Id);
        Assert.AreEqual(measurement.Time, result.Time);
        Assert.AreEqual(measurement.Humidity, result.Humidity);
        Assert.AreEqual(measurement.Co2, result.Co2);
        Assert.AreEqual(measurement.Temperature, result.Temperature);
        Assert.AreEqual(measurement.ServoStatus, result.ServoStatus);
        Assert.AreEqual(measurement.DeviceId, result.DeviceId);
    }

    [Test]
    public async Task GetAllAsync_GivenMeasurementsExist_ReturnsAllMeasurements()
    {
        // Arrange
        var measurements = new List<Measurement>
        {
            new Measurement
            {
                Id = 0,
                Time = DateTime.UtcNow,
                Humidity = 1,
                Co2 = 1,
                Temperature = 1,
                ServoStatus = 1,
                DeviceId = 1,
            },
            new Measurement
            {
                Id = 0,
                Time = DateTime.UtcNow,
                Humidity = 2,
                Co2 = 2,
                Temperature = 2,
                ServoStatus = 0,
                DeviceId = 1
            }
        };

        await SeedData(measurements);

        // Act
        var result = await _measurementDAO.GetAllAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(measurements.Count, result.Count);
        CollectionAssert.AreEqual(measurements, result);
    }

    [Test]
    public async Task GetAllByDeviceIdAsync_GivenDeviceId_ReturnsMeasurementsForDevice()
    {
        // Arrange
        var deviceId = 1;
        var measurements = new List<Measurement>
        {
            new Measurement
            {
                Id = 0,
                Time = DateTime.UtcNow,
                Humidity = 1,
                Co2 = 1,
                Temperature = 1,
                ServoStatus = 1,
                DeviceId = 1,
            },
            new Measurement
            {
                Id = 0,
                Time = DateTime.UtcNow,
                Humidity = 2,
                Co2 = 2,
                Temperature = 2,
                ServoStatus = 0,
                DeviceId = 3
            }
        };

        await SeedData(measurements);

        // Act
        var result = await _measurementDAO.GetAllByDeviceIdAsync(deviceId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(measurements.First(m => m.DeviceId == deviceId), result.First());
    }
}