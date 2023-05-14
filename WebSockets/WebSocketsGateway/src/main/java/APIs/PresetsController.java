
package APIs;

import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import io.grpc.StatusRuntimeException;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import protos.*;

@RestController
@RequestMapping("/api/presets")
public class PresetsController {

    @PostMapping(value ="/create", produces = MediaType.APPLICATION_JSON_UTF8_VALUE)
    public ResponseEntity<Void> createPreset(@RequestBody DTO.Preset preset) {

        try {
            // Connect to the gRPC server
            ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 5001).usePlaintext().build();

            // Create a stub to invoke the gRPC method to save the preset
            PresetServiceProtoGrpc.PresetServiceProtoBlockingStub stub = PresetServiceProtoGrpc.newBlockingStub(channel);
            System.out.printf("Preset: %s\n", preset);
            // Create a Protobuf message representing the preset
            PresetObj protoPreset = PresetObj.newBuilder()
                    .setId(preset.getId())
                    .setName(preset.getName())
                    .setMinHumidity(preset.getMinHumidity())
                    .setMaxHumidity(preset.getMaxHumidity())
                    .setMinCo2(preset.getMinCo2())
                    .setMaxCo2(preset.getMaxCo2())
                    .setMinTemperature(preset.getMinTemperature())
                    .setMaxTemperature(preset.getMaxTemperature())
                    .setDeviceId(preset.getDeviceId())

                    .build();

            // Invoke the gRPC method to save the preset
            CreatePresetRequest request = CreatePresetRequest.newBuilder().setPreset(protoPreset).build();
           CreatePresetResponse response = stub.createPreset(request);

            // Close the gRPC channel
            channel.shutdown();



            return new ResponseEntity<>(HttpStatus.OK);
        } catch (StatusRuntimeException e) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
}

