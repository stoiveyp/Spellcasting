using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;
using SpellCastingLogic;

namespace SpellCastingHandlers
{
    public class RollAgain:IntentNameSynchronousRequestHandler<APLSkillRequest>
    {
        public RollAgain() : base(IntentNames.RollAgain)
        {
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            var lastResult = information.State.GetSession<DiceRollerResult>(SessionKeys.LastRoll);
            if(lastResult == null)
            {
                return NoLastRoll();
            }

            var result = Roll.GetResult(lastResult.Request);
            information.State.SetSession(SessionKeys.LastRoll, result);
            return Roll.GetResponse(result, information.SkillRequest.SupportsAPL1_1());
        }

        private const string _noLastRoll = "I can't find the last roll you made in this session, what roll would you like to make?";

        private SkillResponse NoLastRoll()
        {
            return ResponseBuilder.Ask(_noLastRoll, new Reprompt("What roll would you like me to make?"));
        }
    }
}
