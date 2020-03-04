using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace CoreBot.Cards
{
    public static class Cards
    {
        public static Attachment CreateAdaptiveCardAttachment()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Resources", "adaptiveCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        public static HeroCard GetHeroCard(object incident, object assigneeGrp, object booking,object desc,object priority )
        {
            var heroCard = new HeroCard
            {
                Title = "INCIDENT: " +incident.ToString() + " created successfully",
                Subtitle = "Title: " + booking.ToString() + "",
                Text = "Details: " + desc.ToString() + ", "+ "Priority: "+ priority,
                Images = new List<CardImage> { new CardImage("http://localhost:3978/Images/Logo.png") },
                
                // Images = new List<CardImage> { new CardImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX4EE5eYZ625C03SfumsuK13kIcpm5nNzJMVyYbVByByuHq--cA") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Assigned to: " + assigneeGrp, value: "#") },
            };

            return heroCard;
        }


        public static HeroCard GetHeroCardConfirm( object booking, object desc, object priority)
        {
            var heroCard = new HeroCard
            {
                Title = "Incident Title: " + booking.ToString() + "",
                Subtitle = "Description: " + desc.ToString() + "",
                Text = "Priority: " + priority.ToString() + "",
                Images = new List<CardImage> { new CardImage("http://localhost:3978/Images/Logo.png") },
               
                //Images = new List<CardImage> { new CardImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX4EE5eYZ625C03SfumsuK13kIcpm5nNzJMVyYbVByByuHq--cA") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Press \"Yes\" to Confirm", value: "#") },
            };

            return heroCard;
        }


        public static HeroCard GetHeroCardforStatus(object incident, object booking, object desc)
        {
            var heroCard = new HeroCard
            {
                Title = "INCIDENT NO: " + incident.ToString() ,
                Subtitle = "" + booking.ToString() + "",
                Text = "Status update from Team: " + desc.ToString() + "",
                Images = new List<CardImage> { new CardImage("http://localhost:3978/Images/Logo.png") },
               
               //Images = new List<CardImage> { new CardImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX4EE5eYZ625C03SfumsuK13kIcpm5nNzJMVyYbVByByuHq--cA") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Anything else I can Help you with?", value: "#") },
            };

            return heroCard;
        }




        public static HeroCard GetHeroCardforStatusUpdate(object incident, object booking, object update )
        {
            var heroCard = new HeroCard
            {
                Title = "INCIDENT NO: " + incident.ToString(),
                Subtitle = "Updated Comment : " + booking.ToString() + "",
                Text = "User Comment : " + update.ToString()+"",
                Images = new List<CardImage> { new CardImage("http://localhost:3978/Images/Logo.png") },
               
                // Images = new List<CardImage> { new CardImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX4EE5eYZ625C03SfumsuK13kIcpm5nNzJMVyYbVByByuHq--cA") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Anything else I can Help you with?", value: "#") },
            };

            return heroCard;
        }



        public static ThumbnailCard GetThumbnailCard()
        {
            var heroCard = new ThumbnailCard
            {
                Title = "BotFramework Thumbnail Card",
                Subtitle = "Microsoft Bot Framework",
                Text = "Build and connect intelligent bots to interact with your users naturally wherever they are," +
                       " from text/sms to Skype, Slack, Office 365 mail and other popular services.",
                Images = new List<CardImage> { new CardImage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX4EE5eYZ625C03SfumsuK13kIcpm5nNzJMVyYbVByByuHq--cA") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return heroCard;
        }

      

        public static SigninCard GetSigninCard()
        {
            var signinCard = new SigninCard
            {
                Text = "BotFramework Sign-in Card",
                Buttons = new List<CardAction> { new CardAction(ActionTypes.Signin, "Sign-in", value: "https://login.microsoftonline.com/") },
            };

            return signinCard;
        }

    }
}
