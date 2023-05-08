package DTO;

import org.junit.jupiter.api.*;

public class TokenRequestTest {

    private TokenRequest tokenRequest;

    @BeforeEach
    public void setUp() {
        tokenRequest = new TokenRequest("ABC123");
    }

    @Test
    public void getToken_shouldReturnToken() {
        String expectedToken = "ABC123";
        String actualToken = tokenRequest.getToken();
        Assertions.assertEquals(expectedToken, actualToken);
    }

    @Test
    public void setToken_shouldSetToken() {
        String newToken = "XYZ789";
        tokenRequest.setToken(newToken);
        Assertions.assertEquals(newToken, tokenRequest.getToken());
    }
}