using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.InSkillPricing;
using Alexa.NET.InSkillPricing.Directives;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class BuyAnyProduct : IntentNameSynchronousRequestHandler<APLSkillRequest>
    {
        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            return ResponseBuilder.Ask(
                "Roll history is available to keep track of your last ten rolls, if you'd like to buy it then just ask to buy roll history",
                null);
        }

        public BuyAnyProduct() : base(IntentNames.BuyProduct)
        {
        }
    }
}
