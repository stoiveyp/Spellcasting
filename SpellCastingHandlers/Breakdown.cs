using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class Breakdown:IntentNameSynchronousRequestHandler<APLSkillRequest> {
        public Breakdown() : base(IntentNames.Breakdown)
        {
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            throw new NotImplementedException();
        }
    }
}
