using Model;

namespace Logic.Interface;

public interface IDeviceLogic
{
    Task<IOTDevice> CreateDevice(IOTDeviceDTO dto);
}