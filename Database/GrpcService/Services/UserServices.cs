using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.models;
using Grpc.Core;

using Proto;

namespace GrpcService.Services;

public class UserServices : UserService.UserServiceBase
{
    private readonly DatabaseAccess _databaseAccess;

    public UserServices(DatabaseAccess databaseAccess)
    {
        _databaseAccess = databaseAccess;
    }

    public override async Task<UserObj> AddUser(UserObj request, ServerCallContext context)
    {
        try
        {
            User addingUser = new User()
            {
                Name = request.Username,
                Password = request.Password,
                Email = request.Email,
            };
            User addedUser = _databaseAccess.AddUser(addingUser);


            UserObj userObj = new UserObj()
            {
                Id = addedUser.Id,
                Username = addedUser.Name,
                Password = addedUser.Password,
                Email = addedUser.Email,

            };
            Console.WriteLine("User added");
            return userObj;
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.PermissionDenied, e.Message));
        }
    }

    public override Task<UserObj> GetUser(Username request, ServerCallContext context)
    {
        try
        {
            User user = _databaseAccess.GetAllUsers().FirstOrDefault(u => u.Name == request.Username_)!;
            UserObj userToSend = new UserObj()
            {
                Id = user.Id,
                Username = user.Name,
                Password = user.Password,
                Email = user.Email,

            };
            Console.WriteLine("User found");
            return Task.FromResult(userToSend);
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }
}



