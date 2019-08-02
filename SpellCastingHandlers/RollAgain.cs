using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;
using SpellCastingLogic;

namespace SpellCastingHandlers
{
    public class RollAgain : IntentNameRequestHandler<APLSkillRequest>
    {
        public RollAgain() : base(IntentNames.RollAgain)
        {
        }

        public override Task<SkillResponse> Handle(AlexaRequestInformation<APLSkillRequest> information)
        {
            var lastResult = information.State.GetSession<DiceRollerResult>(StateKeys.LastRoll);
            if (lastResult == null)
            {
                return Task.FromResult(NoLastRoll());
            }

            var result = Roll.GetResult(lastResult.Request);
            return Roll.GetResponse(information, result);
        }

        private const string _noLastRoll = "I can't find the last roll you made in this session, what roll would you like to make?";

        private SkillResponse NoLastRoll()
        {
            return ResponseBuilder.Ask(_noLastRoll, new Reprompt("What roll would you like me to make?"));
        }
    }
}
