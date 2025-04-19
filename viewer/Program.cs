using Microsoft.AspNetCore.Builder;
using viewer.Hubs;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging.ServiceBus;
using Azure.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Use Managed Identity
builder.Services.AddSingleton<ServiceBusClient>(provider =>
{
    var namespaceFQDN = "viewexeservicesub.servicebus.windows.net";
    var credential = new DefaultAzureCredential();
    return new ServiceBusClient(namespaceFQDN, credential);
});

builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddControllers();
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Serve UI at /swagger
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<GridEventsHub>("/hubs/gridevents");
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();

