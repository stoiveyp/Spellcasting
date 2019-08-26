using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;

namespace SpellCastingHandlers
{
    public class SkillPipeline
    {
        public static AlexaRequestPipeline<APLSkillRequest> Create(string appName)
        {
            return new AlexaRequestPipeline<APLSkillRequest>
            (
                new IAlexaRequestHandler<APLSkillRequest>[]
                {
                    new Launch(appName),
                    new Roll(),
                    new RollAgain(),
                    new Breakdown(),
                    new RollHistory(appName),
                    new BuySpecificProduct(), 
                    new BuyAnyProduct(), 
                    new Help(appName),
                    new Fallback(),
                    new SessionEnded()
                },
                new[]
                {
                    new NoRequestHandlerFound()
                },
                new IAlexaRequestInterceptor<APLSkillRequest>[]
                {
                    new ProductStateInterceptor(),
                    new SessionStateInterceptor()
                }, null
            );
        }
    }
}
