using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCDataAccess.DAOs;

public class PresetDAO : IPresetDAO
{
    private DataContext _dataContext;

    public PresetDAO(DataContext dataContext)
    {
        _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    public async Task<Preset> CreateAsync(Preset preset)
    {
        // Check if the preset with the same name already exists
        bool presetExists = await _dataContext.Presets.AnyAsync(u =>
            u.Name.ToLower() == preset.Name.ToLower()
        );

        if (presetExists)
        {
            throw new InvalidOperationException("A preset with the same name already exists.");
        }

        EntityEntry<Preset> entry = _dataContext.Presets.Add(preset);
        await _dataContext.SaveChangesAsync();
        return entry.Entity;
    }


    public async Task<Preset?> GetByIdAsync(int id)
    {
        Preset? existing = await _dataContext.Presets.FirstOrDefaultAsync(u =>
            u.Id == id);
        return existing;
    }

    public async Task<List<Preset>> GetByDeviceIdAsync(int id)
    {
        return await _dataContext.Presets.Where(u => u.DeviceId == id).ToListAsync();
    }

    public async Task<List<Preset>> GetAllAsync()
    {
        return await _dataContext.Presets.ToListAsync();
    }

    public async Task<Preset> UpdateAsync(int presetId, Preset updatedPreset)
    {
        var preset = await _dataContext.Presets.FindAsync(presetId);

        if (preset == null)
        {
            throw new ArgumentException("Preset not found");
        }

        // Update the preset properties with the new values
        preset.Name = updatedPreset.Name;
        preset.MinHumidity = updatedPreset.MinHumidity;
        preset.MaxHumidity = updatedPreset.MaxHumidity;
        preset.MinCo2 = updatedPreset.MinCo2;
        preset.MaxCo2 = updatedPreset.MaxCo2;
        preset.MinTemperature = updatedPreset.MinTemperature;
        preset.MaxTemperature = updatedPreset.MaxTemperature;
        preset.Servo = updatedPreset.Servo;
        preset.DeviceId = updatedPreset.DeviceId;
        // ... update other properties as needed

        await _dataContext.SaveChangesAsync();

        return preset;
    }


    public async Task<Preset> DeleteAsync(int id)
    {
        _dataContext.Presets.Remove(await _dataContext.Presets.FirstOrDefaultAsync(u =>
            u.Id == id));
        await _dataContext.SaveChangesAsync();
        return null!;
    }

    public async Task<Preset> GetLastPresetByDeviceIdAsync(int deviceId)
    {
        return await _dataContext.Presets
            .Where(p => p.DeviceId == deviceId)
            .OrderByDescending(p => p.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<Preset> ActivatePresetAsync(int id)
    {
        // Get the preset to activate
        Preset presetToActivate = await _dataContext.Presets.FindAsync(id);

        if (presetToActivate == null)
        {
            throw new InvalidOperationException("Preset not found.");
            // You can choose to return a specific error response or handle the exception as per your application's requirements.
        }

        // Deactivate any currently active preset
        Preset activePreset = await _dataContext.Presets.FirstOrDefaultAsync(p => p.isActive);
        if (activePreset != null)
        {
            activePreset.isActive = false;
        }

        // Activate the selected preset
        presetToActivate.isActive = true;

        await _dataContext.SaveChangesAsync();
        return presetToActivate;
    }

    public async Task<Preset> GetActivePresetAsync(int deviceId)
    {
        return await _dataContext.Presets.FirstOrDefaultAsync(p => p.DeviceId == deviceId && p.isActive);
    }
}