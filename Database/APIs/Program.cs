using EFCDataAccess;
using EFCDataAccess.DAOs;

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();