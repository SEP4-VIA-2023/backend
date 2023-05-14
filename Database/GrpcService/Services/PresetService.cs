using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.models;
using Grpc.Core;
using Proto;

namespace GrpcService.Services;

public class PresetService : PresetServiceProto.PresetServiceProtoBase
{

    private readonly DatabaseAccess _databaseAccess;
    
    public PresetService(DatabaseAccess databaseAccess)
    {
        _databaseAccess = databaseAccess;
    }

    public override async Task<CreatePresetResponse> CreatePreset(CreatePresetRequest request, ServerCallContext context)
    {
        Preset preset = new Preset()
        {
            Id = request.Preset.Id,
            Name = request.Preset.Name,
            MinHumidity = Convert.ToInt32(request.Preset.MinHumidity),
            MaxHumidity = Convert.ToInt32(request.Preset.MaxHumidity),
            MinCo2 = Convert.ToInt32(request.Preset.MinCo2),
            MaxCo2 = Convert.ToInt32(request.Preset.MaxCo2),
            MinTemperature = Convert.ToInt32(request.Preset.MinTemperature),
            MaxTemperature = Convert.ToInt32(request.Preset.MaxTemperature),
            DeviceId = Convert.ToInt32(request.Preset.DeviceId)
        };

        Preset addedPreset = _databaseAccess.AddPreset(preset);

        return new CreatePresetResponse
        {
            Preset = new PresetObj
            {
                Id = addedPreset.Id,
                Name = addedPreset.Name,
                MinHumidity = addedPreset.MinHumidity,
                MaxHumidity = addedPreset.MaxHumidity,
                MinCo2 = addedPreset.MinCo2,
                MaxCo2 = addedPreset.MaxCo2,
                MinTemperature = addedPreset.MinTemperature,
                MaxTemperature = addedPreset.MaxTemperature,
                DeviceId = Convert.ToString(addedPreset.DeviceId)
            }
        };
    }

    public override async Task<DeletePresetResponse> DeletePreset(DeletePresetRequest request,
        ServerCallContext context)
    {
        int presetId = int.Parse(request.Id);

        _databaseAccess.DeletePreset(presetId);

        return new DeletePresetResponse
        {
            Id = request.Id
        };
    }

    public override async Task<GetPresetResponse> GetPreset(GetPresetRequest request, ServerCallContext context)
    {
        int presetId = int.Parse(request.Id);

        Preset preset = _databaseAccess.GetPresetById(presetId);

        return new GetPresetResponse
        {
            Preset = new PresetObj()
            {
                Id = preset.Id,
                Name = preset.Name,
                MinHumidity = preset.MinHumidity,
                MaxHumidity = preset.MaxHumidity,
                MinCo2 = preset.MinCo2,
                MaxCo2 = preset.MaxCo2,
                MinTemperature = preset.MinTemperature,
                MaxTemperature = preset.MaxTemperature,
                DeviceId = Convert.ToString(preset.DeviceId)
            }
        };
    }

    /*public override async Task<ListPresetsResponse> ListPresets(ListPresetsRequest request,
        ServerCallContext context)
    {
        int limit = request.Limit;

        List<Preset> presets = _databaseAccess.GetAllPresets().Take(limit).ToList();

        List<Preset> presetList = presets.Select(preset => new Preset
        {
            Id = preset.Id,
            Name = preset.Name,
            MinHumidity = preset.MinHumidity,
            MaxHumidity = preset.MaxHumidity,
            MinCo2 = preset.MinCo2,
            MaxCo2 = preset.MaxCo2,
            MinTemperature = preset.MinTemperature,
            MaxTemperature = preset.MaxTemperature,
            DeviceId = preset.DeviceId
        }).ToList();

        return new ListPresetsResponse
        {
            Presets = { presetList }
        }
    }*/
}

                    