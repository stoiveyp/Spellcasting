using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class NoRequestHandlerFound:SynchronousErrorHandler<APLSkillRequest>
    {
        public override bool CanHandle(AlexaRequestInformation<APLSkillRequest> information, Exception exception)
        {
            return exception is AlexaRequestHandlerNotFoundException;
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information, Exception exception)
        {
            return new Fallback().HandleSyncRequest(information);
        }
    }
}
