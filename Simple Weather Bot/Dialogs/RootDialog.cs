using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Simple_Weather_Bot.API;

namespace Simple_Weather_Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
            WeatherModel model = await WeatherAPI.GetWeatherInCity(activity.Text);
     
            await context.PostAsync($"Temperature in {activity.Text} is " + model.main.getTempInFahrenheit());

            // return our reply to the user
            await context.PostAsync("Kelvin temp is " + model.main.temp);

            context.Wait(MessageReceivedAsync);
        }
    }
}