using APIs;
using EFCDataAccess;
using EFCDataAccess.DAOs;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Tests.Controllers;

[TestFixture]
public class PresetsControllerTests
{
    private PresetsController _presetsController;
    private DataContext _dataContext;
    private IPresetDAO _presetDao;

    [SetUp]
    public void SetUp()
    {
        _dataContext = new DataContext();
        _presetDao = new PresetDAO(_dataContext);
        _presetsController = new PresetsController(_dataContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dataContext.Presets.RemoveRange(_dataContext.Presets);
        _dataContext.SaveChanges();
        // _dataContext.Database.EnsureDeleted();
    }

    [Test]
    public async Task GetPreset_ExistingDeviceId_ReturnsPresetList()
    {
        // Arrange
        var deviceId = 1;
        var preset1 = new Preset(0, "Preset 1", 30, 70, 500, 2000, 20, 25, 90, 1, true);
        var preset2 = new Preset(0, "Preset 2", 40, 80, 600, 2500, 22, 27, 95, 1, false);
        _dataContext.Presets.AddRange(preset1, preset2);
        _dataContext.SaveChanges();

        // Act
        var result = await _presetsController.GetPreset(deviceId);

        // Assert
        var actionResult = result;
        Assert.IsNotNull(actionResult);
        var presets = actionResult;
        Assert.IsNotNull(presets);
        Assert.AreEqual(2, presets.Count);
    }

    [Test]
    public async Task UpdatePreset_ExistingPresetId_ReturnsOkResult()
    {
        // Arrange
        var preset = new Preset(0, "Preset 1", 30, 70, 500, 2000, 20, 25, 90, 1, true);
        _dataContext.Presets.Add(preset);
        _dataContext.SaveChanges();

        var presetDTO = new PresetDTO
        {
            Name = "Updated Preset 1",
            MinHumidity = 35,
            MaxHumidity = 75,
            MinCo2 = 600,
            MaxCo2 = 2500,
            MinTemperature = 22,
            MaxTemperature = 27,
            Servo = 95,
            isActive = false
        };

        // Act
        var result = await _presetsController.UpdatePreset(1, presetDTO);
        
        var updatedPreset = await _presetDao.GetByIdAsync(1);
        Assert.AreEqual("Updated Preset 1", updatedPreset.Name);
        Assert.AreEqual(35, updatedPreset.MinHumidity);
        Assert.AreEqual(75, updatedPreset.MaxHumidity);
        Assert.AreEqual(600, updatedPreset.MinCo2);
        Assert.AreEqual(2500, updatedPreset.MaxCo2);
        Assert.AreEqual(22, updatedPreset.MinTemperature);
        Assert.AreEqual(27, updatedPreset.MaxTemperature);
        Assert.AreEqual(95, updatedPreset.Servo);
    }

    [Test]
    public async Task CreatePreset_ValidPresetDTO_CreatesPreset()
    {
        // Arrange
        var presetDTO = new PresetDTO
        {
            Id = 1,
            Name = "New Preset",
            MinHumidity = 40,
            MaxHumidity = 80,
            MinCo2 = 700,
            MaxCo2 = 3000,
            MinTemperature = 23,
            MaxTemperature = 28,
            Servo = 100,
            DeviceId = 1,
            isActive = true
        };

        // Act
        await _presetsController.CreatePreset(presetDTO);

        // Assert
        var createdPreset = await _presetDao.GetByIdAsync(1);
        Assert.IsNotNull(createdPreset);
        Assert.AreEqual("New Preset", createdPreset.Name);
        Assert.AreEqual(40, createdPreset.MinHumidity);
        Assert.AreEqual(80, createdPreset.MaxHumidity);
        Assert.AreEqual(700, createdPreset.MinCo2);
        Assert.AreEqual(3000, createdPreset.MaxCo2);
        Assert.AreEqual(23, createdPreset.MinTemperature);
        Assert.AreEqual(28, createdPreset.MaxTemperature);
        Assert.AreEqual(100, createdPreset.Servo);
        Assert.AreEqual(1, createdPreset.DeviceId);
        Assert.IsTrue(createdPreset.isActive);
    }

    [Test]
    public async Task DeletePreset_ExistingPresetId_ReturnsOkResult()
    {
        // Arrange
        var preset = new Preset(1, "Preset 1", 30, 70, 500, 2000, 20, 25, 90, 1, true);
        _dataContext.Presets.Add(preset);
        _dataContext.SaveChanges();

        // Act
        var result = await _presetsController.DeletePreset(1);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        Assert.AreEqual("Preset deleted successfully", (result as OkObjectResult)?.Value);

        // Verify that the preset was deleted from the database
        var deletedPreset = await _presetDao.GetByIdAsync(1);
        Assert.IsNull(deletedPreset);
    }

    [Test]
    public async Task ActivatePreset_ExistingPresetId_ReturnsOkResult()
    {
        // Arrange
        var preset = new Preset(1, "Preset 1", 30, 70, 500, 2000, 20, 25, 90, 1, false);
        _dataContext.Presets.Add(preset);
        _dataContext.SaveChanges();

        // Act
        var result = await _presetsController.ActivatePreset(1);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        Assert.AreEqual("Preset activated successfully", (result as OkObjectResult)?.Value);

        // Verify that the preset was activated in the database
        var activatedPreset = await _presetDao.GetByIdAsync(1);
        Assert.IsTrue(activatedPreset.isActive);
    }
}