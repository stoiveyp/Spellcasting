using System;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class Launch:LaunchRequestHandler<APLSkillRequest>
    {
        private const string launchText = "Welcome to spell caster, how many dice would you like me to roll?";
        private const string reprompt = "How many dice would you like me to roll?";

        public override Task<SkillResponse> Handle(AlexaRequestInformation<APLSkillRequest> information)
        {
            return Task.FromResult(ResponseBuilder.Ask(
                launchText,
                new Reprompt(reprompt)));
        }
    }
}
