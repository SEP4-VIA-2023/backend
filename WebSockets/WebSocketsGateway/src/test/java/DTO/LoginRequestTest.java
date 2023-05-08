package DTO;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class LoginRequestTest {
    private LoginRequest loginRequest;

    @BeforeEach
    public void setUp() {
        loginRequest = new LoginRequest("testuser", "testpass");
    }

    @Test
    public void getUsername_shouldReturnUsername() {
        String expectedUsername = "testuser";
        String actualUsername = loginRequest.getUsername();
        assertEquals(expectedUsername, actualUsername);
    }

    @Test
    public void setUsername_shouldSetUsername() {
        String newUsername = "newuser";
        loginRequest.setUsername(newUsername);
        assertEquals(newUsername, loginRequest.getUsername());
    }

    @Test
    public void getPassword_shouldReturnPassword() {
        String expectedPassword = "testpass";
        String actualPassword = loginRequest.getPassword();
        assertEquals(expectedPassword, actualPassword);
    }

    @Test
    public void setPassword_shouldSetPassword() {
        String newPassword = "newpass";
        loginRequest.setPassword(newPassword);
        assertEquals(newPassword, loginRequest.getPassword());
    }
}