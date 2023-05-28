using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using System;

namespace EFCDataAccess.DAOs
{
    public class MeasurementDAO : IMeasurementDAO
    {
        private DataContext _dataContext;

        public MeasurementDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Measurement> CreateAsync(Measurement measurement)
        {
            // Convert the DateTime value to UTC
            measurement.Time = measurement.Time.ToUniversalTime();

            EntityEntry<Measurement> entityEntry = _dataContext.Measurements.Add(measurement);
            await _dataContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<List<Measurement>> GetAllAsync()
        {
            return await _dataContext.Measurements.ToListAsync();
        }

        public async Task<List<Measurement>> GetAllByDeviceIdAsync(int deviceId)
        {
            return await _dataContext.Measurements.Where(m => m.DeviceId == deviceId).ToListAsync();
        }

        public async Task<List<Measurement>> GetAllAfterTimeAsync(DateTime time)
        {
            // Convert the DateTime value to UTC
            time = time.ToUniversalTime();

            return await _dataContext.Measurements.Where(m => m.Time > time).ToListAsync();
        }
    }
}