using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.InSkillPricing;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using SpellCastingLogic;

namespace SpellCastingHandlers
{
    internal class ActiveRollHistory
    {
        public static InSkillProduct GetProduct<T>(AlexaRequestInformation<T> information) where T:SkillRequest
        {
            var products = information.State.GetSession<InSkillProduct[]>(StateKeys.Products);
            return products.First(p => p.ReferenceName == ProductNames.RollHistory);
        }

        public static async Task<Queue<DiceRollerResult>> GetHistory(AlexaRequestInformation<APLSkillRequest> information)
        {
            if (information.Items.ContainsKey(StateKeys.RollHistory))
            {
                return (Queue<DiceRollerResult>)information.Items[StateKeys.RollHistory];
            }

            var rolls = await information.State.Get<DiceRollerResult[]>(StateKeys.RollHistory);
            var rollQueue = rolls == null ? new Queue<DiceRollerResult>(10) : new Queue<DiceRollerResult>(rolls);
            information.Items[StateKeys.RollHistory] = rollQueue;
            return rollQueue;
        }

        public static async Task SaveRoll(AlexaRequestInformation<APLSkillRequest> information, DiceRollerResult newResult)
        {
            if (GetProduct(information).Entitled != Entitlement.Entitled)
            {
                return;
            }

            var queue = await GetHistory(information);
            queue.Enqueue(newResult);

            if (queue.Count > 10)
            {
                queue.Dequeue();
            }

            //TODO: Set up persistent storage
            await information.State.SetPersistent(StateKeys.RollHistory, queue.ToArray());
        }

        public static Task<SkillResponse> GiveToUser(AlexaRequestInformation<APLSkillRequest> information)
        {
            //TODO: Display if available, last results always 
            throw new NotImplementedException();
        }
    }
}