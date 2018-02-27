using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using EgovTestBot.AzureTable;
using Microsoft.Bot.Connector;
using EgovTestBot.Dialog;
using System.Threading;
using System.Web;

namespace EgovTestBot.Dialogs
{
    [Serializable]
    public class QueryRecognition
    {

        [NonSerialized]
        Timer t;

        public const string Intent_None = "None";
        public const string Intent_Serviciu = "Serviciu";
        

        public async Task ShowLuisResult(IDialogContext context, LuisResult result)
        { 
            string entities = this.BotEntityRecognition(Intent_Serviciu, result);
            GetInfoFromTable getInfoFromTable = new GetInfoFromTable();

            string queryresult = null;


            //for (int i = 0; i < result.Intents.Count; i++)
            //{
            //    string roundedScore = result.Intents[i].Score != null ? (Math.Round(result.Intents[i].Score.Value, 2).ToString()) : "0";

            //    await context.PostAsync($"**Query**: {result.Query}, **Intent**: {result.Intents[i].Intent}, **Score**: {roundedScore}. **Entities**: {result.Entities[i].Type}");
            //     = getInfoFromTable.By(result.Intents[i].Intent, result.Entities[i].Type);




            //}
            //await context.PostAsync(queryresult);





        }

        public string BotEntityRecognition(string intentName, LuisResult result)
        {
            IList<EntityRecommendation> listOfEntitiesFound = result.Entities;
            StringBuilder entityResults = new StringBuilder();

            foreach (EntityRecommendation item in listOfEntitiesFound)
            {
                // Query: Turn on the [light]
                // item.Type = "HomeAutomation.Device"
                // item.Entity = "light"
                entityResults.Append(item.Entity + "-");
            }
            if (entityResults.Length > 0)
                // remove last comma
                entityResults.Remove(entityResults.Length - 1, 1);

            return entityResults.ToString();
        }


        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            //We need to keep this data so we know who to send the message to. Assume this would be stored somewhere, e.g. an Azure Table
            ConversationStarter.toId = message.From.Id;
            ConversationStarter.toName = message.From.Name;
            ConversationStarter.fromId = message.Recipient.Id;
            ConversationStarter.fromName = message.Recipient.Name;
            ConversationStarter.serviceUrl = message.ServiceUrl;
            ConversationStarter.channelId = message.ChannelId;
            ConversationStarter.conversationId = message.Conversation.Id;

            //We create a timer to simulate some background process or trigger
            t = new Timer(new TimerCallback(timerEvent));
            t.Change(5000, Timeout.Infinite);

            var url = HttpContext.Current.Request.Url;
            //We now tell the user that we will talk to them in a few seconds
            await context.PostAsync("Hello! In a few seconds I'll send you a message proactively to demonstrate how bots can initiate messages. You can also make me send a message by accessing: " +
                    url.Scheme + "://" + url.Host + ":" + url.Port + "/api/CustomWebApi");
            context.Wait(MessageReceivedAsync);
        }
        public void timerEvent(object target)
        {

            t.Dispose();
            ConversationStarter.Resume(ConversationStarter.conversationId, ConversationStarter.channelId); //We don't need to wait for this, just want to start the interruption here
        }


    }
}