// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;
using CoreBot.Cards;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;
using SNOW.snowLogger;
using Microsoft.Recognizers.Text;

namespace Microsoft.BotBuilderSamples.Dialogs
{
    public class ServiceCatlogDialog : CancelAndHelpDialog
    {

        protected readonly IConfiguration Configuration;
        protected readonly ILogger Logger;
        public CoreBot.models.Incident_api_result incident_Api_Result = null;

        public CoreBot.models.apiresult apiresult = null;
        //IncidentDetails incidentDetails = new IncidentDetails();
        public ServiceCatlogDialog()
            : base(nameof(ServiceCatlogDialog))
        {
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
            //AddDialog(new DateResolverDialog());
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
             // DestinationStepAsync,
              OriginStepAsync,
              //Commment_ascalateStepConfirmAsync,
           //   Commment_ascalateStepAsync,

            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> OriginStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

            string catlog1 = "1.AWS(type:t2.nano.Image:centos7)";
            string catlog2 = "2.AWS(type:t2.small.Image:centos7)";

            return await stepContext.PromptAsync(nameof(ChoicePrompt),
              new PromptOptions
              {
                  Prompt = MessageFactory.Text("Ok, Please select the request to be raised from the available catlog."),
                  Choices = ChoiceFactory.ToChoices(new List<string> { catlog1, catlog2 }),
                  Style = ListStyle.HeroCard
                  // Choices = ChoiceFactory.ToChoices(new List<string> { "Add my comment for SNOW team", "Escalate this issue", "I am Satisfied" }),
              }, cancellationToken);

        }

    }


}
