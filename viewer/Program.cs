using Microsoft.AspNetCore.Builder;
using viewer.Hubs;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging.ServiceBus;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Use Managed Identity
builder.Services.AddSingleton<ServiceBusClient>(provider =>
{
    var namespaceFQDN = "viewexeservicesub.servicebus.windows.net";
    var credential = new DefaultAzureCredential();
    return new ServiceBusClient(namespaceFQDN, credential);
});

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSignalR();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<GridEventsHub>("/hubs/gridevents");
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

