using System;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class Fallback:IntentNameSynchronousRequestHandler<APLSkillRequest>
    {
        private const string fallbackText = "I'm not sure what you were asking for, please ask again";
        private const string reprompt = "What roll would you like me to make?";

        public Fallback() : base(BuiltInIntent.Fallback)
        {
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            return ResponseBuilder.Ask(fallbackText, new Reprompt(reprompt));
        }
    }
}
