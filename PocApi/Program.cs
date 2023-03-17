using PocApi.Api;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddBusiness();
builder.Services.AddRepository();

builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddUnitOfWork();

var app = builder.Build();

app.CreateDataBaseIfNotExist();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
