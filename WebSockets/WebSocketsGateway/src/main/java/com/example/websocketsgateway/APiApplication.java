package com.example.websocketsgateway;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

@SpringBootApplication
@ComponentScan("APIs") // Replace with the package name of your application
public class APiApplication {

    public static void main(String[] args) {
        SpringApplication.run(APiApplication.class, args);
    /*    SpringApplication.run(WebSocketsGatewayApplication.class, args);*/
    }
}
