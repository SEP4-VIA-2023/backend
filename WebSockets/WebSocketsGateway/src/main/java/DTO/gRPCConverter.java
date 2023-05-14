package DTO;

import protos.UserObj;

public class gRPCConverter
{
    public static UserObj getGrpcUserFromUser(User user)
    {
        UserObj userObj = UserObj.newBuilder()
                .setPassword(user.getPassword())
                .setUsername(user.getUsername())
                .build();
        return userObj;
    }

    public static User getUserFromGrpcUser(UserObj userObj)
    {
        User user = new User();
        user.setId(userObj.getId());
        user.setUsername(userObj.getUsername());
        user.setPassword(userObj.getPassword());
        user.setEmail(userObj.getEmail());
        return user;
    }


}