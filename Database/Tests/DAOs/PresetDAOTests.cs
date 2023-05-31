using EFCDataAccess;
using EFCDataAccess.DAOs;
using Microsoft.EntityFrameworkCore;
using Model;

    [TestFixture]
    public class PresetDAOTests
    {
        private DataContext _dataContext;
        private PresetDAO _presetDAO;

        [SetUp]
        public void Setup()
        {
            // Set up the data context
            _dataContext = new DataContext();

            // Create a new instance of the PresetDAO with the data context
            _presetDAO = new PresetDAO(_dataContext);
        }

        [TearDown]
        public async Task TearDown()
        {
            // Clean up the data context after each test by deleting all presets
            _dataContext.Presets.RemoveRange(_dataContext.Presets);
            await _dataContext.SaveChangesAsync();
        }
        

[Test]
public async Task GetByIdAsync_ReturnsExistingPreset()
{
    // Arrange
   
    using (var context = new DataContext())
    {
        var preset = new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false);
        context.Presets.Add(preset);
        context.SaveChanges();
        var repository = new PresetDAO(context);

        // Act
        var result = await repository.GetByIdAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(preset.Id, result.Id);
    }
}


        [Test]
        public async Task GetByIdAsync_WhenPresetExists_ShouldReturnPreset()
        {
            // Arrange
            var preset = new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false);
            _dataContext.Presets.Add(preset);
            await _dataContext.SaveChangesAsync();

            // Act
            var retrievedPreset = await _presetDAO.GetByIdAsync(preset.Id);

            // Assert
            Assert.NotNull(retrievedPreset);
            Assert.AreEqual(preset.Id, retrievedPreset.Id);
            // Add more assertions as needed
        }

        [Test]
        public async Task GetByIdAsync_WhenPresetDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var presetId = 123; // Assuming an ID that doesn't exist

            // Act
            var retrievedPreset = await _presetDAO.GetByIdAsync(presetId);

            // Assert
            Assert.Null(retrievedPreset);
        }

        [Test]
        public async Task GetByDeviceIdAsync_WhenPresetsExistForDeviceId_ShouldReturnPresets()
        {
            // Arrange
            var deviceId = 123; // Assuming a device ID

            var presets = new List<Preset>
            {
                // Create some presets with the specified device ID
                // ...
            };
            _dataContext.Presets.AddRange(presets);
            await _dataContext.SaveChangesAsync();

            // Act
            var retrievedPresets = await _presetDAO.GetByDeviceIdAsync(deviceId);

            // Assert
            Assert.NotNull(retrievedPresets);
            Assert.AreEqual(presets.Count, retrievedPresets.Count);
            // Add more assertions as needed
        }

        [Test]
        public async Task GetByDeviceIdAsync_WhenNoPresetsExistForDeviceId_ShouldReturnEmptyList()
        {
            // Arrange
            var deviceId = 123; // Assuming a device ID

            // Act
            var retrievedPresets = await _presetDAO.GetByDeviceIdAsync(deviceId);

            // Assert
            Assert.NotNull(retrievedPresets);
            Assert.IsEmpty(retrievedPresets);
        }

        [Test]
        public async Task GetAllAsync_WhenPresetsExist_ShouldReturnAllPresets()
        {
            // Arrange
            var presets = new List<Preset>
            {
                // Create some presets
                // ...
            };
            _dataContext.Presets.AddRange(presets);
            await _dataContext.SaveChangesAsync();

            // Act
            var retrievedPresets = await _presetDAO.GetAllAsync();

            // Assert
            Assert.NotNull(retrievedPresets);
            Assert.AreEqual(presets.Count, retrievedPresets.Count);
            // Add more assertions as needed
        }

        [Test]
        public async Task GetAllAsync_WhenNoPresetsExist_ShouldReturnEmptyList()
        {
            // Act
            var retrievedPresets = await _presetDAO.GetAllAsync();

            // Assert
            Assert.NotNull(retrievedPresets);
            Assert.IsEmpty(retrievedPresets);
        }

        [Test]
        public async Task UpdateAsync_WhenPresetExists_ShouldUpdateAndReturnPreset()
        {
            // Arrange
            var preset = new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false);
            _dataContext.Presets.Add(preset);
            await _dataContext.SaveChangesAsync();

            var updatedPreset = new Preset(1, "Preset1", 100, 400, 100, 2300, 10, 30, 50, 1, false);

            // Act
            var updated = await _presetDAO.UpdateAsync(preset.Id, updatedPreset);

            // Assert
            Assert.NotNull(updated);
            Assert.AreEqual(preset.Id, updated.Id);
            Assert.AreEqual(updatedPreset.Name, updated.Name);
            // Add more assertions as needed
        }

        [Test]
        public async Task UpdateAsync_WhenPresetDoesNotExist_ShouldThrowArgumentException()
        {
            // Arrange
            var presetId = 123; // Assuming an ID that doesn't exist

            var updatedPreset = new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 0, false);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _presetDAO.UpdateAsync(presetId, updatedPreset));
        }

        [Test]
        public async Task DeleteAsync_WhenPresetExists_ShouldDeleteAndReturnNull()
        {
            // Arrange
            var preset = new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false);
            
            _dataContext.Presets.Add(preset);
            await _dataContext.SaveChangesAsync();

            // Act
            var deletedPreset = await _presetDAO.DeleteAsync(preset.Id);

            // Assert
            Assert.Null(deletedPreset);
            var retrievedPreset = await _presetDAO.GetByIdAsync(preset.Id);
            Assert.Null(retrievedPreset);
        }

        

        [Test]
        public async Task GetLastPresetByDeviceIdAsync_WhenPresetsExistForDeviceId_ShouldReturnLastPreset()
        {
            // Arrange
            var deviceId = 1; // Assuming a device ID

            var presets = new List<Preset>
            {
                new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false),
                new Preset(2, "Pipireset1", 100, 400, 100, 2000, 10, 30, 50, 1, false)

            };
            _dataContext.Presets.AddRange(presets);
            await _dataContext.SaveChangesAsync();

            var lastPreset = presets.OrderByDescending(p => p.Id).FirstOrDefault();

            // Act
            var retrievedPreset = await _presetDAO.GetLastPresetByDeviceIdAsync(deviceId);

            // Assert
            Assert.NotNull(retrievedPreset);
            Assert.AreEqual(lastPreset?.Id, retrievedPreset.Id);
            // Add more assertions as needed
        }

        [Test]
        public async Task GetLastPresetByDeviceIdAsync_WhenNoPresetsExistForDeviceId_ShouldReturnNull()
        {
            // Arrange
            var deviceId = 2; // Assuming a device ID

            // Act
            var retrievedPreset = await _presetDAO.GetLastPresetByDeviceIdAsync(deviceId);

            // Assert
            Assert.Null(retrievedPreset);
        }

        [Test]
        public async Task ActivatePresetAsync_WhenPresetExists_ShouldActivateAndReturnPreset()
        {
            // Arrange
            var preset = new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false);
            _dataContext.Presets.Add(preset);
            await _dataContext.SaveChangesAsync();

            // Act
            var activatedPreset = await _presetDAO.ActivatePresetAsync(preset.Id);

            // Assert
            Assert.NotNull(activatedPreset);
            Assert.IsTrue(activatedPreset.isActive);
            // Add more assertions as needed
        }

        [Test]
        public void ActivatePresetAsync_WhenPresetDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var presetId = 123; // Assuming an ID that doesn't exist

            // Act and Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _presetDAO.ActivatePresetAsync(presetId));
        }

        [Test]
        public async Task GetActivePresetAsync_WhenActivePresetExistsForDeviceId_ShouldReturnActivePreset()
        {
            // Arrange
            var deviceId = 1; // Assuming a device ID
            
            var activePipireset =  new Preset(2, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false);

            var activePreset =  new Preset(1, "Preset1", 100, 400, 100, 2000, 10, 30, 50, 1, false);
            _dataContext.Presets.Add(activePreset);
            _dataContext.Presets.Add(activePipireset);
            await _dataContext.SaveChangesAsync();
            await _presetDAO.ActivatePresetAsync(1);

            // Act
            var retrievedPreset = await _presetDAO.GetActivePresetAsync(deviceId);

            // Assert
            Assert.NotNull(retrievedPreset);
            Assert.AreEqual(activePreset.Id, retrievedPreset.Id);
            // Add more assertions as needed
        }

        [Test]
        public async Task GetActivePresetAsync_WhenNoActivePresetExistsForDeviceId_ShouldReturnNull()
        {
            // Arrange
            var deviceId = 123; // Assuming a device ID

            // Act
            var retrievedPreset = await _presetDAO.GetActivePresetAsync(deviceId);

            // Assert
            Assert.Null(retrievedPreset);
        }
    }

        