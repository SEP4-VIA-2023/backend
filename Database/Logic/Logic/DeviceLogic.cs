using EFCDataAccess;
using Logic.Interface;
using Model;

namespace Logic.Logic;

public class DeviceLogic : IDeviceLogic
{
    private readonly IIOTDeviceDAO _dataAccess;

    public DeviceLogic(IIOTDeviceDAO dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public async Task<IOTDevice> CreateDevice(IOTDeviceDTO dto)
    {
        if (await _dataAccess.GetByTokenAsync(dto.Token) != null)
        {
            throw new Exception("Device exists");
        }

        return await _dataAccess.CreateAsync(new IOTDevice(dto.Token, dto.UserId));
    }
}