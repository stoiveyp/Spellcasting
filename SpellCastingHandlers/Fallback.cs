using System;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class Fallback:IntentNameRequestHandler<APLSkillRequest>
    {
        public Fallback() : base(BuiltInIntent.Fallback)
        {
        }

        public override Task<SkillResponse> Handle(AlexaRequestInformation<APLSkillRequest> information)
        {
            throw new NotImplementedException();
        }
    }
}
