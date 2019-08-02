using System;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.InSkillPricing;
using Alexa.NET.InSkillPricing.Directives;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class RollHistory : IntentNameRequestHandler<APLSkillRequest>
    {
        public readonly string _appName;
        private const string Unavailable = "I'm afraid the ability to look at your previous rolls isn't currently available";

        public RollHistory(string appName) : base(IntentNames.RollHistory)
        {
            AppName = appName;
        }

        public override Task<SkillResponse> Handle(AlexaRequestInformation<APLSkillRequest> information)
        {
            var historyProduct = ActiveRollHistory.GetProduct();

            if (historyProduct.Entitled == Entitlement.Entitled)
            {
                return UserRollHistory(information);
            }

            if (historyProduct.Purchasable == PurchaseState.Purchasable)
            {
                return UpsellRollHistory(historyProduct, information);
            }

            return UnableToOfferRollHistory(information);
        }

        private Task<SkillResponse> UserRollHistory(AlexaRequestInformation<APLSkillRequest> information)
        {
            return ActiveRollHistory.GiveToUser(information);
        }

        private Task<SkillResponse> UpsellRollHistory(InSkillProduct product, AlexaRequestInformation<APLSkillRequest> information)
        {
            var token = Guid.NewGuid().ToString("N");
            //TODO: See why I'd need this if it's transactional state?

            var buy = new BuyDirective(product.ProductId, token);
            buy.Payload.UpsellMessage = "You can keep track of your last ten rolls and ask for detail about them";
            //TODO: Check rules on this


            var upsell = ResponseBuilder.Ask($"Roll history is available as extra functionality in {_appName}", null);
            upsell.Response.Directives.Add(buy);

            return Task.FromResult(upsell);
        }

        private Task<SkillResponse> UnableToOfferRollHistory(AlexaRequestInformation<APLSkillRequest> information)
        {
            return Task.FromResult(ResponseBuilder.Tell(Unavailable));
        }
    }
}
