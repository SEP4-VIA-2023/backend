package DTO;


import lombok.Data;
import org.springframework.stereotype.Component;

@Component
@Data
public class Preset {
    private int Id;
    private String Name;
    private float MinHumidity;
    private float MaxHumidity;
    private float MinTemperature;
    private float MaxTemperature;
    private float MinCo2;
    private float MaxCo2;
    private String DeviceId;

}
