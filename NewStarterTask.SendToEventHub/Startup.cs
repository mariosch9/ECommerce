using Aquifer.DataPipe.Events.EventReceiver.Factories;
using Aquifer.DataPipe.Events.EventReceiver.Interfaces;
using Aquifer.DataPipe.Events.EventSender.Factories;
using Aquifer.DataPipe.Events.EventSender.Interfaces;
using Aquifer.DataPipe.EventTriggerFunction.Common;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NewStarterTask.BusinessLogic.Services;
using NewStarterTask.Core.Interfaces;
using NewStarterTask.SendToEventHub.Services;
using NewStarterTask.SendToEventHub.Services.Interfaces;
using NewStarterTask.SendToStorage.Configuration;
using System;

[assembly: FunctionsStartup(typeof(NewStarterTask.SendToEventHub.Startup))]
namespace NewStarterTask.SendToEventHub
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            try
            {
                builder.Services
                    .AddOptions<ApplicationSettings>()
                    .Configure<IConfiguration>((settings, configuration) =>
                    {
                        configuration.Bind(settings);
                    });

                builder.Services.AddSingleton<IEventSenderFactory, EventSenderFactory>();
                builder.Services.AddSingleton<IEventSender>(c =>
                {
                    var configuration = c.GetService<IConfiguration>();
                    IEventSenderFactory eventSenderFactory = c.GetRequiredService<IEventSenderFactory>();
                    try
                    {
                        var eventHubConnection = configuration.GetValue<string>("DestinationEventHubConnectionString");
                        var destEventHubName = configuration.GetValue<string>("DestinationEventHubName");
                        return eventSenderFactory.CreateEventSender(eventHubConnection, destEventHubName);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                });


                builder.Services
                    .AddSingleton<LogHelperFunctions>()
                    .AddSingleton<IEventReceiverFactory, EventReceiverFactory>()
                    .AddSingleton<ISenderToHubService, SenderToHubService>()
                    .AddScoped<IEventReceiver>(c =>
                    {
                        var applicationSettings = c.GetRequiredService<IOptions<ApplicationSettings>>();
                        IEventReceiverFactory eventReceiverFactory = c.GetRequiredService<IEventReceiverFactory>();
                        return eventReceiverFactory.CreateEventReceiver(applicationSettings.Value.SourceEventHubConnectionString,
                            applicationSettings.Value.SourceEventHubName, applicationSettings.Value.SourceEventHubConsumerGroup,
                            applicationSettings.Value.DataLakeConnectionString);

                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}