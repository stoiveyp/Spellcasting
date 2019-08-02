using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.InSkillPricing;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class ProductStateInterceptor:IAlexaRequestInterceptor<APLSkillRequest>
    {
        public async Task<SkillResponse> Intercept(AlexaRequestInformation<APLSkillRequest> information, RequestInterceptorCall<APLSkillRequest> next)
        {
            await GetProduct(information);
            return await next(information);
        }

        private async Task GetProduct(AlexaRequestInformation<APLSkillRequest> information)
        {
            var product = information.State.GetSession<InSkillProduct[]>(StateKeys.Products);

            if (product != null)
            {
                return;
            }

            var client = new InSkillProductsClient(information.SkillRequest);
            var response = await client.GetProducts();
            information.State.SetSession(StateKeys.Products,response.Products);
        }
    }
}
