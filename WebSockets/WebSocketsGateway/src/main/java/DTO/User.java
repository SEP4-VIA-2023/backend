package DTO;

import lombok.Data;
import org.springframework.stereotype.Component;

@Component
@Data
public class  User
{    private int id;
    private String username;
    private String password;
    private String email;
}
