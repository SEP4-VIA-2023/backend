using System.Text;
using Logic.Interface;
// using Logic.Logic;
using Logic.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EFCDataAccess;
using EFCDataAccess.DAOs;
using WebSockets.Gateway;
using Microsoft.AspNetCore.Hosting;
using Logic.Logic;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddScoped<IIOTDeviceDAO, IOTDeviceDAO>();
builder.Services.AddScoped<IUserDao, UserDAO>();
builder.Services.AddScoped<IMeasurementDAO, MeasurementDAO>();
builder.Services.AddScoped<IPresetDAO, PresetDAO>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder!.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IDeviceLogic, DeviceLogic>();
builder.Services.AddScoped<Tokens>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
string st = @"
{
    ""cmd"": ""rx"",
    ""EUI"": ""0004A30B00251192"",
    ""ts"": 1682681047297,
    ""fcnt"": 8,
    ""port"": 2,
    ""ack"": false,
    ""data"": ""039201a1010b01""

}";

DataContext dataContext = new DataContext();

/*MeasurementDAO msdao = new MeasurementDAO(dataContext);

WebsocketClient server = new WebsocketClient();

await server.ProcessReceivedDataAsync(st);*/

WebsocketClient wbclient = new WebsocketClient();

string url = "wss://iotnet.cibicom.dk/app?token=vnoUBQAAABFpb3RuZXQuY2liaWNvbS5ka4lPPjDJdv8czIiFOiS49tg=";
wbclient.ConnectAsync(url);

/*ConfigService cfg = new ConfigService();

ushort minCO2 = await cfg.GetMinCO2Value();
ushort maxCO2 = await cfg.GetMaxCO2Value();
ushort minHumidity = await cfg.GetMinHumidityValue();
ushort maxHumidity = await cfg.GetMaxHumidityValue();
short minTemp = await cfg.GetMinTempValue();
short maxTemp = await cfg.GetMaxTempValue();
sbyte rotationPercentage = await cfg.GetRotationPercentageValue();


Console.WriteLine(cfg.ConfigurationToString());*/

app.Run();