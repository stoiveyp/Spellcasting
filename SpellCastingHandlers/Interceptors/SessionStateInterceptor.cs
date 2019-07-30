using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class SessionStateInterceptor:IAlexaRequestInterceptor<APLSkillRequest>
    {
        public async Task<SkillResponse> Intercept(AlexaRequestInformation<APLSkillRequest> information, RequestInterceptorCall<APLSkillRequest> next)
        {
            var result = await next(information);
            if (result.SessionAttributes == null)
            {
                result.SessionAttributes = information.State.Session.Attributes;
            }

            return result;
        }
    }
}
