using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCDataAccess.DAOs;

public class PresetDAO: IPresetDAO
{
    private DataContext _dataContext;

    public PresetDAO(DataContext dataContext)
    {
        _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    public async Task<Preset> CreateAsync(Preset preset)
    {
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
    public async  Task<List<Preset>>GetByDeviceIdAsync(int id)
    {
        return await _dataContext.Presets.Where(u => u.DeviceId == id).ToListAsync();
    }

    public async Task<List<Preset>> GetAllAsync()
    {
        return await _dataContext.Presets.ToListAsync();
    }

    public async Task<Preset> UpdateAsync(Preset preset)
    {
        _dataContext.Presets.Update(preset);
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
}