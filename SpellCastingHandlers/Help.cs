using System;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;
using SpellCastingLogic;

namespace SpellCastingHandlers
{
    public class Help:IntentNameSynchronousRequestHandler<APLSkillRequest>
    {
        private const string welcomeText =
            @"Just tell spell caster how many dice you want to roll, and how many sides the dice need to have. If you don't specify the number of sides, I'll assume standard six sided dice.
I'll give you the total, but you can ask for the individual numbers if they're important to you, just say 'what numbers did I roll' after you've heard the number.
If you need to make the same roll again just say 'roll again'. You can try now by saying 'roll a dice'?";
        private const string reprompt = "If you want to give spell caster a try, just say 'roll a dice'";

        public Help() : base(BuiltInIntent.Help)
        {
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {

            return ResponseBuilder.Ask(welcomeText, new Reprompt(reprompt));
        }
    }
}
