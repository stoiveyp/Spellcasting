﻿using System;
using System.Collections.Generic;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;
using SpellCastingLogic;

namespace SpellCastingHandlers
{
    public class Roll:SynchronousRequestHandler<APLSkillRequest>
    {
        public override bool CanHandle(AlexaRequestInformation<APLSkillRequest> information)
        {
            if (!information.SkillRequest.IsIntentName(IntentNames.Roll))
            {
                return false;
            }

            SetDefaults(information.SkillRequest.Request as IntentRequest);

            return true;
        }

        private void SetDefaults(IntentRequest intentRequest)
        {
            var slots = intentRequest.Intent.Slots ?? (intentRequest.Intent.Slots = new Dictionary<string, Slot>());
            
            slots.AddIfNotExist(SlotNames.Number,1.ToString());
            slots.AddIfNotExist(SlotNames.Side,6.ToString());
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            return GenerateRoll(information);
        }

        public static SkillResponse GenerateRoll(AlexaRequestInformation<APLSkillRequest> information)
        {
            var result = GetResult(information.SkillRequest);
            information.State.SetSession(SessionKeys.LastRoll, result);
            return GetResponse(result);
        }

        private const string reprompt = "If you'd like me to roll again, just say 'roll again'";

        public static SkillResponse GetResponse(DiceRollerResult result)
        {
            var response = $"You rolled {result.Total}";
            return ResponseBuilder.Ask(response,new Reprompt(reprompt));
        }

        public static DiceRollerResult GetResult(SkillRequest skillRequest)
        {
            var slots = ((IntentRequest)skillRequest.Request).Intent.Slots;
            var number = int.Parse(slots[SlotNames.Number].Value);
            var sides = int.Parse(slots[SlotNames.Side].Value);
            return GetResult(new DiceRollerRequest(number, sides));
        }
        public static DiceRollerResult GetResult(DiceRollerRequest request)
        {
            return DiceRoller.Roll(request);
        }
    }

    public static class SessionKeys
    {
        public const string LastRoll = "lastRoll";
    }
}