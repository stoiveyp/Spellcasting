using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class SessionEnded:SynchronousRequestHandler<APLSkillRequest>
    {
        public override bool CanHandle(AlexaRequestInformation<APLSkillRequest> information)
        {
            return information.SkillRequest.Request is SessionEndedRequest;
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            return ResponseBuilder.Tell(string.Empty);
        }
    }
}
