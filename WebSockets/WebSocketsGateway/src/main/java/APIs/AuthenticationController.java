package APIs;

import DTO.LoginRequest;
import DTO.TokenRequest;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class AuthenticationController {

    @PostMapping("/login")
    public ResponseEntity<String> login(@RequestBody LoginRequest loginRequest) {
        // Authenticate user and generate JWT token
        String token = JwtUtils.generateToken(loginRequest.getUsername(),loginRequest.getPassword());

        // Return token as response
        return new ResponseEntity<>(token, HttpStatus.OK);


    }

    @PostMapping("/validate")
    public ResponseEntity<Void> validate(@RequestBody TokenRequest tokenRequest) {
        boolean isValid = JwtUtils.validateToken(tokenRequest.getToken());

        if (isValid) {
            return new ResponseEntity<>(HttpStatus.OK);
        } else {
            return new ResponseEntity<>(HttpStatus.UNAUTHORIZED);
        }
    }
}


