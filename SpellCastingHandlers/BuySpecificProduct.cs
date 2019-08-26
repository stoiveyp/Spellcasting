using System;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.InSkillPricing;
using Alexa.NET.InSkillPricing.Directives;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class BuySpecificProduct:IAlexaRequestHandler<APLSkillRequest>
    {
        public bool CanHandle(AlexaRequestInformation<APLSkillRequest> information)
        {
            return information.SkillRequest.Request is IntentRequest intent &&
                   intent.Intent.Name == IntentNames.BuyProduct &&
                   intent.Intent.Slots.ContainsKey(SlotNames.ProductName)
                   && !string.IsNullOrWhiteSpace(intent.Intent.Slots[SlotNames.ProductName].Value);
        }

        public async Task<SkillResponse> Handle(AlexaRequestInformation<APLSkillRequest> information)
        {
            var intent = information.SkillRequest.Request as IntentRequest;

            var products = await information.State.Get<InSkillProduct[]>(StateKeys.Products);
            var slotId = intent.Intent.Slots[SlotNames.ProductName].Resolution.Authorities
                .First(a => a.Name.StartsWith("amzn")).Values.First().Value.Id;
            var productId = products.First(p => p.ReferenceName == slotId).ProductId;

            var response = ResponseBuilder.Empty();
            response.Response.Directives.Add(new BuyDirective(productId,Guid.NewGuid().ToString("N")));

            return response;
        }
    }
}
