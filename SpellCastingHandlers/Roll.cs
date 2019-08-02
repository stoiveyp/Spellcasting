using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.APL;
using Alexa.NET.APL.Commands;
using Alexa.NET.APL.Components;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;
using Alexa.NET.Response.APL;
using SpellCastingHandlers.APL;
using SpellCastingLogic;

namespace SpellCastingHandlers
{
    public class Roll : IAlexaRequestHandler<APLSkillRequest>
    {
        public bool CanHandle(AlexaRequestInformation<APLSkillRequest> information)
        {
            if (!information.SkillRequest.IsIntentName(IntentNames.Roll))
            {
                return false;
            }

            SetDefaults(information.SkillRequest.Request as IntentRequest);

            return true;
        }

        private void SetDefaults(IntentRequest intentRequest)
        {
            var slots = intentRequest.Intent.Slots ?? (intentRequest.Intent.Slots = new Dictionary<string, Slot>());

            slots.AddIfNotExist(SlotNames.Number, 1.ToString());
            slots.AddIfNotExist(SlotNames.Side, 6.ToString());
        }

        public static Task<SkillResponse> GenerateRoll(AlexaRequestInformation<APLSkillRequest> information)
        {
            var result = GetResult(information.SkillRequest);
            return GetResponse(information, result);
        }

        private const string reprompt = "If you'd like me to roll again, just say 'roll again'";

        public static async Task<SkillResponse> GetResponse(AlexaRequestInformation<APLSkillRequest> information, DiceRollerResult result)
        {
            information.State.SetSession(StateKeys.LastRoll, result);
            await ActiveRollHistory.SaveRoll(information, result);
            var response = $"You rolled {result.Total}";
            var ask = ResponseBuilder.Ask(response, new Reprompt(reprompt));

            if (information.SkillRequest.SupportsAPL1_1())
            {
                ask.Response.Directives.Add(new RenderDocumentDirective
                {
                    Document = RollScreen.Generate(result)
                });
            }

            return ask;
        }

        public static DiceRollerResult GetResult(SkillRequest skillRequest)
        {
            var slots = ((IntentRequest)skillRequest.Request).Intent.Slots;
            var number = slots.GetInt(SlotNames.Number);
            var sides = slots.GetInt(SlotNames.Side);
            return GetResult(new DiceRollerRequest(number, sides));
        }
        public static DiceRollerResult GetResult(DiceRollerRequest request)
        {
            return DiceRoller.Roll(request);
        }
    }
}
