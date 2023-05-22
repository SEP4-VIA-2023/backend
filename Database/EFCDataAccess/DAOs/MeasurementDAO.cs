using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCDataAccess.DAOs;

public class MeasurementDAO: IMeasurementDAO
{
    private DataContext _dataContext;

    public MeasurementDAO(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Measurement> CreateAsync(Measurement measurement)
    {
        EntityEntry<Measurement> entry = _dataContext.Measurements.Add(measurement);
        await _dataContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Measurement?> GetAsync(int id)
    {
        Measurement? existing = await _dataContext.Measurements.FirstOrDefaultAsync(u =>
            u.Id == id);
        return existing;
    }

    public async Task<List<Measurement>> GetAllAsync()
    {
        return await _dataContext.Measurements.ToListAsync();
    }
}