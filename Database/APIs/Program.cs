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


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IIOTDeviceDAO, IOTDeviceDAO>();
builder.Services.AddScoped<IUserDao, UserDAO>();
builder.Services.AddScoped<IMeasurementDAO, MeasurementDAO>();
builder.Services.AddScoped<IPresetDAO, PresetDAO>();
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
                    Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<Tokens>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
string st = @"
{
    ""cmd"": ""rx"",
    ""seqno"": 2746,
    ""EUI"": ""0004A30B00E7E212"",
    ""ts"": 1682681047297,
    ""fcnt"": 8,
    ""port"": 2,
    ""freq"": 867100000,
    ""rssi"": -116,
    ""snn"": -13,
    ""toa"": 0,
    ""dr"": ""SF12 BW125 4/5"",
    ""ack"": false,
    ""bat"": 255,
    ""offline"": false,
    ""data"": ""039201a1010b01""
}";

DataContext dataContext = new DataContext();

MeasurementDAO msdao = new MeasurementDAO(dataContext);

WebsocketClient server = new WebsocketClient();

await server.ProcessReceivedDataAsync(st);
app.Run();