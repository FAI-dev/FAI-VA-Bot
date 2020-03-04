// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.BotBuilderSamples.Dialogs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.BotBuilderSamples
{
    public static class LuisHelper
    {
     //   public static object RecognizerResult { get; private set; }

        public static async Task<IncidentDetails> ExecuteLuisQuery(IConfiguration configuration, ILogger logger, ITurnContext turnContext, /*RecognizerResult luisresult,*/ CancellationToken cancellationToken)
        {
            var incidentDetails = new IncidentDetails();


          //  RecognizerResult = luisresult;

            try
            {
                // Create the LUIS settings from configuration.
                var luisApplication = new LuisApplication(
                    configuration["LuisAppIdForSnow"],
                    configuration["LuisAPIKey"],
                    configuration["LuisAPIHostNameforiter"]
                  // $"https://{configuration["LuisAPIHostName"]}.api.cognitive.microsoft.com"))
                );





                var recognizer = new LuisRecognizer(luisApplication);

                // The actual call to LUIS
                var recognizerResult = await recognizer.RecognizeAsync(turnContext, cancellationToken);


              //  var intent = luisresult.GetTopScoringIntent();

                //  var (intent, score) = luisresult.GetTopScoringIntent();

                 var (intent, score) = recognizerResult.GetTopScoringIntent();
                if (intent == "sap_intent")
                {

                    incidentDetails.sap_intent = "true";
                    incidentDetails.None = "true";


                }
                else
                {
                    incidentDetails.sap_intent = "false";
                    incidentDetails.None = "false";
                }

                if (intent == "create_incident")
                {

                    incidentDetails.Create_incident = "true";

                    // We need to get the result from the LUIS JSON which at every level returns an array.
                    //    incidentDetails.Destination = recognizerResult.Entities["To"]?.FirstOrDefault()?["Airport"]?.FirstOrDefault()?.FirstOrDefault()?.ToString();
                    //  incidentDetails.Origin = recognizerResult.Entities["From"]?.FirstOrDefault()?["Airport"]?.FirstOrDefault()?.FirstOrDefault()?.ToString();

                    // This value will be a TIMEX. And we are only interested in a Date so grab the first result and drop the Time part.
                    // TIMEX is a format that represents DateTime expressions that include some ambiguity. e.g. missing a Year.
                    //incidentDetails.TravelDate = recognizerResult.Entities["datetime"]?.FirstOrDefault()?["timex"]?.FirstOrDefault()?.ToString().Split('T')[0];


                    //  BeginDialogAsync(nameof(IncidentDialog), incidentDetails, cancellationToken);
                }
                else
                {
                    incidentDetails.Create_incident = "false";

                }



                if (intent == "create_catlog")
                {

                    incidentDetails.Create_catalog = "true";

                    // We need to get the result from the LUIS JSON which at every level returns an array.
                    //    incidentDetails.Destination = recognizerResult.Entities["To"]?.FirstOrDefault()?["Airport"]?.FirstOrDefault()?.FirstOrDefault()?.ToString();
                    //  incidentDetails.Origin = recognizerResult.Entities["From"]?.FirstOrDefault()?["Airport"]?.FirstOrDefault()?.FirstOrDefault()?.ToString();

                    // This value will be a TIMEX. And we are only interested in a Date so grab the first result and drop the Time part.
                    // TIMEX is a format that represents DateTime expressions that include some ambiguity. e.g. missing a Year.
                    //incidentDetails.TravelDate = recognizerResult.Entities["datetime"]?.FirstOrDefault()?["timex"]?.FirstOrDefault()?.ToString().Split('T')[0];


                    //  BeginDialogAsync(nameof(IncidentDialog), incidentDetails, cancellationToken);
                }
                else
                {
                    incidentDetails.Create_catalog = "false";

                }



                if (intent == "None")
                {

                    incidentDetails.None = "true";

                    
                }
                else
                {
                    incidentDetails.None = "false";

                }

                if (intent == "incident_status")
                {

                    incidentDetails.Incident_status = "true";

                    incidentDetails.Incident_No = recognizerResult.Entities["incident_no"]?.FirstOrDefault().ToString();


                }
                else
                {
                    incidentDetails.Incident_status = "false";

                }





            }
            catch (Exception e)
            {
                logger.LogWarning($"LUIS Exception: {e.Message} Check your LUIS configuration.");
            }

            return incidentDetails;
        }
    }
}
