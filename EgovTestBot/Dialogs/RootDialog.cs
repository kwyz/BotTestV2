using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace EgovTestBot.Dialogs
{
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        QueryRecognition qr = new QueryRecognition();

        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"],
            ConfigurationManager.AppSettings["LuisAPIKey"],
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }
        //public readonly List<string> intentNameMy = new List<string>(new string[] { "None", "element2", "element3" });
        public readonly string intentNameMY = "None";
   
        [LuisIntent(intentName: intentNameMY)]




        //public async Task NoneIntent(IDialogContext context, LuisResult result)
        //{
        //    await this.qr.ShowLuisResult(context, result);
        //    context.Wait(MessageReceived);
        //}

        //public async Task TimeIntent(IDialogContext context, LuisResult result)
        //{
        //    await this.qr.ShowLuisResult(context, result);
        //    await TimeIntent( context, result);
        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("Costul prestarii serviciului")]
        //public async Task PretIntent(IDialogContext context, LuisResult result)
        //{
        //    await this.qr.ShowLuisResult(context, result);
        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("Adresa si datele de contact")]
        //public async Task AdresaIntent(IDialogContext context, LuisResult result)
        //{
        //    await this.qr.ShowLuisResult(context, result);
        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("Informatie generala")]
        //public async Task InfoIntent(IDialogContext context, LuisResult result)
        //{
        //    await this.qr.ShowLuisResult(context, result);
        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("Documentele necesare")]
        //public async Task DocumentIntent(IDialogContext context, LuisResult result)
        //{
        //    await this.qr.ShowLuisResult(context, result);
        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("Acte normative")]
        //public async Task acteIntent(IDialogContext context, LuisResult result)
        //{
        //    await this.qr.ShowLuisResult(context, result);
        //    context.Wait(MessageReceived);
        //}






    }
}