package APIs;

import DTO.LoginRequest;
import DTO.TokenRequest;
import DTO.User;
import DTO.gRPCConverter;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.apache.coyote.Response;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import protos.UserObj;
import protos.UserServiceGrpc;

@RestController
public class AuthenticationController
{

    @PostMapping("/login")
    public ResponseEntity<String> login(@RequestBody LoginRequest loginRequest)
    {
        // Authenticate user and generate JWT token
        String token = JwtUtils.generateToken(loginRequest.getUsername(), loginRequest.getPassword());

        // Return token as response
        return new ResponseEntity<>(token, HttpStatus.OK);


    }

    @PostMapping("/validate")
    public ResponseEntity<Void> validate(@RequestBody TokenRequest tokenRequest)
    {
        boolean isValid = JwtUtils.validateToken(tokenRequest.getToken());

        if (isValid)
        {
            return new ResponseEntity<>(HttpStatus.OK);
        } else
        {
            return new ResponseEntity<>(HttpStatus.UNAUTHORIZED);
        }
    }

    @PostMapping("/signup")
    public ResponseEntity<Void> signUp(@RequestBody User user)
    {
        ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 5001)
                .usePlaintext()
                .build();

        UserServiceGrpc.UserServiceBlockingStub stub
                = UserServiceGrpc.newBlockingStub(channel);

        UserObj userObj = gRPCConverter.getGrpcUserFromUser(user);

        UserObj helloResponse2 = stub.addUser(userObj);
        System.out.println(helloResponse2);

        return new ResponseEntity <>(HttpStatus.OK);
    }


}


