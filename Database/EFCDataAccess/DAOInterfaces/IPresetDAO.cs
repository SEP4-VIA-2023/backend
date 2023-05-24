using Model;

namespace EFCDataAccess;

public interface IPresetDAO
{
    public Task<Preset> CreateAsync(Preset preset);
    public Task<Preset?> GetByIdAsync(int id);
    public Task<List<Preset>> GetByDeviceIdAsync(int id);
    public Task<List<Preset>> GetAllAsync();
    public Task<Preset> UpdateAsync(Preset preset);
    public Task<Preset> DeleteAsync(int id);
}