using Aquifer.DataPipe.Events.EventSender.Factories;
using Aquifer.DataPipe.Events.EventSender.Interfaces;
using NewStarterTask.BusinessLogic.Extensions;
using NewStaterTask.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEventSenderFactory, EventSenderFactory>();
builder.Services.AddSingleton<IEventSender>(c =>
{
    var configuration = c.GetService<IConfiguration>();
    IEventSenderFactory eventSenderFactory = c.GetRequiredService<IEventSenderFactory>();
    try
    {
        var eventHubConnection = configuration.GetValue<string>("EventHubNamespace");
        var destEventHubName = configuration.GetValue<string>("EventHub");
        return eventSenderFactory.CreateEventSender(eventHubConnection, destEventHubName);
    }
    catch (Exception)
    {
        return null;
    }
});

builder.Services.AddRepositories();
builder.Services.AddServices();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
