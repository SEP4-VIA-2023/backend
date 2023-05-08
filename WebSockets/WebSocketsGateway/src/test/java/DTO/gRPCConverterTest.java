package DTO;

import org.junit.jupiter.api.Test;
import protos.UserObj;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotNull;

public class gRPCConverterTest {

    @Test
    public void testGetGrpcUserFromUser() {
        User user = new User();
        user.setUsername("alex");
        user.setPassword("password");

        UserObj userObj = gRPCConverter.getGrpcUserFromUser(user);

        // Check that the returned UserObj has the expected values
        assertEquals("alex", userObj.getUsername());
        assertEquals("password", userObj.getPassword());

        assertNotNull(userObj);
    }

    @Test
    public void testGetUserFromGrpcUser() {
        UserObj userObj = UserObj.newBuilder()
                .setUsername("alex")
                .setPassword("password")
                .build();

        User user = gRPCConverter.getUserFromGrpcUser(userObj);

        assertEquals("alex", user.getUsername());
        assertEquals("password", user.getPassword());
    }

}