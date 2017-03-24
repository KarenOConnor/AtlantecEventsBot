using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Sorry, I couldn't find what you were looking for. Please try again."); //
        context.Wait(MessageReceived);
    }
    
    [LuisIntent("Greeting")]
    public async Task GreetingIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hello!"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("EventLocation")]
    public async Task EventLocationIntent(IDialogContext context, LuisResult result)
    {
        context.Wait(MessageReceived);
        EntityRecommendation locEntityRecommendation;
        if (result.TryFindEntity("Location", out locEntityRecommendation))
        {
              await context.PostAsync($"Location: {locEntityRecommendation.Entity.ToString()}");
        }
        
        EntityRecommendation datetimeEntityRecommendation;
        if (result.TryFindEntity("EventDate", out datetimeEntityRecommendation))
        {
              await context.PostAsync($"Date: {datetimeEntityRecommendation.Entity.ToString()}");
        }
       
    }
    
    [LuisIntent("BookEvent")]
    public async Task BookEventIntent(IDialogContext context, LuisResult result)
    {
        context.Wait(MessageReceived);
        EntityRecommendation locEntityRecommendation;
        if (result.TryFindEntity("Location", out locEntityRecommendation))
        {
              await context.PostAsync($"Location: {locEntityRecommendation.Entity.ToString()}");
        }
        
        EntityRecommendation datetimeEntityRecommendation;
        if (result.TryFindEntity("EventDate", out datetimeEntityRecommendation))
        {
              await context.PostAsync($"Date: {datetimeEntityRecommendation.Entity.ToString()}");
        }
        
        EntityRecommendation eventEntityRecommendation;
        if (result.TryFindEntity("Event", out eventEntityRecommendation))
        {
              await context.PostAsync($"Event: {eventEntityRecommendation.Entity.ToString()}");
        }
        
        EntityRecommendation ticketEntityRecommendation;
        if (result.TryFindEntity("TicketNo", out ticketEntityRecommendation))
        {
              await context.PostAsync($"Number of tickets: {ticketEntityRecommendation.Entity.ToString()}");
        }
    }
}