using NUnit.Framework;
using System;

[TestFixture]
public class MeasurementConverterTests
{
    private MeasurementConverter converter;

    [SetUp]
    public void SetUp()
    {
        converter = new MeasurementConverter();
    }

    [Test]
    public void GetTemperature_ValidData_ReturnsTemperature_zero()
    {
        // Arrange
        string data = "000000000000"; // Update with your actual data

        // Act
        int temperature = converter.GetTemperature(data);

        // Assert
        Assert.AreEqual(0, temperature);
    }

    [Test]
    public void GetHumidity_ValidData_ReturnsHumidity_zero()
    {
        // Arrange
        string data = "000000000000"; // Update with your actual data

        // Act
        int humidity = converter.GetHumidity(data);

        // Assert
        Assert.AreEqual(0, humidity);
    }

    [Test]
    public void GetCO2_ValidData_ReturnsCO_zero()
    {
        // Arrange
        string data = "000000000000"; // Update with your actual data

        // Act
        int co2 = converter.GetCO2(data);

        // Assert
        Assert.AreEqual(0, co2);
    }

    [Test]
    public void GetServo_ValidData_ReturnsServoStatus_zero()
    {
        // Arrange
        string data = "00000000000000"; // Update with your actual data

        // Act
        int servoStatus = converter.GetServo(data);

        // Assert
        Assert.AreEqual(0, servoStatus);
    }

    [Test]
    public void GetTemperature_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        string data = "InvalidData";

        // Act and Assert
        Assert.Throws<FormatException>(() => converter.GetTemperature(data));
    }

    [Test]
    public void GetTemperature_InsufficientDataLength_ThrowsArgumentException()
    {
        // Arrange
        string data = "0000";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => converter.GetTemperature(data));
    }

    [Test]
    public void GetTemperature_ValidData_ReturnsTemperature()
    {
        // Arrange
        string data = "033a019f010432"; // Actual data for temperature (25.0°C)

        // Act
        int temperature = converter.GetTemperature(data);

        // Assert
        Assert.AreEqual(26, temperature);
    }

    [Test]
    public void GetHumidity_ValidData_ReturnsHumidity()
    {
        // Arrange
        string data = "033a019f010432"; // Actual data for humidity (100.0%)

        // Act
        int humidity = converter.GetHumidity(data);

        // Assert
        Assert.AreEqual(41, humidity);
    }

    [Test]
    public void GetCO2_ValidData_ReturnsCO2()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string data = "033a019f010432"; // Actual data for CO2 (1024 ppm)

        // Act
        int co2 = converter.GetCO2(data);

        // Assert
        Assert.AreEqual(826, co2);
    }

    [Test]
    public void GetServo_ValidData_ReturnsServoStatus()
    {
        // Arrange
        string data = "033a019f010432"; // Actual data for servo status (255)

        // Act
        int servoStatus = converter.GetServo(data);

        // Assert
        Assert.AreEqual(50, servoStatus);
    }


    [Test]
    public void GetTemperature_InvalidDataFormat_ThrowsFormatException()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string invalidData = "12G34";

        // Act and Assert
        Assert.Throws<FormatException>(() => converter.GetTemperature(invalidData));
    }
    
    [Test]
    public void GetHumidity_InvalidDataFormat_ThrowsArgumentException()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string invalidData = "ABCD";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => converter.GetHumidity(invalidData));
    }

    [Test]
    public void GetHumidity_InsufficientDataLength_ThrowsArgumentException()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string insufficientData = "1234";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => converter.GetHumidity(insufficientData));
    }

    [Test]
    public void GetCO2_InvalidDataFormat_ThrowsFormatException()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string invalidData = "XY";

        // Act and Assert
        Assert.Throws<FormatException>(() => converter.GetCO2(invalidData));
    }

    [Test]
    public void GetCO2_InsufficientDataLength_ThrowsArgumentException()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string insufficientData = "12";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => converter.GetCO2(insufficientData));
    }

    [Test]
    public void GetServo_InvalidDataFormat_ThrowsArgumentException()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string invalidData = "1";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => converter.GetServo(invalidData));
    }

    [Test]
    public void GetServo_InsufficientDataLength_ThrowsException()
    {
        // Arrange
        var converter = new MeasurementConverter();
        string insufficientData = "1";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => converter.GetServo(insufficientData));
    }
    
}
