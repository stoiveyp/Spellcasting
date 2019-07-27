using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class Help:IntentNameSynchronousRequestHandler<APLSkillRequest>
    {
        private readonly string _welcomeText;
        private readonly string _reprompt;

        public Help(string appName) : base(BuiltInIntent.Help)
        {
            _welcomeText =
                $@"Just tell {appName} how many dice you want to roll, and how many sides the dice need to have. If you don't specify the number of sides, I'll assume standard six sided dice.
I'll give you the total, but you can ask for the individual numbers if they're important to you, just say 'what numbers did I roll' after you've heard the number.
If you need to make the same roll again just say 'roll again'. You can try now by saying 'roll a dice'?";
            _reprompt = $"If you want to give {appName} a try, just say 'roll a dice'";
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            return ResponseBuilder.Ask(_welcomeText, new Reprompt(_reprompt));
        }
    }
}
