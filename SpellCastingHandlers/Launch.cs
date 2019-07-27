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
        public override Task<SkillResponse> Handle(AlexaRequestInformation<APLSkillRequest> information)
        {
            return Task.FromResult(ResponseBuilder.Ask("What roll would you like to make?",new Reprompt("What's the roll?")));
        }
    }
}
