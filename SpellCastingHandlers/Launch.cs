using System;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class Launch:LaunchSynchronousRequestHandler<APLSkillRequest>
    {
        private const string launchText = "Welcome to spell caster, how many dice would you like me to roll?";
        private const string reprompt = "How many dice would you like me to roll?";

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            return ResponseBuilder.Ask(
                launchText,
                new Reprompt(reprompt));
        }
    }
}
