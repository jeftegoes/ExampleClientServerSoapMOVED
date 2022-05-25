using ServiceReference;
using SoapClientServiceReference.Interceptor;
using static ServiceReference.CalculatorSoapClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICalculatorSoapClient>(x =>
{
    var client = new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap);

    var requestInterceptor = new InspectorBehavior();
    client.Endpoint.EndpointBehaviors.Add(requestInterceptor);

    return client;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
