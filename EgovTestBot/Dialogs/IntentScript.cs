using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EgovTestBot.Dialogs
{
    public class IntentScript
    {

        protected string response;

        public string[] GreetingElements = {
            "Buna",
            "Salut",
            "Buna ziua"
        };
        public string[] FarewellsElements =
        {
            "La revedere",
            "O zi bună",
            "Toate cele bune"
        };

        public string intentAnalyze(string Intent) {
            Random random = new Random();
            int x = random.Next(0, 2);
            
            switch (Intent)
            {
                case "Greeting":
                    response =  GreetingElements.GetValue(x) + ". Cu ce vă pot ajuta?";
                    break;

                case "Serviciu":
                    response = "Iata lista de servicii.";
                    break;

                case "Help":
                    response = "La moment eu nu dispun de informație.";
                    break;

                case "Cancel":
                    response = "Să opresc operația.";
                    break;

                case "None":
                    response = "Nu dețin destulă informație!";
                    break;
            }
            return response;
        }


    }
}