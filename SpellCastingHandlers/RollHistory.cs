using System;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.InSkillPricing;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class RollHistory:IntentNameRequestHandler<APLSkillRequest>
    {
        public RollHistory() : base(IntentNames.RollHistory)
        {
        }

        public override Task<SkillResponse> Handle(AlexaRequestInformation<APLSkillRequest> information)
        {

        }
    }
}
